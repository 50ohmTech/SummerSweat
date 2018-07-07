using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Model;
using Model.Calculations;

namespace View
{
    /// <summary>
    ///     Форма для рассчетов
    /// </summary>
    public partial class CalculationsForm : Form
    {
        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="circuit">Цепь</param>
        public CalculationsForm(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
            _calculations = new List<Calculations>();
            _calculationsBindingSource.DataSource = _calculations;
        }

        #endregion

        #region Private

        /// <summary>
        ///     Список расчетов
        /// </summary>
        private readonly List<Calculations> _calculations;

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_calculationsBindingSource.Count < 1)
            {
                MessageBox.Show("Список заданных частот пуст.\r\n" +
                                "Введите их в \"Данные для расчета\"",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            foreach (Calculations calculations in _calculations)
            {
                calculations.Impedance = _circuit.CalculateZ(calculations.Frequency)[0];
                calculations.Impedance = new Complex(
                    Math.Round(calculations.Impedance.Real, 3),
                    Math.Round(calculations.Impedance.Imaginary, 6));
            }

            _dataGridViewCalculations.DataSource = null;
            _dataGridViewCalculations.DataSource = _calculationsBindingSource;
        }

        private void ButtonDeleteCurrent_Click(object sender, EventArgs e)
        {
            if (_calculationsBindingSource.Current is Calculations)
            {
                _calculationsBindingSource.RemoveCurrent();
            }
        }

        private void DataGridViewCalculations_DataError(object sender,
            DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        #endregion
    }
}