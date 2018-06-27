using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gpt.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComboBoxCircuit.Items.Add("Цепь №1");
            ComboBoxCircuit.Items.Add("Цепь №2");
            ComboBoxCircuit.Items.Add("Цепь №3");
            ComboBoxCircuit.Items.Add("Цепь №4");
            ComboBoxCircuit.Items.Add("Цепь №5");
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCircuit = ComboBoxCircuit.SelectedItem.ToString();
            MessageBox.Show(selectedCircuit);
            switch (selectedCircuit)
            {
                case "Цепь №1":
                    break;
                case "Цепь №2":
                    break;
                case "Цепь №3":
                    break;
                case "Цепь №4":
                    break;
                case "Цепь №5":
                    break;
            }
        }

    }
}
