using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Model;
using Model.Elements.Checks;

namespace View
{
    /// <summary>
    ///     Форма расчетов импедансов.
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        /// <summary>
        ///     Визуально оформленные импедансы.
        /// </summary>
        private List<string> _impedances = new List<string>();

        /// <summary>
        ///     Начальное значение.
        /// </summary>
        private double _start;

        /// <summary>
        ///     Шаг.
        /// </summary>
        private double _step;

        #endregion

        #endregion

        #region Private methods

        /// <summary>
        ///     Парсер частот из формы.
        /// </summary>
        /// <returns></returns>
        private List<double> ParseFrequencies()
        {
            _errorProvider.Clear();
            _labelCount.Text = $"Количество расчетов: {_trackBarCount.Value.ToString()}";
            _calculationBindingSource.Clear();
            if (!double.TryParse(_textBoxStart.Text, out _start))
            {
                _errorProvider.SetError(_textBoxStart, "Поле не является числом.");
                return null;
            }

            if (!double.TryParse(_textBoxStep.Text, out _step))
            {
                _errorProvider.SetError(_textBoxStep, "Поле не является числом.");
                return null;
            }

            if (_textBoxStart.Text.Contains(" "))
            {
                _errorProvider.SetError(_textBoxStart, "Поле не должно содержать пробелы.");
                return null;
            }

            if (_textBoxStep.Text.Contains(" "))
            {
                _errorProvider.SetError(_textBoxStep, "Поле не должно содержать пробелы.");
                return null;
            }

            List<double> frequencies = new List<double>();
            double maxValue = _start;
            for (int i = 0; i < _trackBarCount.Value; i++)
            {
                frequencies.Add(maxValue);
                maxValue += _step;
            }

            try
            {
                Calculation.CheckFrequencies(_start);
                Calculation.CheckFrequencies(_step);
                Calculation.CheckFrequencies(maxValue);
                _labelError.Visible = false;
            }
            catch (ArgumentException)
            {
                _labelError.Visible = true;
                return null;
            }

            return frequencies;
        }

        /// <summary>
        ///     Расчет импедансов.
        /// </summary>
        /// <param name="frequencies"></param>
        private void CalculateImpedances(List<double> frequencies)
        {
            if (frequencies == null)
            {
                return;
            }

            List<Complex> impedances = null;
            try
            {
                impedances = _circuit.CalculateZ(frequencies.ToArray());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            //TODO: нужен индексатор - используй for
            int count = 0;
            foreach (Complex impedance in impedances)
            {
                Calculation calculation = new Calculation
                {
                    //TODO: Complex.ToString()?
                    Impedance = $"R:{Math.Round(impedance.Real, 3)} I:{Math.Round(impedance.Imaginary, 3)}",
                    Frequency = $"{Math.Round(frequencies[count++], 3)}"
                };

                _calculationBindingSource.Add(calculation);
            }
        }

        private void Control_TextChanged(object sender, EventArgs e)
        {
            CalculateImpedances(ParseFrequencies());
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="circuit">Цепь.</param>
        public ImpedanceForm(Circuit circuit)
        {
            _circuit = circuit;
            InitializeComponent();
            _labelError.Visible = false;
        }

        #endregion
    }
}