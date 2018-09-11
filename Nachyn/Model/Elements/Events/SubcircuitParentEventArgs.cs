using System;

namespace Model.Elements.Events
{
    public class SubcircuitParentEventArgs
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Имя.
        /// </summary>
        private string _message;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Новое значение.
        /// </summary>
        public INode Parent { get; }

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
        public SubcircuitParentEventArgs(string message, INode parent)
        {
            Message = message;
            Parent = parent;
        }

        #endregion
    }
}