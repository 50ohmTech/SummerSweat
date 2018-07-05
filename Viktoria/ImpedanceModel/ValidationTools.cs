using System;
using System.Windows.Forms;

namespace ImpedanceModel
{
    /// <summary>
    ///     Класс, проверяющий корректность значений, введенных пользователем
    /// </summary>
    public static class ValidationTools
    {
        #region -- Публичные статические методы --

        /// <summary>
        ///     Проверка на корректность ввода вещественных чисел
        /// </summary>
        public static void IsDouble(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException(
                    "Данные не являются вещественным числом.");
            }
        }

        /// <summary>
        ///     Проверка на корректность ввода данных типа double в textBox
        /// </summary>
        public static void IsDouble(TextBox textBox)
        {
            if (!double.TryParse(textBox.Text, out var result))
            {
                throw new ArgumentException(
                    "Введенные данные не являются вещественным числом.");
            }
        }

        /// <summary>
        ///     Проверка на пустоту textBox
        /// </summary>
        public static void IsEmpty(TextBox textBox)
        {
            if (textBox.Text == string.Empty)
            {
                throw new ArgumentException("Требуется полное заполенение полей");
            }
        }

        /// <summary>
        ///     Проверка на корректность ввода данных, которые должны быть строго больше нуля
        /// </summary>
        public static void IsLessThenNull(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "Значение параметра не может быть меньше 0");
            }
        }

        #endregion
    }
}