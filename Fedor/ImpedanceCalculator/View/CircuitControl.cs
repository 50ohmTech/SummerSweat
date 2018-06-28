using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Элемент, управляющий изменением цепи.
    /// </summary>
    public partial class CircuitControl : UserControl
    {
        /// <summary>
        /// Количество резисторов в цепи.
        /// </summary>
        private uint _resistorCounter = 0;

        /// <summary>
        /// Количество конденсаторов в цепи.
        /// </summary>
        private uint _capacitorCounter = 0;

        /// <summary>
        /// Количество катушек индуктивности в цепи.
        /// </summary>
        private uint _inductorCounter = 0;

        /// <summary>
        /// Список элементов цепи.
        /// </summary>
        private static List<Element> _elements;

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public Circuit Circuit => new Circuit(_elements);

        /// <summary>
        /// Конструктор класса CircuitControl.
        /// </summary>
        public CircuitControl()
        {
            InitializeComponent();

            _elements = new List<Element>();

            elementBindingSource.DataSource = _elements;
            elementGridView.DataSource = elementBindingSource;            
        }

        /// <summary>
        /// Создать новую цепь.
        /// </summary>
        /// <param name="elements">Список элементов цепи.</param>
        /// <param name="resistorCounter">Количество резисторов в цепи.</param>
        /// <param name="capacitorCounter">Количество конденсаторов в цепи.</param>
        /// <param name="inductorCounter">Количество катушек индуктивности в цепи.</param>
        public void Update(List<Element> elements, uint resistorCounter,
            uint capacitorCounter, uint inductorCounter)
        {
            _resistorCounter = resistorCounter;
            _capacitorCounter = capacitorCounter;
            _inductorCounter = inductorCounter;

            elementBindingSource.Clear();

            foreach (var element in elements)
            {
                elementBindingSource.Add(element);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NumberBox.ChangeSeparator(valueBox);

            var value = double.Parse(valueBox.Text);

            if (value < 0.000001 || value > 10000.0)
            {
                MessageBox.Show(
                    "Номинал элемента должен быть\n больше 0.000001 и не превышать 10000",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (resistorRadioButton.Checked)
            {
                elementBindingSource.Add(new Resistor(
                    "R" + Convert.ToString(++_resistorCounter),
                    Convert.ToDouble(valueBox.Text)));
            }
            else if (capacitorRadioButton.Checked)
            {
                elementBindingSource.Add(new Capacitor(
                    "C" + Convert.ToString(++_capacitorCounter),
                    Convert.ToDouble(valueBox.Text)));
            }
            else if (inductorRadioButton.Checked)
            {
                elementBindingSource.Add(new Inductor(
                    "I" + Convert.ToString(++_inductorCounter),
                    Convert.ToDouble(valueBox.Text)));
            }
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
            NumberBox.PressDouble(e,
                ((DataGridViewTextBoxEditingControl) sender).Text);
        }

        private void Cell_Leave(object sender, EventArgs e)
        {
            var text = ((DataGridViewTextBoxEditingControl) sender).Text;
            var index = ((DataGridViewTextBoxEditingControl) sender).EditingControlRowIndex;

            if (text == string.Empty || text == ",")
            {
                ((DataGridViewTextBoxEditingControl)sender).Text =
                    ((Element)elementBindingSource[index]).Value.ToString();

                return;
            }
            if (double.Parse(text) < 0.000001 || double.Parse(text) > 10000)
            {
                ((DataGridViewTextBoxEditingControl)sender).Text =
                    ((Element)elementBindingSource[index]).Value.ToString();
            }
        }

        private void ValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox) sender).Text);
        }

        private void ValueBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void ValueBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }
    }
}
