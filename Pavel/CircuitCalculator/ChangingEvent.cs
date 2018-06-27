using System;

namespace CircuitCalculator
{
    public class ChangingEvent:EventArgs
    {
        #region Свойства

        /// <summary>
        /// Измененный номинал
        /// </summary>
        public double Value { get; }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса ChangedEventArgs.
        /// </summary>
        /// <param name="value"> Новое номинал. </param>
        public ChangingEvent(double value)
        {
            Value = value;
        }

        #endregion
    }
}

