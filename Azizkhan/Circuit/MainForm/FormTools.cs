using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CircuitLibrary.Elements;

namespace CircuitView
{
    internal class FormTools
    {
        #region Public methods

        /// <summary>
        ///     Метод проверки введёного в TextBox значения
        ///     на корректность для Convert.ToDouble
        /// </summary>
        /// <param name="text">TextBox, откуда тащим информацию</param>
        /// <returns>Соответствует ли строка типу Double</returns>
        public static bool CheckStringForDouble(string text)
        {
            if (text == null)
            {
                return true;
            }

            return Regex.IsMatch(text, @"^([0-9]*|[0-9]*[,][0-9]*)$");
        }

        /// <summary>
        ///     Проверка строки на вхождение корректных значений для номинала элемента
        /// </summary>
        /// <param name="value">Строка - номинал элемента</param>
        /// <returns>Соответствует ли строка корректному значению номинала элемента</returns>
        public static bool CheckCorrectValue(string value)
        {
            if (CheckStringForDouble(value))
            {
                return !(Convert.ToDouble(value) <= ElementBase.MINVALUE ||
                         Convert.ToDouble(value) >= ElementBase.MAXVALUE);
            }

            return false;
        }

        /// <summary>
        ///     Проверка ввода корректного Double в TextBox
        /// </summary>
        /// <param name="textBox">TextBox, откуда тащим информацию</param>
        /// <param name="e">Критерий для отмены события</param>
        public static void TextBoxCheck(TextBox textBox, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = !CheckStringForDouble(textBox.Text);
                if (!e.Cancel)
                {
                    e.Cancel = Convert.ToDouble(textBox.Text) <= ElementBase.MINVALUE ||
                               Convert.ToDouble(textBox.Text) >= ElementBase.MAXVALUE;
                }

                textBox.ForeColor = e.Cancel ? Color.Red : Color.Black;
                if (e.Cancel)
                {
                    ShowError(textBox);
                    textBox.Text = "";
                }
            }
        }

        /// <summary>
        ///     Вывод ошибки
        /// </summary>
        /// <param name="textBox">куда вводятся значения</param>
        public static void ShowError(TextBox textBox)
        {
            MessageBox.Show(
                "Вы ввели: \"" + textBox.Text + "\"\n" +
                "Вводимое значение должно удовлетворять следующим условиям:\n " +
                "-быть положительным числом\n " +
                "-быть вещественным или натуральным числом\n " +
                "-быть большим 0,1 по модулю\n " +
                "-быть меньше 1e12 (1000000000000)\n " +
                "-запись не должна содержать пробелов\n " +
                "-запись должна начинаться с цифры\n " +
                "-использование экспоненциальной записи не допускается.",
                "Ошибка ввода значения частоты", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        ///     Проверка корректных значений начала и конца интервала
        /// </summary>
        /// <param name="startTextBox">начало интервала</param>
        /// <param name="finishTextBox">конец интервала</param>
        public static void IsCorrectStartFinish(TextBox startTextBox,
            TextBox finishTextBox)
        {
            if (startTextBox.Text.Length != 0 && finishTextBox.Text.Length != 0)
            {
                if (double.Parse(startTextBox.Text) > double.Parse(finishTextBox.Text))
                {
                    MessageBox.Show("Начало должно быть меньше границы!");
                    startTextBox.Text = null;
                    finishTextBox.Text = null;
                }
            }
        }

        /// <summary>
        ///     Проверка корректного значения шага
        /// </summary>
        /// <param name="startTextBox">Начало интервала</param>
        /// <param name="finishTextBox">Конец интервала</param>
        /// <param name="stepTextBox">Шаг</param>
        public static void IsCorrectStep(TextBox startTextBox, TextBox finishTextBox,
            TextBox stepTextBox)
        {
            if (startTextBox.Text.Length != 0 && finishTextBox.Text.Length != 0 &&
                stepTextBox.Text.Length != 0)
            {
                if (double.Parse(finishTextBox.Text) - double.Parse(startTextBox.Text) <
                    double.Parse(stepTextBox.Text))
                {
                    MessageBox.Show(
                        "Разница между началом и концов по модулю не может быть меньше шага!");

                    startTextBox.Text = null;
                    finishTextBox.Text = null;
                    stepTextBox.Text = null;
                }
            }
        }

        #endregion
    }
}