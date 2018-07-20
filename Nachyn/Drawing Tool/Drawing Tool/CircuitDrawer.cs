using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;
using Model.Factories;

namespace DrawingTool
{
    /// <summary>
    ///     Рисовальщик электрической цепи на панели
    /// </summary>
    public class CircuitDrawer
    {
        /// <summary>
        ///     Электрическая цепь
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        ///     Панель на которой рисуется цепь
        /// </summary>
        private readonly Panel _panel;

        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        public readonly List<ViewElement> ViewElements = new List<ViewElement>();

        /// <summary>
        ///     Ручка которая рисует цепь
        /// </summary>
        private Pen _pen = new Pen(Color.Black, 4);

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="panel">Панель</param>
        /// <param name="circuit">Электрическая цепь</param>
        public CircuitDrawer(Panel panel, Circuit circuit)
        {
            if (circuit == null || panel == null)
            {
                throw new ArgumentNullException();
            }

            _panel = panel;
            _circuit = circuit;
        }

        /// <summary>
        ///     Цвет пустой ветки
        /// </summary>
        public Color EmptyBranchColor { get; set; } = Color.Red;

        /// <summary>
        ///     Задает ручку которая рисует цепь
        /// </summary>
        public Pen Pen
        {
            set => _pen = value ?? throw new ArgumentNullException();
        }

        /// <summary>
        ///     Задает и возвращает шаг пустой линии
        /// </summary>
        public uint StepEmptyLine { get; set; } = 5;

        /// <summary>
        ///     Задает и возвращает шаг визуального элемента
        /// </summary>
        public uint StepElement { get; set; } = 80;

        /// <summary>
        ///     Задает и возвращает высоту между ветками в группе
        /// </summary>
        public uint HeightBetweenBranches { get; set; } = 60;

        /// <summary>
        ///     Задает и возвращает ширину(шаг) между группами ветвей
        /// </summary>
        public uint WidthBetweenGroupsBranches { get; set; } = 20;

        /// <summary>
        ///     Задает и возвращает логическое значение отрисовки пустых ветвей
        /// </summary>
        public bool IsDrawEmptyBranches { get; set; }

        /// <summary>
        ///     Задает и возвращает отступ визуального элемента по координате Y от пустой линии
        /// </summary>
        public int ElementLinePositionY { get; set; } = -26;

        /// <summary>
        ///     Сброс всех настроек по умолчанию
        /// </summary>
        public void ResetSettings()
        {
            StepEmptyLine = 5;
            StepElement = 80;
            HeightBetweenBranches = 60;
            WidthBetweenGroupsBranches = 20;
            ElementLinePositionY = -26;
            IsDrawEmptyBranches = false;
        }

        /// <summary>
        ///     Нарисовать цепь
        /// </summary>
        public void DrawCircuit()
        {
            ClearPanel();

            if (!IsDrawEmptyBranches)
            {
                _circuit.ClearEmptyBranches();
            }

            Dictionary<string, Dictionary<int, List<ViewElement>>> viewBranches =
                GetViewBranches();

            int sumMaxCountElementsInGroups = 0;
            int maxCountBranchesInGroups = 0;

            foreach (string keyBranchs in viewBranches.Keys)
            {
                sumMaxCountElementsInGroups +=
                    GetMaxCountElementsInGroupBranches(viewBranches[keyBranchs]);

                if (viewBranches[keyBranchs].Keys.Count > maxCountBranchesInGroups)
                {
                    maxCountBranchesInGroups = viewBranches[keyBranchs].Keys.Count;
                }
            }

            int widthBitmap = sumMaxCountElementsInGroups * (int) StepElement +
                              (int) StepEmptyLine * viewBranches.Keys.Count +
                              (int) WidthBetweenGroupsBranches * viewBranches.Keys.Count
                              + 60;

            int heightBitmap =
                maxCountBranchesInGroups * (int) HeightBetweenBranches + 20;

            Bitmap bitmapBackground =
                new Bitmap(widthBitmap, heightBitmap);

            using (Graphics scheme = Graphics.FromImage(bitmapBackground))
            {
                Point groupBranchs = new Point(20, 30);

                if (sumMaxCountElementsInGroups > 0)
                {
                    scheme.DrawLine(_pen, new Point(0, groupBranchs.Y), groupBranchs);
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
                            groupBranch.X + (int) StepEmptyLine,
                            groupBranch.Y);

                        scheme.DrawLine(_pen, groupBranch, startDrawingElementsPoint);

                        foreach (ViewElement viewElement in viewBranches[keyBranchs][
                            keyBranch])
                        {
                            viewElement.Location = new Point(startDrawingElementsPoint.X,
                                startDrawingElementsPoint.Y + ElementLinePositionY);

                            _panel.Controls.Add(viewElement);
                            startDrawingElementsPoint.X += (int) StepElement;
                        }

                        groupBranch = DrawBranchLines(groupBranch,
                            maxCountElementsInGroup, scheme, viewBranches, keyBranchs,
                            keyBranch);
                    }

                    groupBranchs = DrawGroupBorders(groupBranch, countGroupBranches,
                        scheme, maxCountElementsInGroup);
                }
            }

