using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;
using Model.Factories;
using Model.PropertyGrid;

namespace View
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        private static readonly Random _random = new Random();

        /// <summary>
        ///     Вычисления
        /// </summary>
        private readonly Calculations _calculations;

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        private readonly List<ViewElement> _viewElements;


        private readonly Pen pen = new Pen(Color.Black, 4);

        /// <summary>
        ///     Точечная поверхность для рисования цепи
        /// </summary>
        private Bitmap bitmapBackground;

        /// <summary>
        ///     Поверхность рисования GDI+
        /// </summary>
        private Graphics graphics;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _viewElements = new List<ViewElement>();
            _calculations = new Calculations();
            _circuit = new Circuit();
            _propertyGrid.SelectedObject = _calculations;
            Paint += MainForm_Paint;
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            DrawCircuit();
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
            new ControlPanel(_circuit.Branches, _viewElements).ShowDialog();
            DrawCircuit();
        }

        private void ToolStripButtonClearCircuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Очистить цепь?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

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
            ClearPanel();
        }


        private void ToolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            _calculations.Impedances.Clear();
            _calculations.Impedances.AddRange(
                _circuit.CalculateZ(_calculations.GetFrequencies()));
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
            int heightBetweenBranches = 50, int widthBetweenGroupsBranches = 20)
        {
            ClearPanel();

            Dictionary<string, Dictionary<int, List<ViewElement>>> viewBranches =
                GetViewBranches();

            bitmapBackground =
                new Bitmap(_panelCircuit.Size.Width, _panelCircuit.Size.Height);

            graphics = Graphics.FromImage(bitmapBackground);

            Point groupBranchs = new Point(50, 50);

            graphics.DrawLine(pen, new Point(0, groupBranchs.Y), groupBranchs);

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

                    graphics.DrawLine(pen, groupBranch, startDrawingElementsPoint);

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

                    graphics.DrawLine(pen, leftPointHorizontalBranchLine,
                        rightPointHorizontalBranchLine);

                    if (viewBranches[keyBranchs][keyBranch].Count < 1 &&
                        viewBranches[keyBranchs].Keys.Count > 1)
                    {
                        graphics.DrawLine(new Pen(Color.Red, 4),
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

                graphics.DrawLine(pen, lowerPointLeftBorderGroup,
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

                graphics.DrawLine(pen, lowerPointRightBorderGroup,
                    upperPointRightBorderGroup);

                Point lastGroupPoint = new Point(
                    upperPointRightBorderGroup.X + widthBetweenGroupsBranches,
                    upperPointRightBorderGroup.Y);

                graphics.DrawLine(pen, upperPointRightBorderGroup, lastGroupPoint);
                groupBranchs = lastGroupPoint;
            }

            graphics.Dispose();
            _panelCircuit.BackgroundImage = bitmapBackground;
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
                    branchGroup < _random.Next(2) + 1;
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
            string info =
                "* Генерируете или создаете цепь через \"Панель управления\"\r\n" +
                "* Вводите Частоты в \"Данные для расчета\"\r\n" +
                "* Нажимаете на \"Расчитать импедансы\"\r\n" +
                "* Результаты будут в \"Результаты\" --> \"Импедансы\"\r\n" +
                "\r\n* Чтоб удалить или изменить номинал на уже созданном элементе\r\n" +
                "необходимо нажать правой кнопкой мыши на элемент";
            MessageBox.Show(info);
        }
    }
}