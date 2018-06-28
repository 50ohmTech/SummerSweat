using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class CircuitControl : UserControl
    {
        private uint _resistorCounter = 0;
        private uint _capacitorCounter = 0;
        private uint _inductorCounter = 0;

        private static ObservableCollection<Element> _elements;

        public CircuitControl()
        {
            InitializeComponent();

            _elements = new ObservableCollection<Element>();

            elementBindingSource.DataSource = _elements;
            elementGridView.DataSource = elementBindingSource;            
        }

        public static Circuit Circuit => new Circuit(_elements);

        private void AddButton_Click(object sender, EventArgs e)
        {
            var value = double.Parse(valueBox.Text);

            if (value == 0.0 || value > 10000.0)
            {
                MessageBox.Show("Номинал элемента должен быть больше 0 и не превышать 10000", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (resistorRadioButton.Checked)
            {
                elementBindingSource.Add(new Resistor("R" + Convert.ToString(++_resistorCounter), Convert.ToDouble(valueBox.Text)));
            }
            else if (capacitorRadioButton.Checked)
            {
                elementBindingSource.Add(new Capacitor("C" + Convert.ToString(++_capacitorCounter), Convert.ToDouble(valueBox.Text)));
            }
            else if (inductorRadioButton.Checked)
            {
                elementBindingSource.Add(new Inductor("I" + Convert.ToString(++_inductorCounter), Convert.ToDouble(valueBox.Text)));
            }
        }

        public void Update(ObservableCollection<Element> elements)
        {
            _resistorCounter = 0;
            _capacitorCounter = 0;
            _inductorCounter = 0;

            elementBindingSource.Clear();

            foreach (var element in elements)
            {
                elementBindingSource.Add(element);
            }
        }

        private void ValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnterDouble(sender, e, ((TextBox) sender).Text);
        }

        private void ElementGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= Cell_KeyPress;
            e.Control.KeyPress += Cell_KeyPress;

            e.Control.Leave -= Cell_Leave;
            e.Control.Leave += Cell_Leave;
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnterDouble(sender, e, ((DataGridViewTextBoxEditingControl) sender).Text);
        }

        private void Cell_Leave(object sender, EventArgs e)
        {
            var text = ((DataGridViewTextBoxEditingControl) sender).Text;
            var index = ((DataGridViewTextBoxEditingControl) sender).EditingControlRowIndex;

            if (text == string.Empty)
            {
                ((DataGridViewTextBoxEditingControl)sender).Text =
                    ((Element)elementBindingSource[index]).Value.ToString();

                return;
            }
            if (double.Parse(text) == 0.0 || double.Parse(text) > 10000)
            {
                ((DataGridViewTextBoxEditingControl)sender).Text =
                    ((Element)elementBindingSource[index]).Value.ToString();
            }
        }

        private void EnterDouble(object sender, KeyPressEventArgs e, string text)
        {
            var separator = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back) return;

            if (text.IndexOf(separator) != -1)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar.ToString() == separator) return;

            e.Handled = true;
        }

        private void valueBox_Enter(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox)) return;
            if (textBox.Text == "0")
            {
                textBox.Text = string.Empty;
            }
        }

        private void valueBox_Leave(object sender, EventArgs e)
        {
            if (!(sender is TextBox textBox)) return;

            if (textBox.Text == string.Empty)
            {
                textBox.Text = "0";
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateForm calculateForm = new CalculateForm();
            calculateForm.ShowDialog();
        }
    }
}
