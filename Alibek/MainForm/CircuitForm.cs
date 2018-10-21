using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElementsLibrary;
using ElementsLibrary.Circuits;

namespace MainForm
{
    public partial class CircuitForm : Form
    {
        private readonly Circuit _circuit;

        private INode _currentNode;

        public static string GetDescription(NodeType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }

        public CircuitForm()
        {
            InitializeComponent();
            TestCircuitsComboBox.Items.Add("Цепь №1");
            TestCircuitsComboBox.Items.Add("Цепь №2");
            TestCircuitsComboBox.Items.Add("Цепь №3");
            TestCircuitsComboBox.Items.Add("Цепь №4");
            TestCircuitsComboBox.Items.Add("Цепь №5");
            TestCircuitsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            var elements = new List<string>();
            for (NodeType i = 0; i < (NodeType) 5; i++)
            {
                elements.Add(GetDescription(i));
            }


        }

        private void TestCircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedCircuit = TestCircuitsComboBox.SelectedItem.ToString();
            if (selectedCircuit == "Цепь №1")
            {
                 var resistor = new Resistor(13, "R1");
                 var capacitor = new Capacitor("C1", 91);
                 var inductor = new Inductor("L1", 32);

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

                


            }
        }
    }
}
