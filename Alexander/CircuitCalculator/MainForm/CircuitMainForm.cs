using System;
using System.Windows.Forms;
using Model.Circuit;
using Model.Elements;

namespace View
{
    public partial class MainForm : Form
    {
        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _circuit = new Circuit();
            _resistorIterator = 0;
            _inductorIterator = 0;
            _capacitorIterator = 0;
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Очистить TreeView.
        /// </summary>
        private void ClearTreeView()
        {
            treeView.Nodes.Clear();
            _currentNode = null;
        }

        /// <summary>
        ///     Обновить дерево.
        /// </summary>
        private void UpdateTreeView()
        {
            ClearTreeView();
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
                    var newTreeNode = new CircuitTreeNode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь была null");
            }

            treeView.Nodes.Clear();

            var root = new CircuitTreeNode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            treeView.EndUpdate();
            treeView.ExpandAll();
        }

        private void AddButton_Click(object sender, EventArgs e)
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
                            new Resistor("R" + _resistorIterator++,
                                Convert.ToDouble(NominalNumericUpDown.Text)));

                        break;
                    case "L":
                        _circuit.AddAfter(_currentNode,
                            new Inductor("L" + _inductorIterator++,
                                Convert.ToDouble(NominalNumericUpDown.Text)));

                        break;
                    case "C":
                        _circuit.AddAfter(_currentNode,
                            new Capacitor("C" + _capacitorIterator++,
                                Convert.ToDouble(NominalNumericUpDown.Text)));

                        break;
                }

                UpdateTreeView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            SubcircuitBase parallelSubcircuit = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit = new SeriesSubcircuit();

            _resistorIterator = 0;
            _capacitorIterator = 0;
            _inductorIterator = 0;
            _circuit.Clear();
            UpdateTreeView();

            switch (SelectingCircuitComboBox.SelectedItem)
            {
                case "Цепь №1":
                    _circuit.AddAfter(_currentNode, seriesSubcircuit);
                    _circuit.AddAfter(seriesSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 2.2));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Resistor("R" + _resistorIterator++, 15));

                    _circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
                    _circuit.AddAfter(parallelSubcircuit,
                        new Inductor("L" + _inductorIterator++, 20));

                    break;
                case "Цепь №2":
                    _circuit.AddAfter(_currentNode, parallelSubcircuit);
                    _circuit.AddAfter(parallelSubcircuit,
                        new Resistor("R" + _resistorIterator++, 22.1));

                    _circuit.AddAfter(parallelSubcircuit,
                        new Inductor("L" + _inductorIterator++, 1.1));

                    _circuit.AddAfter(parallelSubcircuit,
                        new Inductor("L" + _inductorIterator++, 6));

                    _circuit.AddAfter(parallelSubcircuit, seriesSubcircuit);
                    _circuit.AddAfter(seriesSubcircuit,
                        new Resistor("R" + _resistorIterator++, 9.9));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Inductor("L" + _inductorIterator++, 5.12));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 11));

                    break;
                case "Цепь №3":
                    _circuit.AddAfter(_currentNode, parallelSubcircuit);
                    _circuit.AddAfter(parallelSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 8.8));

                    _circuit.AddAfter(parallelSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 7.7));

                    _circuit.AddAfter(parallelSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 6.66));

                    break;
                case "Цепь №4":
                    _circuit.AddAfter(_currentNode, seriesSubcircuit);
                    _circuit.AddAfter(seriesSubcircuit,
                        new Inductor("L" + _inductorIterator++, 5));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Resistor("R" + _resistorIterator++, 27.9));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 40));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Resistor("R" + _resistorIterator++, 14));

                    break;
                case "Цепь №5":
                    _circuit.AddAfter(_currentNode, parallelSubcircuit);
                    _circuit.AddAfter(parallelSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 44));

                    _circuit.AddAfter(parallelSubcircuit, seriesSubcircuit);
                    _circuit.AddAfter(seriesSubcircuit,
                        new Resistor("R" + _resistorIterator++, 99.2));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 88.8));

                    _circuit.AddAfter(seriesSubcircuit,
                        new Resistor("R" + _resistorIterator++, 2));

                    break;
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
                    if (_currentNode.GetType() == typeof(Resistor))
                    {
                        _resistorIterator--;
                    }

                    if (_currentNode.GetType() == typeof(Inductor))
                    {
                        _inductorIterator--;
                    }

                    if (_currentNode.GetType() == typeof(Capacitor))
                    {
                        _capacitorIterator--;
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
            new ImpedanceForm(_circuit).ShowDialog();
        }

        #endregion

        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        private INode _currentNode;

        /// <summary>
        ///     Индекс резистора.
        /// </summary>
        private uint _resistorIterator;

        /// <summary>
        ///     Индекс конденсатора.
        /// </summary>
        private uint _capacitorIterator;

        /// <summary>
        ///     Индекс индуктора.
        /// </summary>
        private uint _inductorIterator;

        #endregion

        #endregion

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
    }
}