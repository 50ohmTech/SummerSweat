using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Numerics;

namespace View
{
    /// <summary>
    /// Форма для вычисления импеданса.
    /// </summary>
    public partial class CalculateForm : Form
    {
        #region - - Поля - -

        /// <summary>
        /// Список частот сигнала.
        /// </summary>
        private List<double> _frequencies;

        /// <summary>
        /// Список импедансов цепи.
        /// </summary>
        private List<Complex> _impedancies;

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CalculateForm.
        /// </summary>
        public CalculateForm()
        {
            InitializeComponent();
        }

        #endregion

        #region - - Приватные методы - -

        private void CreateFrequencyButton_Click(object sender, EventArgs e)
        {
            NumberBox.ChangeSeparator(startValueBox);
            NumberBox.ChangeSeparator(intervalBox);
            NumberBox.ChangeSeparator(countBox);

            var startValue = double.Parse(startValueBox.Text);
            var interval = double.Parse(intervalBox.Text);
            var count = uint.Parse(countBox.Text);

            if (interval < double.Parse(Properties.Resources.minFrequencyInterval) ||
                interval > double.Parse(Properties.Resources.maxFrequencyInterval))
            {
                MessageBox.Show(
                    "Интервал между частотами должен быть\nне менее " +
                    Properties.Resources.minFrequencyInterval + " и не более " +
                    Properties.Resources.maxFrequencyInterval,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (count < int.Parse(Properties.Resources.minFrequencyCount) ||
                count > int.Parse(Properties.Resources.maxFrequencyCount))
            {
                MessageBox.Show(
                    "Количество значений должно быть\nне менее " +
                    Properties.Resources.minFrequencyCount + " и не более " +
                    Properties.Resources.maxFrequencyCount,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (startValue < double.Parse(Properties.Resources.minFrequencyStartValue) ||
                startValue > double.Parse(Properties.Resources.maxFrequencyStartValue))
            {
                MessageBox.Show(
                    "Начальное значение длжно быть\nне менее " +
                    Properties.Resources.minFrequencyStartValue + " и не более " +
                    Properties.Resources.maxFrequencyStartValue,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _frequencies = new List<double>();

            for(var index = 0; index < count; index++)
            {
                _frequencies.Add(startValue + index * interval);
            }

            var circuit = ((CreateForm)Owner).Circuit;

            _impedancies = circuit.CalculateZ(_frequencies);
            circuitGridView.Rows.Clear();

            for (var index = 0; index < _impedancies.Count; index++)
            {
                circuitGridView.Rows.Add(_impedancies[index], _frequencies[index]);
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }

        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox)sender).Text);
        }

        private void IntTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressInt(e);
        }

        #endregion
    }
}
