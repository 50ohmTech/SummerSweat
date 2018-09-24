using System;
using Model.Elements;

namespace Model.Events
{
    /// <summary>
    ///     Аргументы события на изменение родителя.
    /// </summary>
    public class SubcircuitEventArgs
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

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="parent">Родитель</param>
        public SubcircuitEventArgs(string message, INode parent)
        {
            Message = message;
            Parent = parent;
        }

        #endregion
    }
}