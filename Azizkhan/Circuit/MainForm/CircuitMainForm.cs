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
    public partial class MainForm : Form
    {
        #region Fields

        #region Readonly fields

        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        private INode _currentNode;

        #endregion

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            SelectingCircuitComboBox.Items.Add("Цепь №1");
            SelectingCircuitComboBox.Items.Add("Цепь №2");
            SelectingCircuitComboBox.Items.Add("Цепь №3");
            SelectingCircuitComboBox.Items.Add("Цепь №4");
            SelectingCircuitComboBox.Items.Add("Цепь №5");
            NadeComboBox.DataSource = Enum.GetValues(typeof(NodeType));
            NadeComboBox.SelectedItem = NodeType.Serial;

            // AddButton.Enabled = false;
            SelectingCircuitComboBox.SelectedItem = "Цепь №1";
        }

        #endregion

        #region Private methods

        private bool IsCorrectAdd()
        {
            if (!(_currentNode is SubcircuitBase) && treeView.Nodes.Count > 0)
            {
                MessageBox.Show(
                    "Для добавление элемента в цепь, требуеться выдбрать " +
                    "последовательность (параллельная, последовательная)");

                return true;
            }

            return false;
        }

        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            //TODO: Переименовать SelectingCircuitComboBox в CircuitsComboBox
            var selectedState = SelectingCircuitComboBox.SelectedItem.ToString();
            if (selectedState == "Цепь №1")
            {
                //TODO: генерацию тестовых цепей вынести в отдельный класс
                var resistor = new Resistor("R1", 10);
                var inductor = new Inductor("L1", 50);
                var capacitor = new Capacitor("C1", 15);

                var parallelSubcircuit = new ParallelSubcircuit();
                parallelSubcircuit.Nodes.Add(capacitor);
                parallelSubcircuit.Nodes.Add(inductor);
                inductor.Parent = parallelSubcircuit;
                capacitor.Parent = parallelSubcircuit;

                var serialSubcircuit = new SerialSubcircuit();
                serialSubcircuit.Nodes.Add(parallelSubcircuit);
                serialSubcircuit.Nodes.Add(resistor);
                parallelSubcircuit.Parent = serialSubcircuit;
                resistor.Parent = serialSubcircuit;

                _circuit.AddAfter(null, serialSubcircuit);
                UpdateTreeView();
            }

            if (selectedState == "Цепь №2")
            {
                var capacitor1 = new Capacitor("C1", 20);
                var inductor2 = new Inductor("L1", 20);
                var resistor3 = new Resistor("R1", 20);
                var inductor4 = new Inductor("L2", 20);

                var parallelSubcircuit1 = new ParallelSubcircuit();
                parallelSubcircuit1.Nodes.Add(capacitor1);
                capacitor1.Parent = parallelSubcircuit1;

                var serialSubcircuit1 = new SerialSubcircuit();
                parallelSubcircuit1.Nodes.Add(serialSubcircuit1);
                serialSubcircuit1.Parent = parallelSubcircuit1;

                serialSubcircuit1.Nodes.Add(inductor2);
                inductor2.Parent = serialSubcircuit1;

                var parallelSubcircuit2 = new ParallelSubcircuit();
                parallelSubcircuit2.Nodes.Add(resistor3);
                resistor3.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit2;

                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                _circuit.AddAfter(null, parallelSubcircuit1);
            }

            if (selectedState == "Цепь №3")
            {
                var resistor1 = new Resistor("R1", 20);
                var inductor2 = new Inductor("L1", 20);
                var inductor3 = new Inductor("L2", 20);
                var inductor4 = new Inductor("L3", 20);
                var resistor5 = new Resistor("R1", 20);
                var resistor6 = new Resistor("R1", 20);
                var inductor7 = new Inductor("L4", 20);

                var parallelSubcircuit1 = new ParallelSubcircuit();

                var serialSubcircuit1 = new SerialSubcircuit();
                var serialSubcircuit2 = new SerialSubcircuit();

                parallelSubcircuit1.Nodes.Add(serialSubcircuit1);
                serialSubcircuit1.Parent = parallelSubcircuit1;
                parallelSubcircuit1.Nodes.Add(serialSubcircuit2);
                serialSubcircuit2.Parent = parallelSubcircuit1;

                var parallelSubcircuit2 = new ParallelSubcircuit();
                var parallelSubcircuit3 = new ParallelSubcircuit();

                serialSubcircuit1.Nodes.Add(inductor3);
                inductor3.Parent = serialSubcircuit1;
                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                parallelSubcircuit2.Nodes.Add(resistor1);
                resistor1.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit2;

                serialSubcircuit2.Nodes.Add(inductor2);
                inductor2.Parent = serialSubcircuit2;
                serialSubcircuit2.Nodes.Add(resistor5);
                resistor5.Parent = serialSubcircuit2;
                serialSubcircuit2.Nodes.Add(parallelSubcircuit3);
                parallelSubcircuit3.Parent = serialSubcircuit2;
                parallelSubcircuit3.Nodes.Add(resistor6);
                resistor6.Parent = parallelSubcircuit3;
                parallelSubcircuit3.Nodes.Add(inductor7);
                inductor7.Parent = parallelSubcircuit3;
                _circuit.AddAfter(null, parallelSubcircuit1);
            }

            if (selectedState == "Цепь №4")
            {
                var resistor1 = new Resistor("R1", 1);
                var capacitor2 = new Capacitor("C2", 20);
                var resistor3 = new Resistor("R3", 20);
                var inductor4 = new Inductor("L4", 20);
                var resistor5 = new Resistor("R5", 20);
                var inductor6 = new Inductor("L6", 20);

                var serialSubcircuit1 = new SerialSubcircuit();
                var parallelSubcircuit1 = new ParallelSubcircuit();
                var parallelSubcircuit2 = new ParallelSubcircuit();

                serialSubcircuit1.Nodes.Add(parallelSubcircuit1);
                parallelSubcircuit1.Parent = serialSubcircuit1;
                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                serialSubcircuit1.Nodes.Add(resistor3);
                resistor3.Parent = serialSubcircuit1;
                parallelSubcircuit1.Nodes.Add(resistor1);
                resistor1.Parent = parallelSubcircuit1;
                parallelSubcircuit1.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit1;
                parallelSubcircuit2.Nodes.Add(capacitor2);
                capacitor2.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(resistor5);
                resistor5.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(inductor6);
                inductor6.Parent = parallelSubcircuit2;
                _circuit.AddAfter(null, serialSubcircuit1);
            }

            if (selectedState == "Цепь №5")
            {
                var resistor1 = new Resistor("R1", 20);
                var capacitor2 = new Capacitor("C2", 20);
                var resistor3 = new Resistor("R3", 20);
                var inductor4 = new Inductor("L4", 20);
                var resistor5 = new Resistor("R5", 20);
                var inductor6 = new Inductor("L6", 20);
                var resistor7 = new Resistor("R7", 20);
                var inductor8 = new Inductor("L8", 20);

                var serialSubcircuit1 = new SerialSubcircuit();
                var serialSubcircuit2 = new SerialSubcircuit();
                var parallelSubcircuit1 = new ParallelSubcircuit();
                var parallelSubcircuit2 = new ParallelSubcircuit();
                var parallelSubcircuit3 = new ParallelSubcircuit();
                serialSubcircuit1.Nodes.Add(parallelSubcircuit1);
                parallelSubcircuit1.Parent = serialSubcircuit1;
                parallelSubcircuit1.Nodes.Add(resistor1);
                resistor1.Parent = parallelSubcircuit1;
                parallelSubcircuit1.Nodes.Add(inductor4);
                inductor4.Parent = parallelSubcircuit1;

                serialSubcircuit1.Nodes.Add(parallelSubcircuit2);
                parallelSubcircuit2.Parent = serialSubcircuit1;
                parallelSubcircuit2.Nodes.Add(capacitor2);
                capacitor2.Parent = parallelSubcircuit2;
                parallelSubcircuit2.Nodes.Add(serialSubcircuit2);
                serialSubcircuit2.Parent = parallelSubcircuit2;
                serialSubcircuit2.Nodes.Add(parallelSubcircuit3);
                parallelSubcircuit3.Parent = serialSubcircuit2;
                serialSubcircuit2.Nodes.Add(resistor7);
                resistor7.Parent = serialSubcircuit2;
                parallelSubcircuit3.Nodes.Add(resistor5);
                resistor5.Parent = parallelSubcircuit3;
                parallelSubcircuit3.Nodes.Add(inductor8);
                inductor8.Parent = parallelSubcircuit3;
                parallelSubcircuit2.Nodes.Add(inductor6);
                inductor6.Parent = parallelSubcircuit2;
                serialSubcircuit1.Nodes.Add(resistor3);
                resistor3.Parent = serialSubcircuit1;

                _circuit.AddAfter(null, serialSubcircuit1);
            }

            UpdateTreeView();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var selectedState = NadeComboBox.SelectedItem.ToString();


            try
            {
                string nameElement;
                double valueElement = double.Parse(NominalTextBox.Text);
                uint count = 1;

                switch (selectedState)
                {
                    case "Serial":
                        _circuit.AddAfter(_currentNode, new SerialSubcircuit());
                        break;
                    case "Parallel":
                        _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
                        break;
                    case "Resistor":
                        if (IsCorrectAdd())
                        {
                            return;
                        }

                        nameElement = "R" + count;
                        _circuit.AddAfter(_currentNode,
                            new Resistor(nameElement, valueElement));

                        break;
                    case "Inductor":
                        if (IsCorrectAdd())
                        {
                            return;
                        }

                        count++;
                        nameElement = "L" + count;
                        _circuit.AddAfter(_currentNode,
                            new Inductor(nameElement,
                                valueElement));

                        break;
                    case "Capacitor":
                        if (IsCorrectAdd())
                        {
                            return;
                        }

                        count++;
                        nameElement = "C" + count;
                        _circuit.AddAfter(_currentNode,
                            new Capacitor(nameElement,
                                valueElement));

                        break;
                }

                UpdateTreeView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

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

                foreach (var children in node.Nodes)
                {
                    var newTreeNode = new TreeINode(children);
                    treeNode.Nodes.Add(newTreeNode);
                    AddNodeTreeNodes(children, newTreeNode);
                }
            }

            treeView.Nodes.Clear();

            var root = new TreeINode(_circuit.Root);
            treeView.Nodes.Add(root);
            AddNodeTreeNodes(_circuit.Root, root);

            treeView.ExpandAll();

            //circuitPictureBox.Image = null;
            ////TODO: Создание битмапа и инициализация шрифтов и ручек должна быть в Drawer
            //var bitmapBackground = new Bitmap(1000, 1000);
            //Drawer.Graphics = Graphics.FromImage(bitmapBackground);
            //Drawer.Pen = new Pen(Color.Black, 1);
            //Drawer.Font = Font;

            //var displacement = new Point(15, 0);
            //Drawer.DrawCircuit(_circuit.Root, displacement);

            //circuitPictureBox.Image = bitmapBackground;
        }

        private void NominalTextBox_Validating(object sender, CancelEventArgs e)
        {
            FormTools.TextBoxCheck(NominalTextBox, e);
        }

        private void NominalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (NadeComboBox.SelectedIndex > 1)
            {
                AddButton.Enabled = NominalTextBox.Text.Length != 0;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
        }

        private void NadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NadeComboBox.SelectedIndex > 1)
            {
                AddButton.Enabled = NominalTextBox.Text.Length != 0;
            }
        }

        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            //new ImpedanceForm(_circuit).ShowDialog();
        }

        #endregion
    }
}