using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitModel;
using System.Numerics;

/// <summary>
/// Форма расчета комплексного сопротивления цепи.
/// </summary>
namespace MainForm
{
    public partial class ImpedanceForm : Form
    {

        #region ~ Переменные только для чтения ~

        /// <summary>
        /// Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="circuit"> Цепь. </param>
        public ImpedanceForm(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;

            StartValueTextBox.ContextMenu = new ContextMenu();
            StepValueTextBox.ContextMenu = new ContextMenu();
            EndValueTextBox.ContextMenu = new ContextMenu();
        }

        #endregion

        #region ~ Приватные методы ~
        /// <summary>
        /// Событие, срабатывающее при закрытии окна.
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Вычисление комплексного сопротивления для всех элементов.
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
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
                correctListOfImpedances.Add($"R:{Math.Round(impedances[i].Real, 3)} " +
                    $"I:{Math.Round(impedances[i].Imaginary, 3)}");
            }

            for (var i = 0; i < impedances.Count; i++)
            {
                dataGridView.Rows.Add(Math.Round(frequency[i], 3),
                    correctListOfImpedances[i]);
            }
        }

        /// <summary>
        /// Подготавливает поле к вводу.
        /// </summary>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ValueValidators.Enter(sender);
        }

        /// <summary>
        /// Подготавливает поле к выводу.
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ValueValidators.Leave(sender);
        }

        /// <summary>
        /// Для ограничения ввода символов в текстбокс для double.
        /// </summary>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressDouble(e, ((TextBox)sender).Text);
        }

        /// <summary>
        /// Для ограничения ввода символов в текстбокс для int .
        /// </summary>
        private void IntTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressInt(sender, e);
        }

        #endregion
    }
}
