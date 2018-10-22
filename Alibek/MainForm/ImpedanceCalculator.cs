using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ElementsLibrary;

namespace MainForm
{
    /// <summary>
    /// Форма под калькулятор
    /// </summary>
    public partial class ImpedanceCalculator : Form
    {
        #region Readonly fields

        /// <summary>
        /// Цепь
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="circuit"></param>
        public ImpedanceCalculator(Circuit circuit)
        {
            InitializeComponent();
            StartValueTextBox.ContextMenu = new ContextMenu();
            StepValueTextBox.ContextMenu = new ContextMenu();
            EndValueTextBox.ContextMenu = new ContextMenu();
            _circuit = circuit;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Функция для подсчета
        /// </summary>
        private void CalculateImpedance()
        {
            ValueValidators.ChangeSeparator(StartValueTextBox);
            ValueValidators.ChangeSeparator(StepValueTextBox);
            ValueValidators.ChangeSeparator(EndValueTextBox);

            var start = double.Parse(StartValueTextBox.Text);
            var step = double.Parse(StepValueTextBox.Text);
            var finish = uint.Parse(EndValueTextBox.Text);

            if (!ValueValidators.IsCorrectFrequency(start, step, finish))
            {
                return;
            }

            double[] frequency = new double[1];

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
                correctListOfImpedances.Add(  $"R:{Math.Round(impedances[i].Real, 3)} " +
                    $"I:{Math.Round(impedances[i].Imaginary, 3)}");
            }

            for (var i = 0; i < impedances.Count; i++)
            {
                CalculatorDataGridView.Rows.Add(Math.Round(frequency[i], 3),
                    correctListOfImpedances[i]);
            }
        }

        /// <summary>
        /// Кнопка для расчета импеданса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateImpedance();
        }

        /// <summary>
        /// Событие подготавливающие поле к вводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ValueValidators.Enter(sender);
        }

        /// <summary>
        /// Событие подготавливающие поле к выводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ValueValidators.Leave(sender);
        }

        /// <summary>
        /// Собыите для ограничения ввода символов в текстбокс для double.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressDouble(e, ((TextBox)sender).Text);
        }

        /// <summary>
        /// Собыите для ограничения ввода символов в текстбокс для int .
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void IntTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressInt(sender, e);
        }
        #endregion
    }
}