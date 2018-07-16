using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;
using Model.Factories;

namespace DrawingTool
{
    public class CircuitDrawer
    {
        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        public readonly List<ViewElement> ViewElements = new List<ViewElement>();

        private readonly Circuit _circuit;

        private readonly Panel _panel;

        private Pen _pen = new Pen(Color.Black, 4);

        public CircuitDrawer(Panel panel, Circuit circuit)
        {
            _panel = panel;
            _circuit = circuit;
        }


        public Color EmptyBranchColor { get; set; } = Color.Red;

        public Pen Pen
        {
            set => _pen = value ?? throw new ArgumentNullException();
        }

        public uint StepEmptyLine { get; set; } = 5;

        public uint StepElement { get; set; } = 80;

        public uint HeightBetweenBranches { get; set; } = 60;

        public uint WidthBetweenGroupsBranches { get; set; } = 20;

        public bool IsDrawEmptyBranches { get; set; } = false;

        public int ElementLinePositionY { get; set; } = -26;

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

            int SumMaxCountElementsInGroups = 0;
            int MaxCountBranchesInGroups = 0;

            foreach (string keyBranchs in viewBranches.Keys)
            {
                SumMaxCountElementsInGroups +=
                    GetMaxCountElementsInGroupBranches(viewBranches[keyBranchs]);

                if (viewBranches[keyBranchs].Keys.Count > MaxCountBranchesInGroups)
                {
                    MaxCountBranchesInGroups = viewBranches[keyBranchs].Keys.Count;
                }
            }

            int WidthBitmap = SumMaxCountElementsInGroups * (int)StepElement +
                        (int)StepEmptyLine * viewBranches.Keys.Count + (int)WidthBetweenGroupsBranches * viewBranches.Keys.Count
                +60;

            int HeightBitmap = MaxCountBranchesInGroups * (int)HeightBetweenBranches + 20;
            Bitmap bitmapBackground =
                new Bitmap(WidthBitmap, HeightBitmap);

            using (Graphics scheme = Graphics.FromImage(bitmapBackground))
            {
                Point groupBranchs = new Point(20, 30);
               
                if (SumMaxCountElementsInGroups > 0)
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