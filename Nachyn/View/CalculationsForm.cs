using System;
using System.Collections.Generic;
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
        /// <summary>
        ///     Список расчетов
        /// </summary>
        private readonly List<Calculations> _calculations;

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

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
    }
}