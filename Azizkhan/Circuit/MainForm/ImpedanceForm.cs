using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CircuitLibrary;
using CircuitView;

namespace MainForm
{
    /// <summary>
    ///     Форма расчёта импедансов
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Поле для цепи.
        /// </summary>
        private Circuit _circuit;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Свойство для цепи.
        /// </summary>
        public Circuit Circuit { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор формы-калькулятора импедансов.
        /// </summary>
        public ImpedanceForm()
        {
            InitializeComponent();
            impedancesGridView.RowHeadersVisible = false;
            calculateButton.Enabled = true;
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Расчёт импедансов.
        /// </summary>
        private void CalculateImpedance()
        {
            try
            {
                if (StartTextBox.Text == "" || FinishTextBox.Text == "" ||
                    StepTextBox.Text == "")
                {
                    MessageBox.Show(
                        "Вы заполнили не все значения! Заполните всё и попробуйте ещё раз!");

                    return;
                }

                _circuit = Circuit;
                FormTools.IsCorrectStartFinish(StartTextBox, FinishTextBox);
                FormTools.IsCorrectStep(StartTextBox, FinishTextBox, StepTextBox);
                var start = Convert.ToDouble(StartTextBox.Text);
                var finish = Convert.ToDouble(FinishTextBox.Text);
                var step = Convert.ToDouble(StepTextBox.Text);

                var frequency = new double[1];

                var j = 0;
                for (var i = start; i <= finish; i += step)
                {
                    frequency[j] = i;
                    j++;
                    if (!(finish - i == 0))
                    {
                        Array.Resize(ref frequency, frequency.Length + 1);
                    }
                }

                if (frequency[frequency.Length - 1] == 0)
                {
                    Array.Resize(ref frequency, frequency.Length - 1);
                }

                var impedances = _circuit.CalculateZ(frequency);
                var correctListOfImpedances = new List<string>();

                for (var i = 0; i < impedances.Count; i++)
                {
                    correctListOfImpedances.Add(
                        $"R:{Math.Round(impedances[i].Real, 3)} " +
                        $"I:{Math.Round(impedances[i].Imaginary, 3)}");
                }

                for (var i = 0; i < impedances.Count; i++)
                {
                    impedancesGridView.Rows.Add(Math.Round(frequency[i], 3),
                        correctListOfImpedances[i]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateImpedance();
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                FormTools.TextBoxCheck(textBox, e);
            }
        }

        #endregion
    }
}