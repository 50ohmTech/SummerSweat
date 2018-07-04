using Model;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма создания цепи.
    /// </summary>
    public partial class CreateForm : Form
    {
        #region - - Поля - -

        /// <summary>
        /// Количество резисторов в цепи.
        /// </summary>
        private uint _resistorCounter;

        /// <summary>
        /// Количество конденсаторов в цепи.
        /// </summary>
        private uint _capacitorCounter;

        /// <summary>
        /// Количество катушек индуктивности в цепи.
        /// </summary>
        private uint _inductorCounter;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public Circuit Circuit { get; set; }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CreateForm.
        /// </summary>
        public CreateForm()
        {
            InitializeComponent();
            
            Circuit = new Circuit(new ElementsTree());

            Circuit.Elements.ElementsChanged += Circuit_ElementsChanged;

            valueBox.ContextMenu = new ContextMenu();
            circuitComboBox.SelectedIndex = 0;

            _resistorCounter = 0;
            _capacitorCounter = 0;
            _inductorCounter = 0;
        }

        #endregion

        #region - - Приватные методы - -

        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (circuitComboBox.SelectedIndex)
            {
                case 0:
                    _resistorCounter = 0;
                    _capacitorCounter = 0;
                    _inductorCounter = 0;

                    Circuit.Elements.Clear();

                    break;
                case 1:
                {
                    _resistorCounter = 5;
                    _capacitorCounter = 0;
                    _inductorCounter = 0;

                    Circuit.Elements.Clear();

                    var elements = new List<Element>
                    {
                        new Resistor("R1", 10),
                        new Resistor("R2", 20),
                        new Resistor("R3", 10),
                        new Resistor("R4", 10),
                        new Resistor("R5", 5)
                    };

                    Circuit.Elements.Add(elements[0]);
                    Circuit.Elements.Add(elements[1], "R1", false);
                    Circuit.Elements.Add(elements[2], "R1", true);
                    Circuit.Elements.Add(elements[3], "R3", false);
                    Circuit.Elements.Add(elements[4], "R1", true);

                    break;
                }
                case 2:
                {
                    _resistorCounter = 1;
                    _capacitorCounter = 1;
                    _inductorCounter = 2;

                    Circuit.Elements.Clear();

                    var elements = new List<Element>
                    {
                        new Capacitor("C1", 66.666),
                        new Inductor("I1", 0.02),
                        new Resistor("R1", 20.56),
                        new Inductor("I2", 0.7)
                    };

                    Circuit.Elements.Add(elements[0]);
                    Circuit.Elements.Add(elements[1], "C1", false);
                    Circuit.Elements.Add(elements[2], "I1", true);
                    Circuit.Elements.Add(elements[3], "C1", false);

                    break;
                }
                case 3:
                {
                    _resistorCounter = 2;
                    _capacitorCounter = 3;
                    _inductorCounter = 1;

                    Circuit.Elements.Clear();

                    var elements = new List<Element>
                    {
                        new Resistor("R1", 95),
                        new Capacitor("C1", 38),
                        new Inductor("I1", 0.5),
                        new Capacitor("C2", 32.8),
                        new Resistor("R2", 20),
                        new Capacitor("C3", 66.666)
                    };

                    Circuit.Elements.Add(elements[0]);
                    Circuit.Elements.Add(elements[1], "R1", false);
                    Circuit.Elements.Add(elements[2], "C1", true);
                    Circuit.Elements.Add(elements[3], "R1", true);
                    Circuit.Elements.Add(elements[4], "I1", false);
                    Circuit.Elements.Add(elements[5], "C2", false);

                    break;
                }
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

            var calculateForm = new CalculateForm {Owner = this};
            calculateForm.ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NumberBox.ChangeSeparator(valueBox);

            var value = double.Parse(valueBox.Text);

            if (value < double.Parse(Properties.Resources.minElementValue) ||
                value > double.Parse(Properties.Resources.maxElementValue))
            {
                MessageBox.Show(
                    "Номинал элемента должен быть\n больше " +
                    Properties.Resources.minElementValue + " и не превышать " +
                    Properties.Resources.maxElementValue,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (resistorRadioButton.Checked)
            {
                Circuit.Elements.Add(new Resistor(
                    "R" + (++_resistorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else if (capacitorRadioButton.Checked)
            {
                Circuit.Elements.Add(new Capacitor(
                    "C" + (++_capacitorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else if (inductorRadioButton.Checked)
            {
                Circuit.Elements.Add(new Inductor(
                    "I" + (++_inductorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else
            {
                MessageBox.Show(
                    "Выберите тип элемента", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in elementGridView.SelectedRows)
            {
                elementGridView.Rows.Remove(row);
            }
        }

        private void ElementGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.ContextMenu = new ContextMenu();

            e.Control.KeyPress -= Cell_KeyPress;
            e.Control.KeyPress += Cell_KeyPress;

            e.Control.Leave -= Cell_Leave;
            e.Control.Leave += Cell_Leave;
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e,
                ((DataGridViewTextBoxEditingControl)sender).Text);
        }

        private void Cell_Leave(object sender, EventArgs e)
        {
            var text = ((DataGridViewTextBoxEditingControl)sender).Text;
            var index = ((DataGridViewTextBoxEditingControl)sender).EditingControlRowIndex;

            if (!double.TryParse(text, out var value))
            {
                //((DataGridViewTextBoxEditingControl) sender).Text =
                //    elementGridView.Rows[index].Cells[1].Value.ToString();

                return;
            }

            if (value < double.Parse(Properties.Resources.minElementValue) ||
                value > double.Parse(Properties.Resources.maxElementValue))
            {
                //((DataGridViewTextBoxEditingControl) sender).Text =
                //    ((Element) elementBindingSource[index]).Value.ToString();
            }
        }

        private void ValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox)sender).Text);
        }

        private void ValueBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void ValueBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }

        private void Circuit_ElementsChanged(object sender, ChangedEventArgs e)
        {
            if (e.Type == ChangedEventArgs.ChangeType.Add)
            {
                elementGridView.Rows.Add(e.Element.Name, e.Element.Value);
            }
            else if (e.Type == ChangedEventArgs.ChangeType.Delete)
            {
            }
            else if (e.Type == ChangedEventArgs.ChangeType.Clear)
            {
                elementGridView.Rows.Clear();
            }

        }

        #endregion
    }
}
