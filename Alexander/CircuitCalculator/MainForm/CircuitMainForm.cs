using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Elements;
using Model.Circuit;
using Model.Enums;

namespace MainForm
{
    public partial class MainForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        /// Цепь
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        private INode _currentNode;

        /// <summary>
        ///  
        /// </summary>
        private uint _resistorIterator;

        /// <summary>
        ///  
        /// </summary>   
        private uint _capacitorIterator;

        /// <summary>
        ///  
        /// </summary>
        private uint _inductorIterator;

        #endregion

        #endregion

        #region Private methods
        
        /// <summary>
        /// Очистить TreeView
        /// </summary>
        private void ClearTreeView()
        {
            treeView.Nodes.Clear();
            _currentNode = null;
        }

        /// <summary>
        /// Обновить дерево
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
                
                foreach (INode children in node.Nodes)
                {
                    CircuitTreeNode newTreeNode = new CircuitTreeNode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь была null");
            }

            treeView.Nodes.Clear();

            CircuitTreeNode root = new CircuitTreeNode(_circuit.Root);
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
                        _circuit.AddAfter(_currentNode, new Resistor("R" + _resistorIterator++, Convert.ToDouble(NominalTextBox.Text)));
                        break;
                    case "L":
                        _circuit.AddAfter(_currentNode, new Inductor("L" + _inductorIterator++, Convert.ToDouble(NominalTextBox.Text)));
                        break;
                    case "C":
                        _circuit.AddAfter(_currentNode, new Capacitor("C" + _capacitorIterator++, Convert.ToDouble(NominalTextBox.Text)));
                        break;
                }
                                
                UpdateTreeView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Конструктор
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

        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectingCircuitComboBox.Text == "Новая цепь")
            {
                
            }
        }
    }
}
