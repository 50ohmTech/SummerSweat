using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CircuitLibrary;
using CircuitLibrary.Elements;

namespace CircuitView
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
                if (!FormTools.IsCorrectInterval(StartTextBox, FinishTextBox,
                    StepTextBox))
                {
                    return;
                }

                var start = Convert.ToDouble(StartTextBox.Text);
                var finish = Convert.ToDouble(FinishTextBox.Text);
                var step = Convert.ToDouble(StepTextBox.Text);

                var frequencies = new List<double>();
                if (Math.Abs(start - finish) < CheckFrequency.MIN_FREQUENCY && step == 0)
                {
                    frequencies[0] = start;
                }
                else
                {
                    for (var i = start; i <= finish; i += step)
                    {
                        frequencies.Add(i);
                    }
                }


                var impedances = _circuit.CalculateZ(frequencies.ToArray());
                var correctListOfImpedances = new List<string>();

                for (var i = 0; i < impedances.Count; i++)
                {
                    correctListOfImpedances.Add(
                        $"R:{Math.Round(impedances[i].Real, 3)} " +
                        $"I:{Math.Round(impedances[i].Imaginary, 3)}");
                }

                for (var i = 0; i < impedances.Count; i++)
                {
                    impedancesGridView.Rows.Add(Math.Round(frequencies[i], 3),
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
            impedancesGridView.Rows.Clear();
            CalculateImpedance();
        }

        private void FrequencyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    e.Cancel = !FormTools.CheckStringForDouble(textBox.Text);
                    if (!e.Cancel)
                    {
                        e.Cancel = Convert.ToDouble(textBox.Text) <=
                                   CheckFrequency.MIN_FREQUENCY ||
                                   Convert.ToDouble(textBox.Text) >=
                                   CheckFrequency.MAX_FREQUENCY;
                    }

                    textBox.ForeColor = e.Cancel ? Color.Red : Color.Black;
                    if (e.Cancel)
                    {
                        FormTools.ShowError(textBox);
                        textBox.Text = "";
                    }
                }
            }
        }

        private void StepTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    e.Cancel = !FormTools.CheckStringForDouble(textBox.Text);
                    textBox.ForeColor = e.Cancel ? Color.Red : Color.Black;
                    if (e.Cancel)
                    {
                        MessageBox.Show(
                            "Вы ввели: \"" + textBox.Text + "\"\n" +
                            "Вводимое значение должно удовлетворять следующим условиям:\n " +
                            "-быть положительным числом\n " +
                            "-быть вещественным или натуральным числом\n " +
                            "-запись не должна содержать пробелов\n " +
                            "-запись должна начинаться с цифры\n " +
                            "-использование экспоненциальной записи не допускается.",
                            "Ошибка ввода значения частоты", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        textBox.Text = "";
                    }
                }
            }
        }

        #endregion
    }
}