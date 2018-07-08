using System;

namespace Model.Events
{
    /// <summary>
    ///     Класс для обработчика события ValueChanged
    /// </summary>
    public class ElementValueEventArgs : EventArgs
    {
        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Сообщение</param>
        /// <param name="oldValue">Старое значение</param>
        /// <param name="newValue">Новое значение</param>
        public ElementValueEventArgs(string name, double oldValue, double newValue)
        {
            Name = name;
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
        public string Name { get; }

        #endregion
    }
}