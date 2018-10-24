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
        private CircuitsCreator _circuits;

        /// <summary>
        ///     Current node
        /// </summary>
        private INode _currentNode;

        /// <summary>
        ///     Element value
        /// </summary>
        private double _valueElement;

        /// <summary>
        /// Maximum elements count
        /// </summary>
        private uint _maxCount = 15;
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
            AddTreeNode(_circuit.Root, root);

            TreeView.ExpandAll();           
            CircuitPictureBox.Image = Drawer.DrawCircuit(_circuit.Root);   
        }

        /// <summary>
        ///     Adding a node to the tree
        /// </summary>
        /// <param name="node">Append of node</param>
        /// <param name="treeNode">Tree node</param>
        private void AddTreeNode(INode node, TreeNode treeNode)
        {
            if (node is ElementBase || node == null)
            {
                return;
            }

            foreach (var children in node.Nodes)
            {
                var newTreeNode = new TreeINode(children);
                treeNode.Nodes.Add(newTreeNode);
                AddTreeNode(children, newTreeNode);
            }
        }

        /// <summary>
        /// Counting the number of elements in the circuit
        /// </summary>
        /// <param name="root">Root</param>
        /// <param name="count">Elements counter</param>
        /// <returns>Number of elements</returns>
        private uint GetCount(INode root,uint count)
        {
            if (root != null)
            {
                foreach (var node in root.Nodes)
                {
                    if (node is ElementBase)
                    {
                        count++;
                    }
                    if (node is SubcircuitBase)
                    {
                        count = GetCount(node, count);
                    }
                }

            }
            
            return count;
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
            _circuits = new CircuitsCreator();
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
        ///     Triggered when the change the selection of tree elements
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
        /// Count elements validation
        /// </summary>
        /// <param name="root">Root of circuit</param>
        /// <returns></returns>
        private bool ValidationCountElements(INode root)
        {
            uint countElements = 0;
            countElements = GetCount(_circuit.Root, countElements);
            if (countElements >= _maxCount)
            {
                MessageBox.Show(
                    "Maximum number of elements cirucit must not exceed " + _maxCount);

                return true;
            }

            return false;
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

            if (ValidationCountElements(_circuit.Root)) 
            {
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
        ///     Triggered when the press a key in the "Value" field
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueTextBoxTools.DoubleKeyPress(e, sender);
        }

        /// <summary>
        ///     Triggered when the “Value” field changed
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            AddButton.Enabled =
                ValueTextBoxTools.TextChanged(sender);
        }

        /// <summary>
        ///     Triggering by leaving the 'Value' field
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_Leave(object sender, EventArgs e)
        {
            var resultValue = ValueTextBoxTools.TextBoxLeave(sender);
            AddButton.Enabled = resultValue;

            if (!string.IsNullOrWhiteSpace(ValueTextBox.Text))
            {
                _valueElement = Convert.ToDouble(ValueTextBox.Text);
            }
        }

        /// <summary>
        ///     Opening "EditElementForm" to change the value of the selected item
        /// </summary>
        private void OpenEditElementForm()
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
        ///     "Edit" button click
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            OpenEditElementForm();
        }

        /// <summary>
        ///     Double click "TreeView"
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void TreeView_DoubleClick(object sender, EventArgs e)
        {
            OpenEditElementForm();
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