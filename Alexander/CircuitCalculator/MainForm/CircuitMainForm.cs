using System;
using System.Drawing;
using System.Windows.Forms;
using Model.Circuit;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Главная форма для работы с цепями.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Properties

        /// <summary>
        ///     Создатель тестовых цепей.
        /// </summary>
        public TestCircuits TestCircuits { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _circuit = new Circuit();

            TestCircuits = new TestCircuits();
            _circuit = TestCircuits.Circuits[0];
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Обновить дерево.
        /// </summary>
        private void UpdateTreeView()
        {
            treeView.Nodes.Clear();
            _currentNode = null;

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь пуста");
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

                foreach (var children in node.Nodes)
                {
                    var newTreeNode = new CircuitTreeNode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            var root = new CircuitTreeNode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            treeView.EndUpdate();
            treeView.ExpandAll();

            PictureBox.Image = null;

            var bitmapBackground = new Bitmap(1000, 1000);
            Drawer.Graphics = Graphics.FromImage(bitmapBackground);
            Drawer.Pen = new Pen(Color.Black, 1);
            Drawer.Font = Font;

            var displacement = new Point(15, 0);
            Drawer.DrawCircuit(_circuit.Root, displacement);

            PictureBox.Image = bitmapBackground;
        }

        /// <summary>
        ///     Обработать добавление элемента.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NodeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите то, что хотите добавить");
            }
            
            if (treeView.Nodes.Count == 0 && NodeComboBox.SelectedItem == "Параллельно")
            {
                _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
            }
            else if (treeView.Nodes.Count == 0 && NodeComboBox.SelectedItem == "Последовательно")
            {
                _circuit.AddAfter(_currentNode, new SeriesSubcircuit());
            }
            else if (NodeComboBox.SelectedItem != null && _currentNode == null)
            {
                MessageBox.Show("Выберите узел");
            }
            
            if (_currentNode is SubcircuitBase subcircuit)
            {
                if (subcircuit.Nodes.Count < 7)
                {
                    if (subcircuit is SeriesSubcircuit && ReferenceEquals(NodeComboBox.SelectedItem, "Последовательно")
                    || subcircuit is ParallelSubcircuit && ReferenceEquals(NodeComboBox.SelectedItem, "Параллельно"))
                    {
                        MessageBox.Show(
                            "Нельзя создавать в параллельном/последовательном узле параллельный/последовательный узел");
                        return;
                    }

                    switch (NodeComboBox.SelectedItem)
                    {
                        case "Последовательно":
                            _circuit.AddAfter(_currentNode, new SeriesSubcircuit());
                            break;
                        case "Параллельно":
                            _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
                            break;
                        case "R":
                            _circuit.AddAfter(_currentNode,
                                new Resistor("R" + TestCircuits.ResistorIterator++,
                                    Convert.ToDouble(NominalNumericUpDown.Text)));

                            break;
                        case "L":
                            _circuit.AddAfter(_currentNode,
                                new Inductor("L" + TestCircuits.InductorIterator++,
                                    Convert.ToDouble(NominalNumericUpDown.Text)));

                            break;
                        case "C":
                            _circuit.AddAfter(_currentNode,
                                new Capacitor("C" + TestCircuits.CapacitorIterator++,
                                    Convert.ToDouble(NominalNumericUpDown.Text)));

                            break;
                    }

                    UpdateTreeView();

                }
                else
                {
                    MessageBox.Show("Достигнуто максимальное количество элементов.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UpdateTreeView();
        }

        /// <summary>
        ///     Выбрать цепь.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            if (SelectingCircuitComboBox.SelectedIndex == 0)
            {
                PictureBox.Image = null;
                treeView.Nodes.Clear();
                
            }

            if (SelectingCircuitComboBox.SelectedIndex >= 0 &&
                SelectingCircuitComboBox.SelectedIndex < 6)
            {
                _circuit = TestCircuits.Circuits[SelectingCircuitComboBox.SelectedIndex];
                TestCircuits.GetIterator(SelectingCircuitComboBox.SelectedIndex);
            }
            else
            {
                throw new InvalidOperationException();
            }

            UpdateTreeView();
        }

        /// <summary>
        ///     Выбрать текущую ноду.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is CircuitTreeNode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        /// <summary>
        ///     Удалить узел или элемент.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == null)
            {
                MessageBox.Show("Выберите элемент, который хотите удалить.");
            }
            else
            {
                try
                {
                    _circuit.Remove(_currentNode);
                    UpdateTreeView();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

            if (_circuit.Root == null)
            {
                PictureBox.Image = null;
                treeView.Nodes.Clear();
            }
        }

        /// <summary>
        ///     Выбрать узел или элемент.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void NodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NodeComboBox.Text == "Параллельно")
            {
                NominalNumericUpDown.ReadOnly = true;
            }
            else if (NodeComboBox.Text == "Последовательно")
            {
                NominalNumericUpDown.ReadOnly = true;
            }
            else
            {
                NominalNumericUpDown.ReadOnly = false;
            }
        }

        /// <summary>
        ///     Рассчитать импедансы цепи.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count == 0)
            {
                MessageBox.Show("Добавьте элементы в цепь", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            new ImpedanceForm(_circuit).ShowDialog();
        }

        /// <summary>
        ///     Изменить номинал элемента.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    var result = new EditForm(element).ShowDialog();
                    if (result == DialogResult.Cancel)
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

        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь.
        /// </summary>
        private Circuit _circuit;

        #endregion

        #region Private fields

        /// <summary>
        ///     Выбранная нода.
        /// </summary>
        private INode _currentNode;
        
        #endregion

        #endregion
    }
}