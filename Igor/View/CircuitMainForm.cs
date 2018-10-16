using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.Elements;

namespace View
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

        //private List<string> _elements;

        public MainForm()
        {
            InitializeComponent();

            SelectingCircuitComboBox.Items.Add("Цепь №1");
            SelectingCircuitComboBox.Items.Add("Цепь №2");
            SelectingCircuitComboBox.Items.Add("Цепь №3");
            SelectingCircuitComboBox.Items.Add("Цепь №4");
            SelectingCircuitComboBox.Items.Add("Цепь №5");
            SelectingCircuitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            var elements = new List<string>();
            for (NodeType i = 0; i < (NodeType) 5; i++)
            {
                elements.Add(ToolsNodeType.GetDescription(i));
            }

            NadeComboBox.DataSource = elements;
            NadeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _circuit = new Circuit();

            NominalTextBox.Enter += NominalTextBox_Enter;
            NameTextBox.Enter += NameTextBox_Enter;
        }

        #endregion

        #region Private methods

        private void NominalTextBox_Enter(object sender, EventArgs e)
        {
            NominalTextBox.ForeColor = SystemColors.WindowText;
            NominalTextBox.Text = "";
            NominalTextBox.TextAlign = HorizontalAlignment.Center;
        }

        private void NameTextBox_Enter(object sender, EventArgs e)
        {
            NameTextBox.ForeColor = SystemColors.WindowText;
            NameTextBox.Text = "";
            NameTextBox.TextAlign = HorizontalAlignment.Center;
        }

        private void NominalTextBox_Leave(object sender, EventArgs e)
        {
            if (NominalTextBox.Text == "")
            {
                NominalTextBox.ForeColor = SystemColors.WindowFrame;
                NominalTextBox.Enter += NominalTextBox_Enter;
                NominalTextBox.Text = "Значение";
                NominalTextBox.TextAlign = HorizontalAlignment.Center;
            }
            else
            {
                NominalTextBox.Enter -= NominalTextBox_Enter;
            }
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                NameTextBox.ForeColor = SystemColors.WindowFrame;
                NameTextBox.Enter += NameTextBox_Enter;
                NameTextBox.Text = "Имя";
                NameTextBox.TextAlign = HorizontalAlignment.Center;
            }
            else
            {
                NameTextBox.Enter -= NameTextBox_Enter;
            }
        }

        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
            EventArgs e)
        {
            var selectedState = SelectingCircuitComboBox.SelectedItem.ToString();
            if (selectedState == "Цепь №1")
            {
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

            circuitPictureBox.Image = null;
            var bitmapBackground = new Bitmap(1000, 1000);
            Drawer.Graphics = Graphics.FromImage(bitmapBackground);
            Drawer.Pen = new Pen(Color.Black, 1);
            Drawer.Font = Font;

            var displacement = new Point(15, 0);
            Drawer.DrawCircuit(_circuit.Root, displacement);

            circuitPictureBox.Image = bitmapBackground;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var selectedState = NadeComboBox.SelectedItem.ToString();
            try
            {
                switch (selectedState)
                {
                    case "Последовательное":
                        _circuit.AddAfter(_currentNode, new SerialSubcircuit());
                        break;
                    case "Параллельное":
                        _circuit.AddAfter(_currentNode, new ParallelSubcircuit());
                        break;
                    case "Резистор":
                        _circuit.AddAfter(_currentNode,
                            new Resistor(NameTextBox.Text,
                                double.Parse(NominalTextBox.Text)));

                        break;
                    case "Катушка":
                        _circuit.AddAfter(_currentNode,
                            new Inductor(NameTextBox.Text,
                                double.Parse(NominalTextBox.Text)));

                        break;
                    case "Конденсатор":
                        _circuit.AddAfter(_currentNode,
                            new Capacitor(NameTextBox.Text,
                                double.Parse(NominalTextBox.Text)));

                        break;
                }

                UpdateTreeView();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void TreeViewCircuit_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TreeINode treeNode)
            {
                _currentNode = treeNode.Value;
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_currentNode == _circuit.Root)
            {
                _circuit.Remove(_currentNode);
                treeView.Nodes.Clear();
                circuitPictureBox.Image = null;
                return;
            }

            _circuit.Remove(_currentNode);
            UpdateTreeView();
        }

        private void CalculateImpedanceButton_Click(object sender, EventArgs e)
        {
            new ImpedanceForm(_circuit).ShowDialog();
        }

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

        #endregion
    }
}