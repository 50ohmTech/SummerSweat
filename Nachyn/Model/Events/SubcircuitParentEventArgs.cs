using System;
using Model.Elements;

namespace Model.Events
{
    /// <summary>
    ///     Аргументы события на изменение родителя.
    /// </summary>
    public class SubcircuitParentEventArgs
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Сообщение.
        /// </summary>
        private string _message;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Новое значение.
        /// </summary>
        public ICircuitNode Parent { get; }

        /// <summary>
        ///     Сообщение.
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

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="parent">Родитель</param>
        public SubcircuitParentEventArgs(string message, ICircuitNode parent)
        {
            Message = message;
            Parent = parent;
        }

        #endregion
    }
}