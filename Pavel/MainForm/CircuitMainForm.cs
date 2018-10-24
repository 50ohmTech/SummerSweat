using System;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;
using View;

namespace MainForm
{
    /// <summary>
    ///     Форма создания цепи.
    /// </summary>
    public partial class CircuitMainForm : Form
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Цепь
        /// </summary>
        private Circuit _circuit;

        /// <summary>
        ///     Текущая нода
        /// </summary>
        private INode _currentNode;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Создатель готовых цепей.
        /// </summary>
        /// z
        public CircuitsCreator CircuitsCreator { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор формы CircuitMainForm
        /// </summary>
        public CircuitMainForm()
        {
            InitializeComponent();
            _circuit = new Circuit();

            CircuitsCreator = new CircuitsCreator();

            _circuit = CircuitsCreator.Circuits[0];
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Обновить дерево
        /// </summary>
        private void UpdateTreeView()
        {
            treeView.Nodes.Clear();
            _currentNode = null;

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь была null");
            }

            if (_circuit.IsEmpty())
            {
                return;
            }


            treeView.BeginUpdate();

            void AddNodeTreeNodes(INode node, TreeNode treeNode)
            {
                if (node is ElementBase)
                {
                    return;
                }

                foreach (var child in node.Nodes)
                {
                    var newTreeNode = new CircuitTreeNode(child);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(child, newTreeNode);
                }
            }

            var root = new CircuitTreeNode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            treeView.EndUpdate();
            treeView.ExpandAll();

            CircuitPictureBox.Image = null;

            var bitmapBackground = new Bitmap(1000, 1000);
            Drawer.Graphics = Graphics.FromImage(bitmapBackground);
            Drawer.Pen = new Pen(Color.Black, 1);
            Drawer.Font = Font;

            var displacement = new Point(15, 0);
            Drawer.DrawCircuit(_circuit.Root, displacement);

            CircuitPictureBox.Image = bitmapBackground;
        }

        /// <summary>
        ///     Выбор готовой тестовой цепи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            if (SelectingCircuitComboBox.SelectedIndex == 0)
            {
                CircuitPictureBox.Image = null;
            }

            if (SelectingCircuitComboBox.SelectedIndex >= 0 &&
                SelectingCircuitComboBox.SelectedIndex < 6)
            {
                _circuit =
                    CircuitsCreator.Circuits[SelectingCircuitComboBox.SelectedIndex];
            }

            else
            {
                throw new InvalidOperationException();
            }

            UpdateTreeView();
        }

        /// <summary>
        ///     Выбор ноды в TreeView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is CircuitTreeNode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        /// <summary>
        ///     Обработчик добавления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NodeComboBox.SelectedItem == null)
            {
                MessageBox.Show(
                    "Выберите элемент который хотите добавить.",
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (treeView.Nodes.Count == 0 && NodeComboBox.SelectedItem == "Параллельное")
            {
                _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
            }

            else if (treeView.Nodes.Count == 0 &&
                     NodeComboBox.SelectedItem == "Последовательное")
            {
                _circuit.AddAfter(_currentNode, new SeriesSubcircuit());
            }

            else if (NodeComboBox.SelectedItem != null && _currentNode == null)
            {
                MessageBox.Show(
                    "Выберите узел относительно которого будет происходить добавление.",
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (_circuit.ResistorCount + _circuit.InductorCount +
                _circuit.CapacitorCount < 7)
            {
                try
                {
                    switch (NodeComboBox.SelectedItem)
                    {
                        case "R":
                        {
                            _circuit.AddAfter(_currentNode, new Resistor(
                                "R" + _circuit.ResistorCount,
                                Convert.ToDouble(ValueTextBox.Value)));

                            break;
                        }

                        case "C":
                        {
                            _circuit.AddAfter(_currentNode, new Capacitor(
                                "C" + _circuit.CapacitorCount,
                                Convert.ToDouble(ValueTextBox.Value)));

                            break;
                        }

                        case "L":
                        {
                            _circuit.AddAfter(_currentNode, new Inductor(
                                "L" + _circuit.InductorCount,
                                Convert.ToDouble(ValueTextBox.Value)));

                            break;
                        }

                        case "Параллельное":
                        {
                            _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
                            break;
                        }

                        case "Последовательное":
                        {
                            _circuit.AddAfter(_currentNode, new SeriesSubcircuit());
                            break;
                        }
                    }

                    UpdateTreeView();
                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show(
                    "Достигнуто максимальное количество элементов",
                    "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

              
            }
        }
        

        /// <summary>
        ///     Обработчик удаления элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == null)
            {
                MessageBox.Show("Выберите элемент, который хотите удалить.");
            }
            else
            {
                _circuit.Remove(_currentNode);
                UpdateTreeView();
            }

            if (_circuit.Root == null)
            {
                CircuitPictureBox.Image = null;
            }
        }

        /// <summary>
        ///     Вызов формы расчета импедансов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count == 0)
            {
                MessageBox.Show("Добавьте элементы в цепь", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            new ImpedanceForm(_circuit).ShowDialog();
        }

        /// <summary>
        ///     Вызов формы изменения элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditFormButton_Click(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    var result = new EditForm(element).ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        UpdateTreeView();
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный вами узел не является элементом.");
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент, который хотите изменить.");
            }
        }

        #endregion
    }
}