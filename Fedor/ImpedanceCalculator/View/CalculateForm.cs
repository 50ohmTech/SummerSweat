using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Model;

namespace View
{
    /// <summary>
    /// Форма для вычисления импеданса.
    /// </summary>
    public partial class CalculateForm : Form
    {
        /// <summary>
        /// Список частот сигнала.
        /// </summary>
        private List<double> _frequencies;

        /// <summary>
        /// Список импедансов цепи.
        /// </summary>
        private List<Complex> _impedancies;

        /// <summary>
        /// Конструктор класса CalculateForm.
        /// </summary>
        public CalculateForm()
        {
            InitializeComponent();
        }

        private void CreateFrequencyButton_Click(object sender, EventArgs e)
        {
            NumberBox.ChangeSeparator(startValueBox);
            NumberBox.ChangeSeparator(intervalBox);
            NumberBox.ChangeSeparator(countBox);

            var startValue = double.Parse(startValueBox.Text);
            var interval = double.Parse(intervalBox.Text);
            var count = uint.Parse(countBox.Text);

            if (interval < 0.001 || interval > 10000.0)
            {
                MessageBox.Show(
                    "Интервал между частотами должен быть\n не менее 0.001 и не более 1000",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (count < 2 || count > 100)
            {
                MessageBox.Show(
                    "Количество значений должно быть\n не менее 2 и не более 100",
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (startValue < 0.001 || startValue > 500000.0)
            {
                MessageBox.Show(
                    "Начальное значение длжно быть\n не менее 0.001 и не более 500000",
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

        private void StartValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox) sender).Text);
        }

        private void IntervalBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox)sender).Text);
        }

        private void CountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressInt(e);
        }

        private void StartValueBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void IntervalBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void CountBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void StartValueBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }

        private void IntervalBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }

        private void CountBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }
    }
}