            PictureBox background = new PictureBox();
            background.SizeMode = PictureBoxSizeMode.AutoSize;
            background.Image = bitmapBackground;
            _panel.Controls.Add(background);
            background.Location = new Point(0, 0);
        }

        /// <summary>
        ///     Нарисовать границы в группе
        /// </summary>
        /// <param name="groupBranch">Точка начала отрисовки группы</param>
        /// <param name="countGroupBranches">Количество ветвей в группе</param>
        /// <param name="scheme">Схема которая отрисуется на панели</param>
        /// <param name="maxCountElementsInGroup">Максимальное количество визуальных элементов в группе</param>
        /// <returns></returns>
        private Point DrawGroupBorders(Point groupBranch, int countGroupBranches,
            Graphics scheme,
            int maxCountElementsInGroup)
        {
            Point groupBranchs;
            Point lowerPointLeftBorderGroup = new Point(groupBranch.X,
                groupBranch.Y - (int) HeightBetweenBranches);

            Point upperPointLeftBorderGroup = new Point(groupBranch.X,
                groupBranch.Y - (int) HeightBetweenBranches * countGroupBranches);

            scheme.DrawLine(_pen, lowerPointLeftBorderGroup,
                upperPointLeftBorderGroup);

            Point lowerPointRightBorderGroup =
                new Point(
                    groupBranch.X + maxCountElementsInGroup * (int) StepElement +
                    2 * (int) StepEmptyLine,
                    groupBranch.Y - (int) HeightBetweenBranches);

            Point upperPointRightBorderGroup = new Point(
                groupBranch.X + maxCountElementsInGroup * (int) StepElement +
                2 * (int) StepEmptyLine,
                groupBranch.Y - (int) HeightBetweenBranches * countGroupBranches);

            scheme.DrawLine(_pen, lowerPointRightBorderGroup,
                upperPointRightBorderGroup);

            Point lastGroupPoint = new Point(
                upperPointRightBorderGroup.X + (int) WidthBetweenGroupsBranches,
                upperPointRightBorderGroup.Y);

            scheme.DrawLine(_pen, upperPointRightBorderGroup, lastGroupPoint);
            groupBranchs = lastGroupPoint;
            return groupBranchs;
        }

        private Point DrawBranchLines(Point groupBranch, int maxCountElementsInGroup,
            Graphics scheme,
            Dictionary<string, Dictionary<int, List<ViewElement>>> viewBranches,
            string keyBranchs, int keyBranch)
        {
            Point leftPointHorizontalBranchLine =
                new Point(groupBranch.X + (int) StepEmptyLine, groupBranch.Y);

            Point rightPointHorizontalBranchLine =
                new Point(
                    leftPointHorizontalBranchLine.X +
                    maxCountElementsInGroup * (int) StepElement + (int) StepEmptyLine,
                    leftPointHorizontalBranchLine.Y);

            scheme.DrawLine(_pen, leftPointHorizontalBranchLine,
                rightPointHorizontalBranchLine);

            if (viewBranches[keyBranchs][keyBranch].Count < 1 &&
                viewBranches[keyBranchs].Keys.Count > 1)
            {
                scheme.DrawLine(new Pen(EmptyBranchColor, _pen.Width),
                    new Point(leftPointHorizontalBranchLine.X + (int) StepEmptyLine,
                        leftPointHorizontalBranchLine.Y),
                    new Point(rightPointHorizontalBranchLine.X - (int) StepEmptyLine,
                        rightPointHorizontalBranchLine.Y));
            }

            groupBranch = new Point(groupBranch.X,
                groupBranch.Y + (int) HeightBetweenBranches);

            return groupBranch;
        }

        /// <summary>
        ///     Получить максимальное количество
        ///     элементов в группе ветвей
        /// </summary>
        /// <param name="group">Группа ветвей</param>
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
                    foreach (ViewElement viewElement in ViewElements)
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
        ///     Очистить цепь
        /// </summary>
        public void ClearCircuit()
        {
            _circuit.Branches.Clear();
            ViewElements.Clear();
            Branch.NodeOutLast = 0;
            ElementFactory.NumberRandomElement = 1;
            ClearPanel();
        }

        /// <summary>
        ///     Очистить панель для рисования
        /// </summary>
        private void ClearPanel()
        {
            _panel.BackgroundImage = null;
            _panel.Controls.Clear();
        }
    }
}