using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void circuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (circuitComboBox.SelectedIndex == 0)
            {
                circuitControl.Update(new ObservableCollection<Element>());
            }
            else if (circuitComboBox.SelectedIndex == 1)
            {
                ObservableCollection<Element> elements = new ObservableCollection<Element>
                {
                    new Resistor("R1", 33.333),
                    new Resistor("R2", 50.5),
                    new Resistor("R3", 100)
                };

                circuitControl.Update(elements);
            }
            else if (circuitComboBox.SelectedIndex == 2)
            {
                ObservableCollection<Element> elements = new ObservableCollection<Element>
                {
                    new Capacitor("C1", 66.666),
                    new Inductor("I1", 0.02)
                };

                circuitControl.Update(elements);
            }
            else if (circuitComboBox.SelectedIndex == 3)
            {
                ObservableCollection<Element> elements = new ObservableCollection<Element>
                {
                    new Resistor("R1", 95),
                    new Capacitor("C1", 38),
                    new Inductor("I1", 0.5),
                    new Capacitor("C2", 32.8)
                };

                circuitControl.Update(elements);
            }
        }
    }
}
