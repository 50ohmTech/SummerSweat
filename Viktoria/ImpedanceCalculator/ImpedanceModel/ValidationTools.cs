using System;

namespace ImpedanceModel
{
    /// <summary>
    ///     Класс, проверяющий корректность значений, введенных пользователем
    /// </summary>
    public static class ValidationTools
    {
        #region Static fields

        /// <summary>
        ///     Максимальное значение параметра элемента
        /// </summary>
        private static readonly double maxElementValue = 100000;

        /// <summary>
        ///     Максимальное значение частоты
        /// </summary>
        private static readonly double maxFrequencyValue = 1000000000000;

        /// <summary>
        ///     Максимальное значение шага
        /// </summary>
        private static readonly double maxStepValue = 1000;

        /// <summary>
        ///     Минимальное значение параметра элемента
        /// </summary>
        private static readonly double minElementValue = 0.001;

        /// <summary>
        ///     Минимальное значение частоты
        /// </summary>
        private static readonly double minFrequencyValue = 0.001;

        /// <summary>
        ///     Минимальное значение шага
        /// </summary>
        private static readonly double minStepValue = 0.001;

        #endregion

        #region Public methods

        /// <summary>
        ///     Проверка на корректность введенных чисел относительно допустимого
        ///     диапазона значений параметров пассивных элементов
        /// </summary>
        public static void IsCorrectValue(double value)
        {
            if (value > maxElementValue || value < minElementValue)
            {
                throw new ArgumentException(
                    "Введенные данные выходят за допустимый диапазон значений. " +
                    "\nЗначение не может быть: \n- меньше " + minElementValue +
                    " \n- больше " + maxElementValue);
            }
        }

        #endregion
    }
}