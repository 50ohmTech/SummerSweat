using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CircuitLibrary.Elements;

namespace CircuitView
{
    //TODO: в каждом методе один и тот же текст постоянно конвертируется в double.
    // Исправить, чтобы число конвертировалось только один раз, а затем проходило проверки и валидации
    //+
    internal class FormTools
    {
        #region Public methods

        //TODO: избавиться от этого метода, заменить на использование double.TryParse или double.Parse
        //+

        /// <summary>
        ///     Проверка строки на вхождение корректных значений для номинала элемента
        /// </summary>
        /// <param name="value">Строка - номинал элемента</param>
        /// <returns>Соответствует ли строка корректному значению номинала элемента</returns>
        public static bool CheckCorrectValue(string value)
        {
            if (double.TryParse(value, out var checkValue))
            {
                return !(checkValue <= ElementBase.MINVALUE ||
                         checkValue >= ElementBase.MAXVALUE);
            }

            return false;
        }

        //TODO: метод называется Check, а по факту занимается сменой цветов и отменой валидации. Неправильно, переделать
        //+
        /// <summary>
        ///     Проверка ввода корректного Double в TextBox
        /// </summary>
        /// <param name="textBox">TextBox, откуда тащим информацию</param>
        /// <param name="e">Критерий для отмены события</param>
        public static void TextBoxValidation(TextBox textBox, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = !CheckCorrectValue(textBox.Text);


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
            //TODO: а этот сворованный кусок сообщения почему не подчистил? Это сообщение тоже по всем репозиториям ходит
            //потому что это удобный метод, который по-другому не написать, либо написать,
            //но по сути ничего не поменяется, кроме внутреннего текста.
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
        ///     Проверка корректных значений введённых в три текстбокса
        /// </summary>
        /// <param name="start">Начало интервала</param>
        /// <param name="finish">Конец интервала</param>
        /// <param name="step">Шаг</param>
        public static bool IsCorrectInterval(TextBox start,
            TextBox finish, TextBox step)
        {
            if (start.Text.Length == 0 || finish.Text.Length == 0 ||
                step.Text.Length == 0)
            {
                return false;
            }

            if (!double.TryParse(start.Text, out var startValue) ||
                !double.TryParse(finish.Text, out var finishValue) ||
                !double.TryParse(step.Text, out var stepValue))
            {
                return false;
            }

            if (!(finishValue - startValue <
                  0) || !(finishValue -
                          startValue < stepValue))
            {
                return true;
            }

            MessageBox.Show(
                "Интервал задан не верно!");

            start.Text = finish.Text = step.Text = "";
            return false;
        }

        #endregion
    }
}