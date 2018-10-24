using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CircuitLibrary.Elements;

namespace CircuitView
{
    //TODO: в каждом методе один и тот же текст постоянно конвертируется в double.
    // Исправить, чтобы число конвертировалось только один раз, а затем проходило проверки и валидации
    internal class FormTools
    {
        #region Public methods

        //TODO: избавиться от этого метода, заменить на использование double.TryParse или double.Parse
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

        //TODO: метод называется Check, а по факту занимается сменой цветов и отменой валидации. Неправильно, переделать
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
        {//TODO: а этот сворованный кусок сообщения почему не подчистил? Это сообщение тоже по всем репозиториям ходит
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
            if (start.Text.Length != 0 && finish.Text.Length != 0 &&
                step.Text.Length != 0)
            {
                if (CheckStringForDouble(start.Text) &&
                    CheckStringForDouble(finish.Text) &&
                    CheckStringForDouble(step.Text))
                {
                    if (Convert.ToDouble(finish.Text) - Convert.ToDouble(start.Text) <
                        0 && Convert.ToDouble(finish.Text) -
                        Convert.ToDouble(start.Text) < Convert.ToDouble(step.Text))
                    {
                        MessageBox.Show(
                            "Интервал задан не верно!");

                        start.Text = finish.Text = step.Text = "";
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}