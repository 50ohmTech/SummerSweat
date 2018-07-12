﻿using System;
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

            _frequencies = new List<double>();

            for (var index = 0; index < count; index++)
            {
                _frequencies.Add(startValue + index * interval);
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
