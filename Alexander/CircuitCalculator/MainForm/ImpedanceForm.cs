using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Model.Circuit;

namespace View
{
    /// <summary>
    ///     Форма расчетов импедансов.
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Readonly fields
        
        /// <summary>
        ///     Поле для цепи.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        /// <summary>
        ///     Список частот.
        /// </summary>
        private List<double> _frequencies;

        /// <summary>
        ///     Список импедансов.
        /// </summary>
        private List<Complex> _impedancies;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="circuit">Цепь.</param>
        public ImpedanceForm(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
        }

        #endregion

        #region Private methods
        
        /// <summary>
        ///     Расчет импедансов.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var start = double.Parse(StartNumericUpDown.Text);
            var finish = double.Parse(FinishNumericUpDown.Text);
            var step = double.Parse(StepNumericUpDown.Text);

            _frequencies = new List<double>();

            for (var index = start; index <= finish;)
            {
                _frequencies.Add(index += step);
            }

            _impedancies = _circuit.CalculateZ(_frequencies.ToArray());
            dataGridView.Rows.Clear();

            for (var index = 0; index < _impedancies.Count; index++)
            {
                dataGridView.Rows.Add(_frequencies[index], _impedancies[index]);
            }
        }

        #endregion
    }
}