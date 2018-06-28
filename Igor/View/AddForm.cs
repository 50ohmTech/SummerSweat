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
    public partial class AddForm : Form
    {
        //private readonly ObservableCollection<ElementBase> _elements;
        private readonly List<ElementBase> _elements;
        public AddForm()
        {
            InitializeComponent();
            ComboBoxCircuit.Items.Add("Цепь №1");
            ComboBoxCircuit.Items.Add("Цепь №2");
            ComboBoxCircuit.Items.Add("Цепь №3");
            ComboBoxCircuit.Items.Add("Цепь №4");
            ComboBoxCircuit.Items.Add("Цепь №5");
            ComboBoxCircuit.DropDownStyle = ComboBoxStyle.DropDownList;
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
                case "Цепь №1":
                    ElementBase = new Resistor(textBox1.Text, double.Parse(textBox2.Text));
                    //TODO:разобраться с обсерколектион и зачем он
                    //newElementControl = new ElementControl(new Bitmap(Image.FromFile(@"C:\Users\Игорь\Desktop\цепи\resistor.png"),
                      //  ElementBase, _elements);
                    //_elements.Add(ElementBase);
                     NewElementControl = new ElementControl(ElementBase);
                    break;
                case "Цепь №2":
                    ElementBase = new Resistor(textBox1.Text, double.Parse(textBox2.Text));
                    break;
                case "Цепь №3":
                    ElementBase = new Inductor(textBox1.Text, double.Parse(textBox2.Text));
                    break;
                case "Цепь №4":
                    break;
                case "Цепь №5":
                    break;
            }
        }
    }
}
