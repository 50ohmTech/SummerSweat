using System;
using System.ComponentModel;
using System.Windows.Forms;
using CircuitLibraby;
using CircuitLibrary;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;
using MainForm;

namespace CircuitView
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Цепь
        /// </summary>
        private Circuit _circuit;

        /// <summary>
        ///     Текущий узел
        /// </summary>
        private INode _currentNode;

        /// <summary>
        ///     true = элемент, false = не элемент
        /// </summary>
        private bool _isElement;

        #endregion

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            _circuit = new Circuit();
            _isElement = true;
            SelectingCircuitComboBox.Items.Add("Цепь №1");
            SelectingCircuitComboBox.Items.Add("Цепь №2");
            SelectingCircuitComboBox.Items.Add("Цепь №3");
            SelectingCircuitComboBox.Items.Add("Цепь №4");
            SelectingCircuitComboBox.Items.Add("Цепь №5");
            SelectingCircuitComboBox.SelectedIndex = 0;
            NodeComboBox.DataSource = Enum.GetValues(typeof(NodeType));
            NodeComboBox.SelectedItem = NodeType.Serial;
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Обновить дерево
        /// </summary>
        private void UpdateTreeView(bool isElement)
        {
            TreeView.Nodes.Clear();
            _currentNode = null;
            if (_circuit == null || _circuit.IsEmpty())
            {
                return;
            }

            TreeView.BeginUpdate();

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

            TreeView.Nodes.Clear();

            var root = new TreeINode(_circuit.Root);
            TreeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            TreeView.EndUpdate();
            TreeView.ExpandAll();
            if (isElement)
            {
                circuitPictureBox.Image = null;
                circuitPictureBox.Image = Drawer.DrawCircuit(_circuit);
            }
        }


        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            NodesFactory.IteratorsToZero();
            SubcircuitBase parallelSubcircuit = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit = new SerialSubcircuit();
            _circuit.Clear();
            UpdateTreeView(_isElement);
            _circuit = NodesFactory.GetCircuit(SelectingCircuitComboBox.SelectedIndex);

            UpdateTreeView(_isElement);
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeINode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NodeType nodeType;
            Enum.TryParse(NodeComboBox.SelectedValue.ToString(), out nodeType);
            if (_currentNode == null && _circuit.Root != null)
            {
                MessageBox.Show("Выберите узел, к которому хотите добавить!");
                return;
            }

            try
            {
                if (nodeType == NodeType.Parallel || nodeType == NodeType.Serial)
                {
                    _circuit.AddAfter(_currentNode,
                        NodesFactory.GetNode(nodeType, 0));

                    _isElement = false;
                }
                else
                {
                    _circuit.AddAfter(_currentNode,
                        NodesFactory.GetNode(nodeType,
                            Convert.ToDouble(ValueTextBox.Text)));
                }

                UpdateTreeView(_isElement);
                _isElement = true;
            }
            catch (Exception exception)
            {
                switch (nodeType)
                {
                    case NodeType.Resistor:
                        NodesFactory._resistorIterator--;

                        break;
                    case NodeType.Inductor:
                        NodesFactory._inductorIterator--;

                        break;
                    case NodeType.Capacitor:
                        NodesFactory._capacitorIterator--;

                        break;
                }

                MessageBox.Show(exception.Message);
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
                    if (_currentNode == _circuit.Root)
                    {
                        NodesFactory.IteratorsToZero();
                    }

                    _circuit.Remove(_currentNode);
                    UpdateTreeView(_isElement);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void ValueTextBox_Validating(object sender, CancelEventArgs e)
        {
            FormTools.TextBoxCheck(ValueTextBox, e);
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NodeComboBox.SelectedIndex > 1)
            {
                AddButton.Enabled = ValueTextBox.Text.Length != 0;
            }
        }

        private void NodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NodeComboBox.SelectedIndex > 1)
            {
                AddButton.Enabled = ValueTextBox.Text.Length != 0;
            }
        }

        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            var impedanceForm = new ImpedanceForm();
            impedanceForm.Circuit = _circuit;
            impedanceForm.ShowDialog();
        }

        private void TreeView_DoubleClick(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    var result = new EditForm(element).ShowDialog();
                    if (result == DialogResult.Cancel)
                    {
                        UpdateTreeView(_isElement);
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