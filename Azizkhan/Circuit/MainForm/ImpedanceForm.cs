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
                //TODO: использовать пустые кавычки неправильно. Заменить на константу из класса string
                //+
                if (StartTextBox.Text == string.Empty ||
                    FinishTextBox.Text == string.Empty ||
                    StepTextBox.Text == string.Empty)
                {
                    MessageBox.Show(
                        "Вы заполнили не все значения! Заполните всё и попробуйте ещё раз!");

                    return;
                }


                if (!FormTools.IsCorrectInterval(StartTextBox, FinishTextBox,
                    StepTextBox))
                {
                    return;
                }

                var start = Convert.ToDouble(StartTextBox.Text);
                var finish = Convert.ToDouble(FinishTextBox.Text);
                var step = Convert.ToDouble(StepTextBox.Text);

                //TODO: Всё? Замёл следы ворованного кода? Думаешь, никто не заметит?
                //А.А. сам сказал исправить это всё.
                var frequencies = new List<double>();
                if (Math.Abs(start - finish) < CheckFrequency.MIN_FREQUENCY && step == 0)
                {
                    frequencies[0] = start;
                }
                else
                {
                    //TODO: циклы по double - неправильно. Переделать на int, иначе страдает читаемость кода
                    //Тогда мы потеряем часть значений. Не могу этого сделать
                    for (var i = start; i <= finish; i += step)
                    {
                        frequencies.Add(i);
                    }
                }


                var impedances = Circuit.CalculateZ(frequencies.ToArray());
                var correctListOfImpedances = new List<string>();

                for (var i = 0; i < impedances.Count; i++)
                {
                    //TODO: Надо использовать не Round, а ToString() с форматной строкой,
                    // Иначе не отображаются комплексные значения меньше 1е-3
                    //+
                    correctListOfImpedances.Add(
                        $"R:{impedances[i].Real:##.#####} " +
                        $"I:{impedances[i].Imaginary:##.#####}");
                }

                for (var i = 0; i < impedances.Count; i++)
                {
                    //TODO: аналогично
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
                    e.Cancel = !double.TryParse(textBox.Text, out var checkedValue);
                    if (!e.Cancel)
                    {
                        e.Cancel = checkedValue <=
                                   CheckFrequency.MIN_FREQUENCY ||
                                   checkedValue >=
                                   CheckFrequency.MAX_FREQUENCY;
                    }

                    textBox.ForeColor = e.Cancel ? Color.Red : Color.Black;
                    if (e.Cancel)
                    {
                        FormTools.ShowError(textBox);

                        //TODO: аналогично
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
                    e.Cancel = !double.TryParse(textBox.Text, out _);
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

        //TODO: зачем поле, если есть свойство?
        //убрал
    }
}