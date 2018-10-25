using System;

namespace CircuitModel
{
    /// <summary>
    /// Класс обработчика события ValueChanged.
    /// </summary>
     public class ValueEventArgs : EventArgs
     {
        #region ~ Переменные ~

        /// <summary>
        /// Сообщение.
        /// </summary>
        private string _message;

        /// <summary>
        /// Новое значение элемента.
        /// </summary>
        private double _value;

        #endregion

        #region ~ Свойства ~

        /// <summary>
        /// Получает сообщение.
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

        /// <summary>
        /// Принимает и возвращает новое значение элемента.
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

        #endregion

        #region ~ Конструктор класса ~

        /// <summary>
        /// Конструктор класса ValueEventArgs.
        /// </summary>
        /// <param name="message"> Сообщение. </param>
        /// <param name="value"> Новое значение. </param>
        public ValueEventArgs(string message, double value)
        {
            Message = message;
            Value = value;
        }

        #endregion
     }
}
