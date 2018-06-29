using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gpt.Model;

namespace Gpt.View
{
    public partial class MainForm : Form
    {
        //private List<ElementBase> _elements;    
        private readonly Circuit _circuit;

        private List<Circuit> _circuitsList;

        private AddForm _addForm;

        private List<ElementControl> _elementControls;

        private readonly ObservableCollection<ElementBase> _elements;

        public MainForm()
        {
            InitializeComponent();
            InitializeCircuits();
            comboBox1.Items.Add("Цепь №1");
            comboBox1.Items.Add("Цепь №2");
            comboBox1.Items.Add("Цепь №3");
            comboBox1.Items.Add("Цепь №4");
            comboBox1.Items.Add("Цепь №5"); ;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            _addForm = new AddForm(null,null);
           // bindingSource1.DataSource = _elements;
            dataGridView1.DataSource = bindingSource1;
            _circuit = new Circuit();
            dataGridView1.Visible = false;
        }

        private void InitializeCircuits()
        {
            //_circuitsList = new List<Circuit>();
            //var circuitElements = new ObservableCollection<ElementBase>();
            //circuitElements.Add(new Capacitor("C1", 10));
            //circuitElements.Add(new Inductor("L1", 5));
            //circuitElements.Add(new Resistor("R1", 10));
            //var elementsControls = new List<ElementControl>();
            //elementsControls.Add(new ElementControl(new Capacitor("C1", 10), circuitElements));
            //elementsControls.Add(new ElementControl(new Resistor("R1", 10), circuitElements));
            //elementsControls[0].Location = new Point(0, 50);
            //elementsControls[1].Location = new Point(80, 50);
            //panel1.Controls.Add(elementsControls[0]);
            //panel1.Controls.Add(elementsControls[1]);
            //var circuit1 = new Circuit(circuitElements);
            //_circuitsList.Add(circuit1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_addForm.ShowDialog();
            //if (_addForm.ElementBase != null)
            //{
            //    bindingSource1.Add(_addForm.ElementBase);
            //    _elements.Add(_addForm.ElementBase);
            //    _addForm.NewElementControl = new ElementControl();
            //}
            new AddForm(_circuit.Elements, panel1).ShowDialog();
        }

        private void SelectCircuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();
            MessageBox.Show(selectedState);
            var salary = comboBox1.Text;
            _circuitsList = new List<Circuit>();
            var circuitElements = new ObservableCollection<ElementBase>();
            var elementsControls = new List<ElementControl>();
            var endElementsControls = new List<ElementControl>();
            switch (salary)
            {
                case "Цепь №1":
                {
                    //_circuitsList = new List<Circuit>();
                    //var circuitElements = new ObservableCollection<ElementBase>();
                    endElementsControls.Add(new ElementControl("Starting"));
                    circuitElements.Add(new Capacitor("C1", 10));
                    circuitElements.Add(new Inductor("L1", 5));
                    circuitElements.Add(new Resistor("R1", 10));
                    //var elementsControls = new List<ElementControl>();
                    elementsControls.Add(new ElementControl("Starting"));
                    elementsControls.Add(new ElementControl(new Capacitor("C1", 10),
                        circuitElements));
                    elementsControls.Add(new ElementControl(new Resistor("R1", 10),
                        circuitElements));
                    elementsControls.Add(new ElementControl(new Inductor("L1", 10),
                        circuitElements));
                    elementsControls.Add(new ElementControl("Ending"));


                    elementsControls[0].Location = new Point(0, 50);
                    elementsControls[1].Location = new Point(80, 50);
                    elementsControls[2].Location = new Point(160,50);
                    elementsControls[3].Location = new Point(240, 50);
                    elementsControls[4].Location = new Point(320, 50);
                        break;
                }
                case "Цепь №2":
                {
                    break;
                }
                case "Цепь №3":
                {
                    break;
                }
                case "Цепь №4":
                {
                    break;
                }
                case "Цепь №5":
                {
                    break;
                }
            }

            panel1.Controls.Add(elementsControls[0]);
            panel1.Controls.Add(elementsControls[1]);
            panel1.Controls.Add(elementsControls[2]);
            panel1.Controls.Add(elementsControls[3]);
            panel1.Controls.Add(elementsControls[4]);
        }
    }
}
