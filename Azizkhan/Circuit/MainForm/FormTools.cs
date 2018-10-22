﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CircuitView
{
    internal class FormTools
    {
        #region Public methods

        /// <summary>
        ///     Метод проверки введёного в TextBox значения
        ///     на корректность для Convert.ToDouble
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool CheckStringForDouble(string text)
        {
            if (text == null)
            {
                return true;
            }

            return Regex.IsMatch(text, @"^([0-9]*|[0-9]*[,][0-9]*)$");
        }

        /// <summary>
        ///     Проверка ввода корректного Double в TextBox
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="e"></param>
        public static void TextBoxCheck(TextBox textBox, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = !CheckStringForDouble(textBox.Text);
                e.Cancel = (Convert.ToDouble(textBox.Text) <= 0.1 || Convert.ToDouble(textBox.Text) >= 1e12);


                textBox.ForeColor = e.Cancel ? Color.Red : Color.Black;
                if (e.Cancel)
                {
                    MessageBox.Show(
                        "Введённое значение не соответствует правильному формату или не находится в диапазоне допустимых значений!");
                }
            }
        }

        #endregion
    }
}