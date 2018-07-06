using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;
using Model.Factories;

namespace View
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        private static readonly Random _random = new Random();

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;


        private readonly Pen _pen = new Pen(Color.Black, 4);

        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        private readonly List<ViewElement> _viewElements;

        /// <summary>
        ///     Точечная поверхность для рисования цепи
        /// </summary>
        private Bitmap _bitmapBackground;

        /// <summary>
        ///     Поверхность рисования GDI+
        /// </summary>
        private Graphics _graphics;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _viewElements = new List<ViewElement>();

            _circuit = new Circuit();

            Paint += MainForm_Paint;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawCircuit();
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            new ElementManagerForm(_circuit.Branches, _viewElements).ShowDialog();
            DrawCircuit();
        }

        private void ToolStripButtonClearCircuit_Click(object sender, EventArgs e)
        {
            if (_circuit.IsEmpty)
            {
                MessageBox.Show("Цепь пуста!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show("Очистить цепь?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ClearCircuit();              
            }
        }

        /// <summary>
        ///     Очистить цепь
        /// </summary>
        private void ClearCircuit()
        {
            _circuit.Branches.Clear();
            _viewElements.Clear();
            Branch.NodeOutLast = 0;
            ElementFactory.NumberRandomElement = 1;
            ClearPanel();
        }


        private void ToolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            if (_circuit.IsEmpty)
            {
                MessageBox.Show("Цепь пуста!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            new CalculationsForm(_circuit).ShowDialog();
        }

        /// <summary>
        ///     Получить визуальные элементы, распределенные
        ///     по группам ветвей
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, Dictionary<int, List<ViewElement>>> GetViewBranches()
        {
            Dictionary<string, Dictionary<int, List<ViewElement>>> viewBranches =
                new Dictionary<string, Dictionary<int, List<ViewElement>>>();

            int key = 0;
            foreach (Branch branch in _circuit.Branches)
            {
                if (!viewBranches.ContainsKey(branch.Key))
                {
                    viewBranches[branch.Key] = new Dictionary<int, List<ViewElement>>();
                }

                viewBranches[branch.Key][key] = new List<ViewElement>();
                foreach (ElementBase baseElement in branch.Elements)
                {
                    foreach (ViewElement viewElement in _viewElements)
                    {
                        if (baseElement.Equals(viewElement.Item))
                        {
                            viewBranches[branch.Key][key].Add(viewElement);
                            break;
                        }
                    }
                }

                key++;
            }

            return viewBranches;
        }

        /// <summary>
        ///     Получить максимальное количество
        ///     элементов в группе ветвей
        /// </summary>
        /// <param name="group">Группа</param>
        /// <returns></returns>
        private int GetMaxCountElementsInGroupBranches(
            Dictionary<int, List<ViewElement>> group)
        {
            int maxCount = 0;
            foreach (int keyBranch in group.Keys)
            {
                if (group[keyBranch].Count > maxCount)
                {
                    maxCount = group[keyBranch].Count;
                }
            }

            return maxCount;
        }

        /// <summary>
        ///     Нарисовать цепь
        /// </summary>
        private void DrawCircuit(int stepEmptyLine = 5, int stepElement = 80,
            int heightBetweenBranches = 60, int widthBetweenGroupsBranches = 20)
        {
            ClearPanel();

            Dictionary<string, Dictionary<int, List<ViewElement>>> viewBranches =
                GetViewBranches();

            _bitmapBackground =
                new Bitmap(_panelCircuit.Size.Width, _panelCircuit.Size.Height);

            _graphics = Graphics.FromImage(_bitmapBackground);

            Point groupBranchs = new Point(50, 50);

            int countElementsInGroups = 0;
            foreach (string keyBranchs in viewBranches.Keys)
            {
                countElementsInGroups +=
                    GetMaxCountElementsInGroupBranches(viewBranches[keyBranchs]);
            }

            if (countElementsInGroups > 0)
            {
                _graphics.DrawLine(_pen, new Point(0, groupBranchs.Y), groupBranchs);
            }

            foreach (string keyBranchs in viewBranches.Keys)
            {
                Point groupBranch = groupBranchs;

                int maxCountElementsInGroup =
                    GetMaxCountElementsInGroupBranches(viewBranches[keyBranchs]);

                int countGroupBranches = viewBranches[keyBranchs].Keys.Count;

                if (maxCountElementsInGroup == 0)
                {
                    continue;
                }

                foreach (int keyBranch in viewBranches[keyBranchs].Keys)
                {
                    Point startDrawingElementsPoint = new Point(
                        groupBranch.X + stepEmptyLine,
                        groupBranch.Y);

                    _graphics.DrawLine(_pen, groupBranch, startDrawingElementsPoint);

                    foreach (ViewElement viewElement in viewBranches[keyBranchs][
                        keyBranch])
                    {
                        viewElement.Location = new Point(startDrawingElementsPoint.X,
                            startDrawingElementsPoint.Y - 26);

                        _panelCircuit.Controls.Add(viewElement);
                        startDrawingElementsPoint.X += stepElement;
                    }

                    Point leftPointHorizontalBranchLine =
                        new Point(groupBranch.X + stepEmptyLine, groupBranch.Y);

                    Point rightPointHorizontalBranchLine =
                        new Point(
                            leftPointHorizontalBranchLine.X +
                            maxCountElementsInGroup * stepElement + stepEmptyLine,
                            leftPointHorizontalBranchLine.Y);

                    _graphics.DrawLine(_pen, leftPointHorizontalBranchLine,
                        rightPointHorizontalBranchLine);

                    if (viewBranches[keyBranchs][keyBranch].Count < 1 &&
                        viewBranches[keyBranchs].Keys.Count > 1)
                    {
                        _graphics.DrawLine(new Pen(Color.Red, 4),
                            new Point(leftPointHorizontalBranchLine.X + stepEmptyLine,
                                leftPointHorizontalBranchLine.Y),
                            new Point(rightPointHorizontalBranchLine.X - stepEmptyLine,
                                rightPointHorizontalBranchLine.Y));
                    }

                    groupBranch = new Point(groupBranch.X,
                        groupBranch.Y + heightBetweenBranches);
                }

                Point lowerPointLeftBorderGroup = new Point(groupBranch.X,
                    groupBranch.Y - heightBetweenBranches);

                Point upperPointLeftBorderGroup = new Point(groupBranch.X,
                    groupBranch.Y - heightBetweenBranches * countGroupBranches);

                _graphics.DrawLine(_pen, lowerPointLeftBorderGroup,
                    upperPointLeftBorderGroup);

                Point lowerPointRightBorderGroup =
                    new Point(
                        groupBranch.X + maxCountElementsInGroup * stepElement +
                        2 * stepEmptyLine,
                        groupBranch.Y - heightBetweenBranches);

                Point upperPointRightBorderGroup = new Point(
                    groupBranch.X + maxCountElementsInGroup * stepElement +
                    2 * stepEmptyLine,
                    groupBranch.Y - heightBetweenBranches * countGroupBranches);

                _graphics.DrawLine(_pen, lowerPointRightBorderGroup,
                    upperPointRightBorderGroup);

                Point lastGroupPoint = new Point(
                    upperPointRightBorderGroup.X + widthBetweenGroupsBranches,
                    upperPointRightBorderGroup.Y);

                _graphics.DrawLine(_pen, upperPointRightBorderGroup, lastGroupPoint);
                groupBranchs = lastGroupPoint;
            }

            _graphics.Dispose();
            _panelCircuit.BackgroundImage = _bitmapBackground;
        }

        /// <summary>
        ///     Очистить панель для рисования
        /// </summary>
        private void ClearPanel()
        {
            _panelCircuit.BackgroundImage = null;
            _panelCircuit.Controls.Clear();
        }

        private void ToolStripRandomizeCircuit_Click(object sender, EventArgs e)
        {
            ClearCircuit();

            for (uint group = 0; group < _random.Next(2) + 1; group++)
            {
                for (uint branchGroup = 0;
                    branchGroup < _random.Next(3) + 1;
                    branchGroup++)
                {
                    Branch randomBranch = new Branch(group);

                    for (uint countElements = 0;
                        countElements < _random.Next(3) + 1;
                        countElements++)
                    {
                        ElementBase randomElement = ElementFactory.GetRandomInstance();
                        _viewElements.Add(new ViewElement(randomElement,
                            randomBranch.Elements));

                        randomBranch.Elements.Add(randomElement);
                    }

                    _circuit.Branches.Add(randomBranch);
                }
            }

            DrawCircuit();
        }

        private void ToolStripButtonHelp_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }

        private static void ShowInfo()
        {
            string info =
                "* Генерируете или создаете цепь через \"Управление элементами\"\r\n" +
                "* Вводите частоты и получаете результаты в \"Рассчитать импедансы\"\r\n" +
                "\r\n* Чтоб удалить или изменить номинал на уже созданном элементе\r\n" +
                "необходимо нажать правой кнопкой мыши на элемент.";

            MessageBox.Show(info, "Инструкция");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowInfo();
        }
    }
}