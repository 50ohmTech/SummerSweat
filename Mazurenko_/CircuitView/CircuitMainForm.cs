using System;
using System.Windows.Forms;
using CircuitLibrary;
using CircuitLibrary.Subcircuit;

namespace CircuitView
{
    /// <summary>
    ///     MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        #region Private fields

        /// <summary>
        ///     Current electrical circuit
        /// </summary>
        private Circuit _circuit;

        /// <summary>
        ///     List of all electrical circuits
        /// </summary>
        private CircuitsCreate _circuits;

        /// <summary>
        ///     Current node
        /// </summary>
        private INode _currentNode;

        /// <summary>
        ///     Element value
        /// </summary>
        private double _valueElement;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Update the TreeView
        /// </summary>
        private void UpdateTreeView()
        {
            _currentNode = null;
            CircuitPictureBox.Image = null;
            TreeView.Nodes.Clear();
            if (_circuit == null)
            {
                throw new ArgumentException("Circuit is null");
            }

            if (_circuit.IsEmpty())
            {
                return;
            }

            var root = new TreeINode(_circuit.Root);
            TreeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            TreeView.ExpandAll();
            CircuitPictureBox.Image = Drawer.DrawCircuit(_circuit.Root);
        }

        /// <summary>
        ///     Adding a node to the tree
        /// </summary>
        /// <param name="node">Append of node</param>
        /// <param name="treeNode">Tree node</param>
        private void AddNodeTreeNodes(INode node, TreeNode treeNode)
        {
            if (node is ElementBase || node == null)
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

        /// <summary>
        ///     Occurs when the selection of a desired electrical circuit
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            _circuit = _circuits.Circuits[CircuitsComboBox.SelectedIndex];
            UpdateTreeView();
        }

        /// <summary>
        ///     Initial setting CircuitMainForm
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _circuit = new Circuit();
            _circuits = new CircuitsCreate();
            CircuitsComboBox.SelectedIndex = 1;
            NodeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        ///     Delete a node
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == null)
            {
                MessageBox.Show(@"Select the item you want to delete", @"Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                _circuit.Remove(_currentNode);
                if (_circuit.IsEmpty())
                {
                    _circuit.NodeCreate.ResetCounter();
                    _circuit.AddAfter(_currentNode,
                        _circuit.NodeCreate.GetElementNode(NodeType.Serial, 0));
                }

                UpdateTreeView();
            }
        }

        /// <summary>
        ///     Event that occurs when you change the selection of tree elements
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeINode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        /// <summary>
        ///     Adding a node to the tree
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == null && !_circuit.IsEmpty())
            {
                MessageBox.Show("No node is selected for which you want to add a node",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            Enum.TryParse(NodeComboBox.SelectedItem.ToString(),
                out NodeType selectedItem);

            if (!(_currentNode is SerialSubcircuit) &&
                !(_currentNode is ParallelSubcircuit) && !_circuit.IsEmpty())
            {
                MessageBox.Show("Element cannot be added to the circuit element",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (selectedItem == NodeType.Serial || selectedItem == NodeType.Parallel)
            {
                _circuit.AddAfter(_currentNode,
                    _circuit.NodeCreate.GetElementNode(selectedItem, 0));
            }
            else
            {
                _circuit.AddAfter(_currentNode,
                    _circuit.NodeCreate.GetElementNode(selectedItem, _valueElement));
            }


            UpdateTreeView();
        }

        /// <summary>
        ///     Event when you press a key in the 'Value' field
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueTextBoxTools.DoubleKeyPress(e, sender);
        }

        /// <summary>
        ///     Event triggered when the field is changed 'Value'
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            AddButton.Enabled =
                ValueTextBoxTools.TextChanged(sender);
        }

        /// <summary>
        ///     Event when leaving the 'Value' field
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_Leave(object sender, EventArgs e)
        {
            var resultValue = ValueTextBoxTools.Leave(sender);
            AddButton.Enabled = resultValue;

            if (!string.IsNullOrWhiteSpace(ValueTextBox.Text))
            {
                _valueElement = Convert.ToDouble(ValueTextBox.Text);
            }
        }

        /// <summary>
        ///     Changing the value of an element
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void EditValue(object sender, EventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    var editForm = new EditElementForm();
                    editForm.SetElement = element;
                    var dialogResult = editForm.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        UpdateTreeView();
                    }
                }
            }
            else
            {
                MessageBox.Show("Select the item whose \nvalue you want to change",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        ///     Calling the form to calculate the impedance of an electrical circuit
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            if (_circuit.IsEmpty())
            {
                MessageBox.Show(@"The electrical circuit is empty", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var calculationForm = new CalculationForm();
            calculationForm.SetCircuit = _circuit;
            calculationForm.ShowDialog();
        }

        /// <summary>
        ///     The event occurs when the selection in the "NodeComboBox"
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void NodeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NodeComboBox.SelectedIndex == 0 || NodeComboBox.SelectedIndex == 1)
            {
                AddButton.Enabled = true;
                ValueTextBox.Enabled = false;
            }
            else
            {
                AddButton.Enabled = !ValueTextBoxTools.IsTextEmpty(ValueTextBox.Text);
                ValueTextBox.Enabled = true;
            }
        }

        #endregion
    }
}