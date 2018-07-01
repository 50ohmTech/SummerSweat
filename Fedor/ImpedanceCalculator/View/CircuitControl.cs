using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Элемент, управляющий изменением цепи.
    /// </summary>
    public partial class CircuitControl : UserControl
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

        /// <summary>
        /// Список элементов цепи.
        /// </summary>
        private static List<Element> _elements;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public Circuit Circuit => new Circuit(_elements);

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CircuitControl.
        /// </summary>
        public CircuitControl()
        {
            InitializeComponent();

            _elements = new List<Element>();

            elementBindingSource.DataSource = _elements;
            elementGridView.DataSource = elementBindingSource;      
            
            valueBox.ContextMenu = new ContextMenu();

            _resistorCounter = 0;
            _capacitorCounter = 0;
            _inductorCounter = 0;
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

        #endregion

        #region - - Приватные методы - -

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
                elementBindingSource.Add(new Resistor(
                    "R" + (++_resistorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else if (capacitorRadioButton.Checked)
            {
                elementBindingSource.Add(new Capacitor(
                    "C" + (++_capacitorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else if (inductorRadioButton.Checked)
            {
                elementBindingSource.Add(new Inductor(
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
                ((DataGridViewTextBoxEditingControl) sender).Text);
        }

        private void Cell_Leave(object sender, EventArgs e)
        {
            var text = ((DataGridViewTextBoxEditingControl) sender).Text;
            var index = ((DataGridViewTextBoxEditingControl) sender).EditingControlRowIndex;

            if (!double.TryParse(text, out var value))
            {
                ((DataGridViewTextBoxEditingControl)sender).Text =
                    ((Element)elementBindingSource[index]).Value.ToString();

                return;
            }

            if (value < double.Parse(Properties.Resources.minElementValue) ||
                value > double.Parse(Properties.Resources.maxElementValue))
            {
                ((DataGridViewTextBoxEditingControl) sender).Text =
                    ((Element) elementBindingSource[index]).Value.ToString();
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

        #endregion
    }
}
