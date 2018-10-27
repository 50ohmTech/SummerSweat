using System;
using System.Windows.Forms;
using ElementsLibrary;
using ElementsLibrary.Circuits;
using ElementsLibrary.Elements;
using MainForm.Properties;

namespace MainForm
{
    /// <summary>
    ///     Класс под основную форму
    /// </summary>
    public partial class CircuitForm : Form
    {
        #region Readonly fields

        /// <summary>
        ///     Цепь
        /// </summary>
        public Circuit _circuit;

        #endregion

        #region Private fields

        /// <summary>
        ///     Текущй узел
        /// </summary>
        private INode _currentNode;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор формы
        /// </summary>
        public CircuitForm()
        {
            InitializeComponent();
            _circuit = new Circuit();
            _testCircuitsComboBox.Items.Add("Цепь №1");
            _testCircuitsComboBox.Items.Add("Цепь №2");
            _testCircuitsComboBox.Items.Add("Цепь №3");
            _testCircuitsComboBox.Items.Add("Цепь №4");
            _testCircuitsComboBox.Items.Add("Цепь №5");


            
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Функция для обновления информаици в TreeView
        /// </summary>
        private void UpdateTreeView()
        {
            void AddNodeTreeNodes(INode node, TreeNode treeNode)
            {
                if (node == null)
                {
                    return;
                }

                if (node is ElementBase)
                {
                    return;
                }

                foreach (var child in node.Nodes)
                {
                    var newTreeNode = new TreeViewNode(child);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(child, newTreeNode);
                }
            }

            _treeView.Nodes.Clear();
            var root = new TreeViewNode(_circuit.Root);
            _treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);
            _treeView.ExpandAll();
        }

        /// <summary>
        ///     Выбор цепи в Combobox
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TestCircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: всю генерацию цепей вынести в отдельный класс
            var selectedCircuit =
                _testCircuitsComboBox.Items.IndexOf(_testCircuitsComboBox.SelectedItem
                    .ToString());
            if (selectedCircuit == Fi)
            {
                _
            }

            if (selectedCircuit == "Цепь №2")
            {
                _circuitPictureBox.Image = Resources.Цепь_2;
            }

            if (selectedCircuit == "Цепь №3")
            {
                _circuitPictureBox.Image = Resources.Цепь_3;
            }

            if (selectedCircuit == "Цепь №4")
            {
                _circuitPictureBox.Image = Resources.Цепь_4;
            }

            if (selectedCircuit == "Цепь №5")
            {
                _circuitPictureBox.Image = Resources.Цепь_5;
            }

            TestCircuits.TestCircuitsGenerator(selectedCircuit, _circuit);

            UpdateTreeView();
        }

        /// <summary>
        ///     Кнопка для открытия калькулятора(другой формы)
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (_circuit.Root == null)
            {
                MessageBox.Show("Выберите цепь!", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            new ImpedanceCalculatorForm().ShowDialog();
        }

        /// <summary>
        ///     Событие для изменения значения элемента в TreeView
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_currentNode != null)
            {
                if (_currentNode is ElementBase element)
                {
                    var result = new EditValuesForm().ShowDialog();
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

        /// <summary>
        ///     Событие для изменения значения элемента в TreeView
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeViewNode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        #endregion
    }
}