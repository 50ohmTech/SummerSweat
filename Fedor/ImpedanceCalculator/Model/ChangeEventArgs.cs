
using System;
using System.Collections.Generic;
namespace Model
{
    /// <summary>
    /// Аргументы события Changed.
    /// </summary>
    public class ChangedEventArgs : EventArgs
    {
        #region - - Свойства - -

        /// <summary>
        /// Новое значение.
        /// </summary>
        public double Value { get; }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса ChangedEventArgs.
        /// </summary>
        /// <param name="value">Новое значение.</param>
        public ChangedEventArgs(double value)
        {
            Value = value;
        }

        #endregion
    }
}

