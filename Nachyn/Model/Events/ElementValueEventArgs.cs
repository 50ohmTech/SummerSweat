using System;

namespace Model.Events
{
    /// <summary>
    ///     Класс для обработчика события ValueChanged
    /// </summary>
    public class ElementValueEventArgs : EventArgs
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="oldValue">Старое значение</param>
        /// <param name="newValue">Новое значение</param>
        public ElementValueEventArgs(string message, double oldValue, double newValue)
        {
            Message = message;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        ///     Старое значение
        /// </summary>
        public double OldValue { get; }

        /// <summary>
        ///     Новое значение
        /// </summary>
        public double NewValue { get; }

        /// <summary>
        ///     Сообщение
        /// </summary>
        public string Message { get; }
    }
}