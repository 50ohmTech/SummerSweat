using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace CircuitView
{
    /// <summary>
    /// Форма для расчета импеданса.
    /// </summary>
    public partial class CalculateForm : Form
    {

        #region Поля

        /// <summary>
        /// Список частот сигнала.
        /// </summary>
        private List<double> _frequencies;
        /// <summary>
        /// Список импедансов цепи.
        /// </summary>
        private List<Complex> _impedancies;

        #endregion

        #region Публичные методы
        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public CalculateForm()
        {
            InitializeComponent();
            _frequencies = new List<double>();
        }
        /// <summary>
        /// Расчет импеданса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateFrequenciesButton(object sender, EventArgs e)
        {
            var startValue = double.Parse(StartValueBox.Text);
            var interval = double.Parse(IntervalBox.Text);
            var count = uint.Parse(AmountBox.Text);

            for (var index = 0; index < count; index++)
            {
                _frequencies.Add(startValue + index * interval);
            }

            if (FrequenciesGridView.Rows.Count > 1000)
            {
                MessageBox.Show("Общее количество частот должно быть меньше 1000", "Error",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var circuit = ((MainForm)Owner).Circuit;

            _impedancies = circuit.CalculateZ(_frequencies);
            FrequenciesGridView.Rows.Clear();

            for (var index = 0; index < _impedancies.Count; index++)
            {
                FrequenciesGridView.Rows.Add(_impedancies[index], _frequencies[index]);
            }
        }

        #endregion

    }
}
