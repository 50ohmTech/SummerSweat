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
    /// <summary>
    /// Форма создания цепи.
    /// </summary>
    public partial class CreateForm : Form
    {
        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public Circuit Circuit => circuitControl.Circuit;

        /// <summary>
        /// Конструктор класса CreateForm.
        /// </summary>
        public CreateForm()
        {
            InitializeComponent();
            circuitComboBox.SelectedIndex = 0;
        }

        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (circuitComboBox.SelectedIndex == 0)
            {
                circuitControl.Update(new List<Element>(), 0, 0, 0);
            }
            else if (circuitComboBox.SelectedIndex == 1)
            {
                var elements = new List<Element>
                {
                    new Resistor("R1", 33.333),
                    new Resistor("R2", 50.5),
                    new Resistor("R3", 100)
                };

                circuitControl.Update(elements, 3, 0, 0);
            }
            else if (circuitComboBox.SelectedIndex == 2)
            {
                var elements = new List<Element>
                {
                    new Capacitor("C1", 66.666),
                    new Inductor("I1", 0.02)
                };

                circuitControl.Update(elements, 0, 1, 1);
            }
            else if (circuitComboBox.SelectedIndex == 3)
            {
                var elements = new List<Element>
                {
                    new Resistor("R1", 95),
                    new Capacitor("C1", 38),
                    new Inductor("I1", 0.5),
                    new Capacitor("C2", 32.8)
                };

                circuitControl.Update(elements, 1, 2, 1);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (Circuit.Elements.Count == 0)
            {
                MessageBox.Show("Добавьте элементы в цепь", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CalculateForm calculateForm = new CalculateForm {Owner = this};
            calculateForm.ShowDialog();
        }
    }
}
