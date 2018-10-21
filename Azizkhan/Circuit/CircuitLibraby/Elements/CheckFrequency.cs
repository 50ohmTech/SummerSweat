using System;

namespace CircuitLibrary.Elements
{
    /// <summary>
    ///     Проверка частот
    /// </summary>
    internal class CheckFrequency
    {
        #region Constants

        /// <summary>
        ///     Максимальное значение частоты  = 1 ТГц
        /// </summary>
        public const double MAX_FREQUENCY = 1000000000000;

        /// <summary>
        ///     Минимальное значение частоты = 1 Гц
        /// </summary>
        public const double MIN_FREQUENCY = 1;

        #endregion

        #region Public methods

        /// <summary>
        ///     Проверить входные частоты на валидность
        /// </summary>
        /// <param name="frequencies">Частоты</param>
        /// <exception cref="ArgumentException">Исключение, в случае частот вне диапазона от 1 Гц. до 1Тгц.</exception>
        public static void CheckFrequencies(params double[] frequencies)
        {
            foreach (var frequency in frequencies)
            {
                if (frequency < MIN_FREQUENCY || frequency > MAX_FREQUENCY)
                {
                    throw new ArgumentException(
                        "Частота должна быть в пределах от 1 Гц. до 1 ТГц..");
                }
            }
        }

        #endregion
    }
}