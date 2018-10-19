using System;

namespace Model.Events
{
    /// <summary>
    ///     Класс для обработчика события ValueChanged.
    /// </summary>
    public class ElementEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        ///     Новое значение.
        /// </summary>
        public double Value
        {
            get => _value;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                _value = value;
            }
        }

        /// <summary>
        ///     Сообщение.
        /// </summary>
        public string Message
        {
            get => _message;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Message));
                }

                _message = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="value">Новое значение.</param>
        public ElementEventArgs(string message, double value)
        {
            Value = value;
            Message = message;
        }

        #endregion

        #region Fields

        #region Private fields

        /// <summary>
        ///     Сообщение.
        /// </summary>
        private string _message;

        /// <summary>
        ///     Новое значение.
        /// </summary>
        private double _value;

        #endregion

        #endregion
    }
}