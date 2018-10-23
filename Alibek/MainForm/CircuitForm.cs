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
        private readonly Circuit _circuit;

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

            testCircuitsComboBox.Items.Add("Цепь №1");
            testCircuitsComboBox.Items.Add("Цепь №2");
            testCircuitsComboBox.Items.Add("Цепь №3");
            testCircuitsComboBox.Items.Add("Цепь №4");
            testCircuitsComboBox.Items.Add("Цепь №5");


            _circuit = new Circuit();
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

            treeView.Nodes.Clear();
            var root = new TreeViewNode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);
            treeView.ExpandAll();
        }

        /// <summary>
        ///     Выбор цепи в Combobox
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TestCircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCircuit = testCircuitsComboBox.SelectedItem.ToString();
            if (selectedCircuit == "Цепь №1")
            {
                ElementBase resistor = new Resistor(13, "R1");
                ElementBase capacitor = new Capacitor("C1", 91);
                ElementBase inductor = new Inductor("L1", 32);

                SubcircuitBase parallelCircuit = new ParallelSubcircuit();

                parallelCircuit.Nodes.Add(resistor);
                parallelCircuit.Nodes.Add(capacitor);
                parallelCircuit.Nodes.Add(inductor);
                inductor.Parent = parallelCircuit;
                resistor.Parent = parallelCircuit;

                SubcircuitBase serialCircuit = new SerialSubcircuit();
                serialCircuit.Nodes.Add(parallelCircuit);
                serialCircuit.Nodes.Add(inductor);
                parallelCircuit.Parent = serialCircuit;
                inductor.Parent = serialCircuit;
                circuitPictureBox.Image = Resources.Цепь_1;
                _circuit.Clean();
                _circuit.AddAfter(null, parallelCircuit);
            }

            if (selectedCircuit == "Цепь №2")
            {
                var capacitor1 = new Capacitor("C1", 12);
                var inductor1 = new Inductor("L1", 21);
                var resistor1 = new Resistor(83, "R1");
                var inductor2 = new Inductor("L2", 73);

                var parallelCircuit1 = new ParallelSubcircuit();
                parallelCircuit1.Nodes.Add(inductor1);
                inductor1.Parent = parallelCircuit1;

                SubcircuitBase serialCircuit1 = new SerialSubcircuit();
                parallelCircuit1.Nodes.Add(serialCircuit1);
                serialCircuit1.Parent = parallelCircuit1;

                serialCircuit1.Nodes.Add(inductor2);
                inductor2.Parent = serialCircuit1;

                SubcircuitBase parallelCircuit2 = new ParallelSubcircuit();
                parallelCircuit2.Nodes.Add(resistor1);
                resistor1.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(capacitor1);
                capacitor1.Parent = parallelCircuit2;

                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                circuitPictureBox.Image = Resources.Цепь_2;
                _circuit.Clean();
                _circuit.AddAfter(null, parallelCircuit1);
            }

            if (selectedCircuit == "Цепь №3")
            {
                var resistor1 = new Resistor(43, "R1");
                var resistor2 = new Resistor(10, "R2");
                var resistor3 = new Resistor(15, "R3");
                var inductor1 = new Inductor("L3", 25);
                var capacitor1 = new Capacitor("C1", 15);
                var capacitor2 = new Capacitor("C2", 19);

                SubcircuitBase serialCircuit = new SerialSubcircuit();
                SubcircuitBase serialCircuit1 = new SerialSubcircuit();
                SubcircuitBase parallelCircuit1 = new ParallelSubcircuit();
                SubcircuitBase parallelCircuit2 = new ParallelSubcircuit();

                serialCircuit.Nodes.Add(capacitor1);
                capacitor1.Parent = serialCircuit;
                serialCircuit.Nodes.Add(resistor1);
                resistor1.Parent = serialCircuit;
                serialCircuit.Nodes.Add(inductor1);
                inductor1.Parent = serialCircuit;
                serialCircuit.Nodes.Add(parallelCircuit1);
                parallelCircuit1.Parent = serialCircuit;
                parallelCircuit1.Nodes.Add(resistor2);
                resistor2.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(capacitor2);
                capacitor2.Parent = parallelCircuit1;
                serialCircuit.Nodes.Add(serialCircuit1);
                serialCircuit1.Parent = serialCircuit;
                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                parallelCircuit2.Nodes.Add(inductor1);
                inductor1.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(resistor3);
                resistor3.Parent = parallelCircuit2;

                circuitPictureBox.Image = Resources.Цепь_3;
                _circuit.Clean();
                _circuit.AddAfter(null, serialCircuit);
            }

            if (selectedCircuit == "Цепь №4")
            {
                ElementBase resistor1 = new Resistor(13, "R1");
                ElementBase resistor2 = new Resistor(14, "R2");
                ElementBase resistor3 = new Resistor(6, "R3");
                ElementBase resistor4 = new Resistor(9, "R4");
                ElementBase capacitor1 = new Capacitor("C1", 12);
                ElementBase inductor1 = new Inductor("L1", 30);
                ElementBase inductor2 = new Inductor("L2", 10);

                SubcircuitBase serialCircuit1 = new SerialSubcircuit();
                SubcircuitBase parallelCircuit1 = new ParallelSubcircuit();
                SubcircuitBase parallelCircuit2 = new ParallelSubcircuit();

                serialCircuit1.Nodes.Add(inductor1);
                inductor1.Parent = serialCircuit1;
                serialCircuit1.Nodes.Add(resistor1);
                resistor1.Parent = serialCircuit1;
                serialCircuit1.Nodes.Add(parallelCircuit1);
                parallelCircuit1.Parent = serialCircuit1;
                parallelCircuit1.Nodes.Add(resistor2);
                resistor2.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(inductor2);
                inductor2.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(capacitor1);
                capacitor1.Parent = parallelCircuit1;
                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                parallelCircuit2.Nodes.Add(resistor3);
                resistor3.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(resistor4);
                resistor4.Parent = parallelCircuit2;
                circuitPictureBox.Image = Resources.Цепь_4;
                _circuit.Clean();
                _circuit.AddAfter(null, serialCircuit1);
            }

            if (selectedCircuit == "Цепь №5")
            {
                ElementBase resistor = new Resistor(10, "R1");
                ElementBase resistor1 = new Resistor(10, "R1");
                ElementBase resistor2 = new Resistor(10, "R1");
                ElementBase capacitor = new Capacitor("C1", 12);
                ElementBase inductor = new Inductor("L1", 30);
                ElementBase inductor2 = new Inductor("L1", 23);

                SubcircuitBase serialCircuit1 = new SerialSubcircuit();
                SubcircuitBase serialCircuit2 = new SerialSubcircuit();
                SubcircuitBase parallelCircuit1 = new ParallelSubcircuit();
                SubcircuitBase parallelCircuit2 = new ParallelSubcircuit();
                SubcircuitBase parallelCircuit3 = new ParallelSubcircuit();

                serialCircuit1.Nodes.Add(parallelCircuit1);
                parallelCircuit1.Parent = serialCircuit1;
                parallelCircuit1.Nodes.Add(resistor1);
                resistor1.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(inductor);
                inductor.Parent = parallelCircuit1;

                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                parallelCircuit2.Nodes.Add(capacitor);
                capacitor.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(serialCircuit2);
                serialCircuit2.Parent = parallelCircuit2;
                serialCircuit2.Nodes.Add(parallelCircuit3);
                parallelCircuit3.Parent = serialCircuit2;
                serialCircuit2.Nodes.Add(resistor2);
                resistor.Parent = serialCircuit2;
                parallelCircuit3.Nodes.Add(resistor);
                resistor.Parent = parallelCircuit3;
                parallelCircuit3.Nodes.Add(inductor);
                inductor.Parent = parallelCircuit3;
                parallelCircuit2.Nodes.Add(inductor2);
                inductor2.Parent = parallelCircuit2;
                serialCircuit1.Nodes.Add(resistor);
                resistor.Parent = serialCircuit1;
                circuitPictureBox.Image = Resources.Цепь_5;
                _circuit.Clean();
                _circuit.AddAfter(null, serialCircuit1);
            }

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

            new ImpedanceCalculator(_circuit).ShowDialog();
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
                    var result = new EditValuesForm(element).ShowDialog();
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