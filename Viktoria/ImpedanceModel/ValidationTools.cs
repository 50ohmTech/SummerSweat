using System;
using System.Windows.Forms;

namespace ImpedanceModel
{
    /// <summary>
    ///     Класс, проверяющий корректность значений, введенных пользователем
    /// </summary>
    public static class ValidationTools
    {
        #region -- Закрытые поля --

        /// <summary>
        ///     Максимальное значение частоты
        /// </summary>
        private static readonly double maxFrequencyValue = 1000000000000;

        /// <summary>
        ///     Минимальное значение частоты
        /// </summary>
        private static readonly double minFrequencyValue = 0.001;

        /// <summary>
        ///     Минимальное значение шага
        /// </summary>
        private static readonly double minStepValue = 0.001;

        /// <summary>
        ///     Максимальное значение шага
        /// </summary>
        private static readonly double maxStepValue = 1000;

        /// <summary>
        ///     Минимальное значение параметра элемента
        /// </summary>
        private static readonly double minElementValue = 0.001;

        /// <summary>
        ///     Максимальное значение параметра элемента
        /// </summary>
        private static readonly double maxElementValue = 100000;

        #endregion

        #region -- Публичные статические методы --

        /// <summary>
        ///     Проверка на корректность введенных чисел относительно
        ///     допустимого диапазона значений частот
        /// </summary>
        public static void IsCorrectFrequency(double value)
        {
            if (value > maxFrequencyValue || value < minFrequencyValue)
            {
                throw new ArgumentException(
                    "Введенные данные выходят за допустимый диапазон значений. " +
                    "\nЗначение частоты не может быть:\n- меньше " + minFrequencyValue +
                    "\n- больше " + maxFrequencyValue);
            }
        }

        /// <summary>
        ///     Проверка на корректность введенных чисел относительно
        ///     допустимого шага
        /// </summary>
        public static void IsCorrectStep(double value)
        {
            if (value < minStepValue || value > maxStepValue)
            {
                throw new ArgumentException(
                    "Введенные данные выходят за допустимый диапазон значений. " +
                    "\nЗначение шага не может быть:\n-меньше " + minStepValue +
                    "\n-больше " + maxStepValue);
            }
        }

        /// <summary>
        ///     Проверка на корректность введенных чисел относительно допустимого
        ///     диапазона значений параметров пассивных элементов
        /// </summary>
        public static void IsCorrectParameter(double value)
        {
            if (value > maxElementValue || value < minElementValue)
            {
                throw new ArgumentException(
                    "Введенные данные выходят за допустимый диапазон значений. " +
                    "\nЗначение не может быть: \n- меньше " + minElementValue +
                    " \n- больше " + maxElementValue);
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