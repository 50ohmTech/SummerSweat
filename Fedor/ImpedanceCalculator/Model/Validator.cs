using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
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
        /// <param name="frequncies">Частоты.</param>
        /// <exception cref="ArgumentException">Выбрасывает если частоты вне диапазона от 1 Гц. до 1Тгц.</exception>
        public static void CheckFrequencies(List<double> frequncies)
        {
            if (frequncies.Any(frequency => frequency < _minValue || frequency > _maxValue))
            {
                throw new ArgumentException(
                    "Частота может принимать значение только от 1 Гц. до 1 ТГц..");
            }
        }

        #endregion
    }
}
