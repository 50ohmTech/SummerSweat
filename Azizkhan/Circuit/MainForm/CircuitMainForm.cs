using System;
using System.Windows.Forms;
using CircuitLibraby;
using CircuitLibrary;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;

namespace CircuitView
{
    public partial class MainForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        private uint _capacitorIterator;

        private INode _currentNode;

        private uint _inductorIterator;

        private uint _resistorIterator;

        #endregion

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            _circuit = new Circuit();
            SelectingCircuitComboBox.Items.Add("Цепь №1");
            SelectingCircuitComboBox.Items.Add("Цепь №2");
            SelectingCircuitComboBox.Items.Add("Цепь №3");
            SelectingCircuitComboBox.Items.Add("Цепь №4");
            SelectingCircuitComboBox.Items.Add("Цепь №5");
            NodeComboBox.DataSource = Enum.GetValues(typeof(NodeType));
            NodeComboBox.SelectedItem = NodeType.Serial;
            _resistorIterator = 0;
            _capacitorIterator = 0;
            _inductorIterator = 0;


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
            if (_circuit == null || _circuit.IsEmpty())
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
                    var newTreeNode = new TreeINode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь была null");
            }

            treeView.Nodes.Clear();

            var root = new TreeINode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            treeView.EndUpdate();
            treeView.ExpandAll();
        }


        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            SubcircuitBase parallelSubcircuit = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit = new SerialSubcircuit();

            _resistorIterator = 0;
            _capacitorIterator = 0;
            _inductorIterator = 0;
            _circuit.Clear();
            UpdateTreeView();

            if (SelectingCircuitComboBox.SelectedIndex == 1)
            {
                _circuit.AddAfter(_currentNode, seriesSubcircuit);
                _circuit.AddAfter(seriesSubcircuit,
                    new Resistor("R" + _resistorIterator++, 1));

                _circuit.AddAfter(seriesSubcircuit,
                    new Resistor("R" + _resistorIterator++, 5.5));

                _circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
                _circuit.AddAfter(parallelSubcircuit,
                    new Resistor("R" + _resistorIterator++, 6.2));
            }

            if (SelectingCircuitComboBox.SelectedIndex == 2)
            {
                _circuit.AddAfter(_currentNode, seriesSubcircuit);
                _circuit.AddAfter(seriesSubcircuit,
                    new Capacitor("C" + _capacitorIterator++, 55.1));

                _circuit.AddAfter(seriesSubcircuit,
                    new Resistor("R" + _resistorIterator++, 34.5));

                _circuit.AddAfter(seriesSubcircuit,
                    new Inductor("L" + _inductorIterator++, 6.2));
            }

            if (SelectingCircuitComboBox.SelectedIndex == 3)
            {
                _circuit.AddAfter(_currentNode, seriesSubcircuit);
                _circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
                _circuit.AddAfter(parallelSubcircuit,
                    new Resistor("R" + _resistorIterator++, 56));

                _circuit.AddAfter(parallelSubcircuit,
                    new Capacitor("C" + _capacitorIterator++, 59.1));

                _circuit.AddAfter(parallelSubcircuit,
                    new Resistor("R" + _resistorIterator++, 33.3));
            }

            if (SelectingCircuitComboBox.SelectedIndex == 4)
            {
                _circuit.AddAfter(_currentNode, seriesSubcircuit);
                _circuit.AddAfter(seriesSubcircuit,
                    new Resistor("R" + _resistorIterator++, 22));

                _circuit.AddAfter(seriesSubcircuit,
                    new Capacitor("C" + _capacitorIterator++, 59.1));

                _circuit.AddAfter(seriesSubcircuit,
                    new Capacitor("C" + _capacitorIterator++, 33.3));

                _circuit.AddAfter(seriesSubcircuit,
                    new Resistor("R" + _resistorIterator++, 11.34));
            }

            if (SelectingCircuitComboBox.SelectedIndex == 5)
            {
                _circuit.AddAfter(_currentNode, seriesSubcircuit);
                _circuit.AddAfter(seriesSubcircuit,
                    new Resistor("R" + _resistorIterator++, 22));

                _circuit.AddAfter(seriesSubcircuit,
                    new Capacitor("C" + _capacitorIterator++, 59.1));

                _circuit.AddAfter(seriesSubcircuit,
                    new Capacitor("C" + _capacitorIterator++, 33.3));

                _circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
                _circuit.AddAfter(parallelSubcircuit,
                    new Resistor("R" + _resistorIterator++, 99.2));
            }

            UpdateTreeView();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeINode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (NodeComboBox.SelectedItem.ToString() == "Resistor")
            {
                _circuit.AddAfter(_currentNode, new Resistor("R" + _resistorIterator++,
                    Convert.ToDouble(ValueTextBox.Text)));
            }

            if (NodeComboBox.SelectedItem.ToString() == "Capacitor")
            {
                _circuit.AddAfter(_currentNode, new Capacitor("C" + _capacitorIterator++,
                    Convert.ToDouble(ValueTextBox.Text)));
            }

            if (NodeComboBox.SelectedItem.ToString() == "Inductor")
            {
                _circuit.AddAfter(_currentNode, new Inductor("L" + _inductorIterator++,
                    Convert.ToDouble(ValueTextBox.Text)));
            }

            if (NodeComboBox.SelectedItem.ToString() == "Parallel")
            {
                _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
            }

            if (NodeComboBox.SelectedItem.ToString() == "Serial")
            {
                _circuit.AddAfter(_currentNode, new SerialSubcircuit());
            }

            UpdateTreeView();
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
                    if (_currentNode.GetType() == typeof(Resistor))
                    {
                        _resistorIterator--;
                    }

                    if (_currentNode.GetType() == typeof(Capacitor))
                    {
                        _capacitorIterator--;
                    }

                    if (_currentNode.GetType() == typeof(Inductor))
                    {
                        _inductorIterator--;
                    }

                    _circuit.Remove(_currentNode);
                    UpdateTreeView();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        #endregion
    }
}