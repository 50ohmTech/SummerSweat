using System;

namespace CircuitModel
{
    public class ChangingEventArgs:EventArgs
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
        public ChangingEventArgs(double value)
        {
            Value = value;
        }

        #endregion
    }
}

