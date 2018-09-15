using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;
using Model.Elements.Enums;
using Model.Elements.Factories;
using Model.TreeView;
using Model.ViewHelpers;
using Model.ViewHelpers.Enums;

namespace View
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        ///     Рисовальщик цепи.
        /// </summary>
        private readonly Drawer _drawer;

        #endregion

        #region Private fields

        private NodeTreeNode _currentNodeTreeNode;

        /// <summary>
        ///     Номинал нового элемента
        /// </summary>
        private double _value;

        #endregion

        #endregion

        #region Private methods

        /// <summary>
        ///     Инициализировать ComboBox'ы
        /// </summary>
        private void InitializeComboBoxesType()
        {
            List<ElementTypeComboBoxItem> elementTypes = new List<ElementTypeComboBoxItem>
            {
                new ElementTypeComboBoxItem(ElementType.Resistor),
                new ElementTypeComboBoxItem(ElementType.Inductor),
                new ElementTypeComboBoxItem(ElementType.Capacitor)
            };

            _comboBoxAddElementType.DataSource = elementTypes;
            _comboBoxAddElementType.ValueMember = "Value";
            _comboBoxAddElementType.DisplayMember = "Description";

            List<InitialCircuitTypeComboBoxItem> initialCircuitTypes = new List<InitialCircuitTypeComboBoxItem>
            {
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.A),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.B),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.C),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.D),
                new InitialCircuitTypeComboBoxItem(InitialCircuitType.E)
            };

            _comboBoxSelectCircuit.DataSource = initialCircuitTypes;
            _comboBoxSelectCircuit.ValueMember = "Value";
            _comboBoxSelectCircuit.DisplayMember = "Description";

            List<ConnectionTypeComboBoxItem> connectionTypes = new List<ConnectionTypeComboBoxItem>
            {
                new ConnectionTypeComboBoxItem(ConnectionType.Serial),
                new ConnectionTypeComboBoxItem(ConnectionType.Parallel)
            };

            _comboBoxAddElementConnectionType.DataSource = connectionTypes;
            _comboBoxAddElementConnectionType.ValueMember = "Value";
            _comboBoxAddElementConnectionType.DisplayMember = "Description";
        }

        /// <summary>
        ///     Инициализировать подсказки
        /// </summary>
        private void InitializePlaceholders()
        {
            _textBoxAddElementName.GotFocus += (sender, e) =>
            {
                ((TextBox) sender).Text = string.Empty;
                ((TextBox) sender).ForeColor = Color.Black;
            };

            _textBoxAddElementName.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(((TextBox) sender).Text))
                {
                    ((TextBox) sender).Text = "Имя..";
                    ((TextBox) sender).ForeColor = Color.Gray;
                }
            };

            _textBoxAddElementValue.GotFocus += (sender, e) =>
            {
                ((TextBox) sender).Text = string.Empty;
                ((TextBox) sender).ForeColor = Color.Black;
            };

            _textBoxAddElementValue.LostFocus += (sender, e) =>
            {
                if (!double.TryParse(((TextBox) sender).Text, out _value))
                {
                    ((TextBox) sender).Text = "Номинал..";
                    ((TextBox) sender).ForeColor = Color.Gray;
                }
            };
        }

        /// <summary>
        ///     Очистить TreeViewCircuit
        /// </summary>
        private void ClearTreeViewCircuit()
        {
            _treeViewCircuit.Nodes.Clear();
            _currentNodeTreeNode = null;
        }

        /// <summary>
        ///     Обновить дерево
        /// </summary>
        private void UpdateTreeView()
        {
            ClearTreeViewCircuit();
            if (_circuit == null || _circuit.IsEmpty())
            {
                return;
            }

            _treeViewCircuit.BeginUpdate();

            void AddNodeTreeNodes(INode node, TreeNode treeNode)
            {
                if (node is ElementBase)
                {
                    return;
                }

                foreach (INode children in node.Nodes)
                {
                    NodeTreeNode newTreeNode = new NodeTreeNode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            if (_circuit == null)
            {
                throw new InvalidOperationException("Цепь была null");
            }

            _treeViewCircuit.Nodes.Clear();

            NodeTreeNode root = new NodeTreeNode(_circuit.Root);
            _treeViewCircuit.Nodes.Add(root);
            root.Text = "Корень";
            AddNodeTreeNodes(_circuit.Root, root);

            _treeViewCircuit.EndUpdate();
            _treeViewCircuit.ExpandAll();
        }

        private void ButtonClearCircuit_Click(object sender, EventArgs e)
        {
            _circuit.Clear();
            UpdateViewCircuit();
        }

        private void ComboBoxSelectCircuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_comboBoxSelectCircuit.SelectedItem is InitialCircuitTypeComboBoxItem initialCircuitType)
            {
                InitialCircuitInitializer.Initialize(_circuit, initialCircuitType.Value);
                UpdateViewCircuit();
            }
        }

        private void ButtonAddElement_Click(object sender, EventArgs e)
        {
            if (GetCurrentElementBase() == null && !_circuit.IsEmpty())
            {
                MessageBox.Show("Выберите элемент перед которым ходите добавить новый элемент.");
            }
            else
            {
                ElementTypeComboBoxItem elementTypeComboBoxItem =
                    _comboBoxAddElementType.SelectedItem as ElementTypeComboBoxItem;

                ConnectionTypeComboBoxItem connectionTypeComboBoxItem =
                    _comboBoxAddElementConnectionType.SelectedItem as ConnectionTypeComboBoxItem;

                if (elementTypeComboBoxItem != null && connectionTypeComboBoxItem != null)
                {
                    _circuit.AddAfter(GetCurrentElementBase(),
                        ElementFactory.GetInstance(elementTypeComboBoxItem.Value, _textBoxAddElementName.Text,
                            _value), connectionTypeComboBoxItem.Value);

                    UpdateViewCircuit();
                }
            }
        }

        private void TextBoxAddElementValue_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_textBoxAddElementName.Text))
            {
                _buttonAddElement.Enabled = false;
                return;
            }

            if (!double.TryParse(_textBoxAddElementValue.Text, out _value))
            {
                _buttonAddElement.Enabled = false;
                return;
            }

            _buttonAddElement.Enabled = true;
        }

        private void TreeViewCircuit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is NodeTreeNode treeNode)
            {
                _currentNodeTreeNode = treeNode;
            }
        }

        private void ButtonOpenEditForm_Click(object sender, EventArgs e)
        {
            if (GetCurrentElementBase() != null)
            {
                DialogResult result = new EditForm(GetCurrentElementBase()).ShowDialog();
                if (result == DialogResult.OK)
                {
                    UpdateViewCircuit();
                }
            }
            else
            {
                MessageBox.Show("Выберите элемент, который хотите изменить.");
            }
        }

        /// <summary>
        ///     Обновить дерево и картинку цепи.
        /// </summary>
        private void UpdateViewCircuit()
        {
            UpdateTreeView();
            DrawCircuit();
        }

        private void ButtonCalculateFormShow_Click(object sender, EventArgs e)
        {
            new ImpedanceForm(_circuit).ShowDialog();
        }

        private void ButtonRemoveElement_Click(object sender, EventArgs e)
        {
            if (GetCurrentElementBase() != null)
            {
                try
                {
                    _circuit.TryRemove(GetCurrentElementBase());
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

                UpdateViewCircuit();
            }
            else
            {
                MessageBox.Show("Выберите элемент, который хотите удалить.");
            }
        }

        /// <summary>
        ///     Получить текущий элемент из TreeView
        /// </summary>
        /// <returns></returns>
        private ElementBase GetCurrentElementBase()
        {
            if (_currentNodeTreeNode?.Value is ElementBase element)
            {
                return element;
            }

            return null;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeComboBoxesType();
            InitializePlaceholders();
            _circuit = new Circuit();
            _drawer = new Drawer(_pictureBoxCircuit, _circuit);
            _buttonAddElement.Enabled = false;
        }

        /// <summary>
        ///     Нарисовать цепь.
        /// </summary>
        public void DrawCircuit()
        {
            _pictureBoxCircuit.Image = null;
            if (_circuit == null || _circuit.IsEmpty())
            {
                return;
            }

            _drawer.DrawCircuit();
        }

        #endregion
    }
}