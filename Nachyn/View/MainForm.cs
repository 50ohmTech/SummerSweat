using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.PropertyGrid;

namespace View
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        ///     Вычисления
        /// </summary>
        private readonly Calculations _calculations;

        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        private readonly ObservableCollection<ViewElement> _viewElements =
            new ObservableCollection<ViewElement>();

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _calculations = new Calculations();
            _circuit = new Circuit();
            _propertyGrid.SelectedObject = _calculations;
            Branch.CollectionChanged += DrawCircuit;
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
            var result = MessageBox.Show("Очистить цепь?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                _circuit.Branches.Clear();
                _panelCircuit.Controls.Clear();
                _viewElements.Clear();
                _panelCircuit.BackgroundImage = null;
            }
        }


        private void ToolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            _calculations.Impedances.Clear();
            _calculations.Impedances.AddRange(
                _circuit.CalculateZ(_calculations.Frequencies.ToArray()));
        }

        Dictionary<string, Dictionary<int, List<ViewElement>>> GetViewBranches()
        {
            var viewBranches =
                new Dictionary<string, Dictionary<int, List<ViewElement>>>();

            var key = 0;
            foreach (var branch in _circuit.Branches)
            {
                if (!viewBranches.ContainsKey(branch.Key))
                {
                    viewBranches[branch.Key] = new Dictionary<int, List<ViewElement>>();
                }

                viewBranches[branch.Key][key] = new List<ViewElement>();
                foreach (var baseElement in branch.Elements)
                {
                    foreach (var viewElement in _viewElements)
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
        ///     Нарисовать цепь
        /// </summary>
        private void DrawCircuit()
        {
            _panelCircuit.BackgroundImage = null;
            _panelCircuit.Controls.Clear();

            var viewBranches = GetViewBranches();
            
            var bitmapBackground = new Bitmap(1000, 1000);
            var pen = new Pen(Color.Black, 4);
            var graphics = Graphics.FromImage(bitmapBackground);

            var stepLine = 5;           
            var stepElement = 80;
            var stepBetweenBranchesY = 50;
            var stepBetweenBranchesX = 20;
            var groupBranchs = new Point(50, 50);
            var lastX = groupBranchs.X;

            graphics.DrawLine(pen, new Point(0, groupBranchs.Y), groupBranchs);

            foreach (var keyBranchs in viewBranches.Keys)
            {
                var point = groupBranchs;

                var countElements = 0;
                var countKeys = viewBranches[keyBranchs].Keys.Count;

                foreach (var keyBranch in viewBranches[keyBranchs].Keys)
                {
                    if (viewBranches[keyBranchs][keyBranch].Count > countElements)
                    {
                        countElements = viewBranches[keyBranchs][keyBranch].Count;
                    }
                }

                foreach (var keyBranch in viewBranches[keyBranchs].Keys)
                {
                    var nextPoint = new Point(point.X + stepLine, point.Y);
                    graphics.DrawLine(pen, point, nextPoint);

                    foreach (var viewElement in viewBranches[keyBranchs][
                        keyBranch])
                    {
                        viewElement.Location = new Point(nextPoint.X, nextPoint.Y - 26);
                        _panelCircuit.Controls.Add(viewElement);
                        nextPoint.X += stepElement;
                    }

                    var startLine = new Point(point.X + stepLine, point.Y);
                    var endLine =
                        new Point(startLine.X + countElements * stepElement + stepLine,
                            startLine.Y);

                    graphics.DrawLine(pen, startLine, endLine);

                    if (viewBranches[keyBranchs][keyBranch].Count < 1 &&
                        viewBranches[keyBranchs].Keys.Count > 1)
                    {
                        graphics.DrawLine(new Pen(Color.Red, 4),
                            new Point(startLine.X + stepLine, startLine.Y),
                            new Point(endLine.X - stepLine, endLine.Y));
                    }

                    point = new Point(lastX, point.Y + stepBetweenBranchesY);
                }

                var endBorder = new Point(point.X, point.Y - stepBetweenBranchesY);
                var startBorder = new Point(point.X,
                    point.Y - stepBetweenBranchesY * countKeys);

                graphics.DrawLine(pen, endBorder, startBorder);

                var endBorder2 =
                    new Point(point.X + countElements * stepElement + 2 * stepLine,
                        point.Y - stepBetweenBranchesY);

                var startBorder2 = new Point(
                    point.X + countElements * stepElement + 2 * stepLine,
                    point.Y - stepBetweenBranchesY * countKeys);

                graphics.DrawLine(pen, endBorder2, startBorder2);
                var lastPoint = new Point(startBorder2.X + stepBetweenBranchesX, startBorder2.Y);
                graphics.DrawLine(pen, startBorder2, lastPoint);
                groupBranchs = lastPoint;
                lastX = lastPoint.X;
            }
            _panelCircuit.BackgroundImage = bitmapBackground;
        }
    }
}