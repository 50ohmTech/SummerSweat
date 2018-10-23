using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.Circuit;
using Model.Elements;
using System.Drawing;

namespace View
{
    public partial class MainForm : Form
    {
        #region Properties

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
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            _countElements = TestCircuits.capacitorIterator +
                             TestCircuits.inductorIterator +
                             TestCircuits.resistorIterator;
            
            if (_countElements < 8)
            {
                try
                {
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
                                new Resistor("R" + TestCircuits.resistorIterator++,
                                    Convert.ToDouble(NominalNumericUpDown.Text)));

                            _countElements++;
                            break;
                        case "L":
                            _circuit.AddAfter(_currentNode,
                                new Inductor("L" + TestCircuits.inductorIterator++,
                                    Convert.ToDouble(NominalNumericUpDown.Text)));

                           _countElements++;
                            break;
                        case "C":
                            _circuit.AddAfter(_currentNode,
                                new Capacitor("C" + TestCircuits.capacitorIterator++,
                                    Convert.ToDouble(NominalNumericUpDown.Text)));

                            _countElements++;
                            break;
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
                MessageBox.Show("Достигнуто максимальное количество элементов в цепи.");
            }
            
        }

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

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is CircuitTreeNode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

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
        }

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

        private INode _currentNode;

        private uint _countElements = 0;

        #endregion

        #endregion
    }
}