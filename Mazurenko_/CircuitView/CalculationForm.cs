using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using CircuitLibrary;

namespace CircuitView
{
    /// <summary>
    ///     Form for calculating the impedance of an electric circuit
    /// </summary>
    public partial class CalculationForm : Form
    {
        #region Private fields

        /// <summary>
        ///     The selected electrical circuit
        ///     to calculate the impedance
        /// </summary>
        private Circuit _circuit;

        /// <summary>
        ///     Frequency list
        /// </summary>
        private double[] _frequencies;

        /// <summary>
        ///     Impedance list
        /// </summary>
        private List<Complex> _impedancies;

        #endregion

        #region Properties

        /// <summary>
        ///     The selected electrical circuit
        ///     to calculate the impedance
        /// </summary>
        public Circuit SetCircuit
        {
            set => _circuit =
                value ?? throw new ArgumentNullException(nameof(value),
                    "The electrical circuit is null");
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public CalculationForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Event when leaving the TextBox
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            var resultValue = ValueTextBoxTools.TextBoxLeave(sender);
            CalculationButton.Enabled = resultValue;
        }

        /// <summary>
        ///     Event triggered when the field is changed TextBox
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CalculationButton.Enabled = ValueTextBoxTools.TextChanged(sender);
        }

        /// <summary>
        ///     Enter floating-point numbers only
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void TextBox_DoubleKeyPress(object sender, KeyPressEventArgs e)
        {
            ValueTextBoxTools.DoubleKeyPress(e, sender);
        }

        /// <summary>
        ///     Impedance calculation for a given frequency range
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void CalculationButton_Click(object sender, EventArgs e)
        {
            double.TryParse(StepTextBox.Text, out var step);
            double.TryParse(StartValueTextBox.Text, out var startValue);
            double.TryParse(EndValueTextBox.Text, out var endValue);

            if (!FrequencyRange.IsCorrectStartEnd(startValue, endValue) ||
                !FrequencyRange.IsCorrectStep(startValue, endValue, step))
            {
                return;
            }

            var frequencies = new List<double>();

            for (var frequency = startValue; frequency <= endValue; frequency += step)
            {
                frequencies.Add(frequency);
            }

            if (frequencies.Last() == 0)
            {
                frequencies.Remove(frequencies.Last());
            }

            _frequencies = new double[frequencies.Count];

            for (var i = 0; i < frequencies.Count; i++)
            {
                _frequencies[i] = frequencies.ElementAt(i);
            }

            _impedancies = _circuit.CalculateZ(_frequencies);
            var listImpedances = new List<string>();

            CalculationGridView.Rows.Clear();
            for (var i = 0; i < _impedancies.Count; i++)
            {
                listImpedances.Add(
                    $"Real : ({Math.Round(_impedancies[i].Real, 3)})" +
                    $" Imaginary : ({Math.Round(_impedancies[i].Imaginary, 3)})");
            }

            for (var i = 0; i < _impedancies.Count; i++)
            {
                CalculationGridView.Rows.Add(Math.Round(_frequencies[i], 3),
                    listImpedances[i]);
            }
        }

        /// <summary>
        ///     Action when clicking "Close"
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}