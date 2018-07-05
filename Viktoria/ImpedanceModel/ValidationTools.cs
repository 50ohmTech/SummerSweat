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
        ///     Проверка на корректность введенных чисел относительно допустимого диапазона значений частот
        /// </summary>
        public static void IsCorrectFrequency(double value)
        {
            if (value > 1000000000000 || value < 0.001)
            {
                throw new ArgumentException("Введенные данные выходят за допустимый диапазон значений. \nЗначение не может быть: \n- меньше 0,001 \n- больше 1000000000000.");
            }
        }

        /// <summary>
        ///     Проверка на корректность введенных чисел относительно допустимого диапазона значений параметров пассивных элементов
        /// </summary>
        public static void IsCorrectParameter(double value)
        {
            if (value > 100000 || value < 0.001)
            {
                throw new ArgumentException("Введенные данные выходят за допустимый диапазон значений. \nЗначение не может быть: \n- меньше 0,001 \n- больше 100000.");
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
        #endregion
    }
}