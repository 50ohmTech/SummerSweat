using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Validators
{
    /// <summary>
    /// Проверки.
    /// </summary>
    public static class Validator
    {
        #region -- Константы --

        /// <summary>
        /// Максимально допустимая частота.
        /// </summary>
        private const double _maxValue = 1000000000000.0;

        /// <summary>
        /// Минимально допустимая частота.
        /// </summary>
        private const double _minValue = 1.0;

        #endregion

        #region -- Публичные статичные методы --

        /// <summary>
        /// Проверить частоты на значения, которые они могут принимать.
        /// </summary>
        /// <param name="frequencies">Частоты.</param>
        public static void CheckFrequencies(List<double> frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            if (frequencies.Any(frequency => frequency < _minValue || frequency > _maxValue))
            {
                throw new ArgumentException(
                    "Частота может принимать значение только от 1 Гц. до 1 ТГц..");
            }
        }

        /// <summary>
        /// Проверить частоту на значения, которые она может принимать.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        public static void CheckFrequency(double frequency)
        {
            if (frequency < _minValue || frequency > _maxValue)
            {
                throw new ArgumentException(
                    "Частота может принимать значение только от 1 Гц. до 1 ТГц..");
            }
        }

        #endregion
    }
}
