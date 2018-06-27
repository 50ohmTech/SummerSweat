using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            switch (circuitComboBox.SelectedIndex)
            {
                case 0:
                    Circuit circuit = new Circuit();
                    circuit.Elements.Add(new Resistor("R1", 12));
                    circuit.Elements.Add(new Resistor("R2", 8));
                    circuit.Elements.Add(new Resistor("R3", 5));


                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}
