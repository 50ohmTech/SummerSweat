using System;

namespace CircuitLibrary.Events
{
    /// <summary>
    ///     Класс для обработчика события SubcircuitChanged.
    /// </summary>
    public class SubcircuitChangedEventArgs : EventArgs
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Сообщение
        /// </summary>
        private string _message;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Новый родитель
        /// </summary>
        public INode Parent { get; }

        /// <summary>
        ///     Вернуть/установить сообщение
        /// </summary>
        public string Message
        {
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Message));
                }

                _message = value;
            }
            get => _message;
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="parent">Родитель</param>
        public SubcircuitChangedEventArgs(string message, INode parent)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
        }

        #endregion
    }
}