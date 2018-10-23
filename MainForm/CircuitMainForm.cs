using System;
using System.Windows.Forms;
using MainForm.Properties;
using CircuitModel;

/// <summary>
/// Главная форма.
/// </summary>
namespace MainForm
{
    public partial class MainForm : Form
    {
        #region ~ Переменные только для чтения ~

        /// <summary>
        /// Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region ~ Приватные переменные ~

        /// <summary>
        /// Текущий узел.
        /// </summary>
        private INode _currentNode;

        #endregion

        #region ~ Конструктор ~

        public MainForm()
        {
            InitializeComponent();

            _circuit = new Circuit();

            SelectingCircuitComboBox.Items.Add("Цепь №1");
            SelectingCircuitComboBox.Items.Add("Цепь №2");
            SelectingCircuitComboBox.Items.Add("Цепь №3");
            SelectingCircuitComboBox.Items.Add("Цепь №4");
            SelectingCircuitComboBox.Items.Add("Цепь №5");

            AddButton.Enabled = false;
            DeleteButton.Enabled = false;
            NodeComboBox.Enabled = false;
            NominalTextBox.Enabled = false;
            ConnectionComboBox.Enabled = false;
        }

        #endregion

        #region ~ Приватные методы ~

        /// <summary>
        /// Выбор тестотвой цепи.
        /// </summary>
        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCircuit = SelectingCircuitComboBox.SelectedItem.ToString();
            if (selectedCircuit == "Цепь №1")
            {
                ElementBase resistor = new Resistor("R1", 10);
                ElementBase capacitor = new Capacitor("C1", 20);
                ElementBase inductor = new Inductor("L1", 30);

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

                _circuit.Clear();
                _circuit.AddAfter(null, parallelCircuit);
            }

            if (selectedCircuit == "Цепь №2")
            {
                var capacitor1 = new Capacitor("C1", 10);
                var inductor1 = new Inductor("L1", 20);
                var resistor1 = new Resistor("R1", 30);
                var inductor2 = new Inductor("L2", 40);

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

                _circuit.Clear();
                _circuit.AddAfter(null, parallelCircuit1);
            }

            if (selectedCircuit == "Цепь №3")
            {
                var resistor1 = new Resistor("R1", 10);
                var resistor2 = new Resistor("R2", 20);
                var resistor3 = new Resistor("R3", 30);
                var inductor1 = new Inductor("L3", 40);
                var capacitor1 = new Capacitor("C1", 50);
                var capacitor2 = new Capacitor("C2", 60);

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

                _circuit.Clear();
                _circuit.AddAfter(null, serialCircuit);
            }

            if (selectedCircuit == "Цепь №4")
            {
                ElementBase resistor1 = new Resistor("R1", 10);
                ElementBase resistor2 = new Resistor("R2", 20);
                ElementBase resistor3 = new Resistor("R3", 30);
                ElementBase resistor4 = new Resistor("R4", 40);
                ElementBase capacitor1 = new Capacitor("C1", 50);
                ElementBase inductor1 = new Inductor("L1", 60);
                ElementBase inductor2 = new Inductor("L2", 70);

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

                _circuit.Clear();
                _circuit.AddAfter(null, serialCircuit1);
            }

            if (selectedCircuit == "Цепь №5")
            {
                ElementBase resistor = new Resistor("R1", 10);
                ElementBase resistor1 = new Resistor("R1", 20);
                ElementBase resistor2 = new Resistor("R1", 30);
                ElementBase capacitor = new Capacitor("C1", 40);
                ElementBase inductor = new Inductor("L1", 50);
                ElementBase inductor2 = new Inductor("L1", 60);

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

                _circuit.Clear();
                _circuit.AddAfter(null, serialCircuit1);
            }

            UpdateTreeView();
        }

        /// <summary>
        /// Событие, срабатывающее при открытии формы расчета импеданса.
        /// </summary>
        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            if (_circuit.Root == null)
            {
                MessageBox.Show("Функция не доспупна при пустой цепи!", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            new ImpedanceForm(_circuit).ShowDialog();
        }

        /// <summary>
        /// Обновление элементов в TreeView.
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



        #endregion


    }
}
