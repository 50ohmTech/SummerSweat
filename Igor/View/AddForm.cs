using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gpt.Model;

namespace Gpt.View
{
    public partial class AddForm : Form
    {
        private readonly ObservableCollection<ElementBase> _elements;

        private readonly Panel _panel;

        private readonly ElementControl _elementControl;
        //private readonly List<ElementBase> _elements;
        public AddForm(ObservableCollection<ElementBase> elements, Panel panel)
        {
            InitializeComponent();
            ComboBoxCircuit.Items.Add("Резистор");
            ComboBoxCircuit.Items.Add("Индуктор");
            ComboBoxCircuit.Items.Add("Конденсатор");
            //ComboBoxCircuit.Items.Add("Конец цепи");
            //ComboBoxCircuit.Items.Add("Начало цепи");
            ComboBoxCircuit.DropDownStyle = ComboBoxStyle.DropDownList;
            _panel = panel;
            _elements = elements;
            //label1.Visible = false;
            //label2.Visible = false;
            //textBox1.Visible = false;
            //textBox2.Visible = false;

        }

        public ElementBase ElementBase { get; set; }
        public ElementControl NewElementControl { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCircuit = ComboBoxCircuit.SelectedItem.ToString();
            //MessageBox.Show(selectedCircuit);
            //ElementControl newElementControl = null;
            switch (selectedCircuit)
            {
                case "Резистор":
                    ElementBase =
                        new Resistor(textBox1.Text, double.Parse(textBox2.Text));
                    break;
                case "Индуктор":
                    ElementBase =
                        new Inductor(textBox1.Text, double.Parse(textBox2.Text));
                    break;
                case "Конденсатор":
                    ElementBase =
                        new Capacitor(textBox1.Text, double.Parse(textBox2.Text));
                    break;
                case "Конец цепи":
                    break;
                case "Цепь №5":
                    break;
            }

            NewElementControl = new ElementControl(ElementBase, _elements);
            _panel.Controls.Add(NewElementControl);
            Close();
        }
    }
}
