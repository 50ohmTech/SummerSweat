using System;

namespace Model
{
    /// <summary>
    /// Аргументы события Changed.
    /// </summary>
    public class ChangedEventArgs : EventArgs
    {
        #region - - Перечисления - -

        /// <summary>
        /// Возможные изменения.
        /// </summary>
        public enum ChangeType
        {
            Add,
            Delete,
            Clear
        }

        #endregion

        #region – – Свойства – –

        /// <summary>
        /// Тип изменения.
        /// </summary>
        public ChangeType Type { get; }

        /// <summary>
        /// Добавленный элемент.
        /// </summary>
        public ElementBase Element { get; }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса ChangedEventArgs.
        /// </summary>
        /// <param name="element">Добавляемый элемент.</param>
        /// <param name="type">Тип изменения.</param>
        public ChangedEventArgs(ElementBase element, ChangeType type)
        {
            Element = element;
            Type = type;
        }

        /// <summary>
        /// Конструктор класса ChangedEventArgs.
        /// </summary>
        /// <param name="type">Тип изменения.</param>
        public ChangedEventArgs(ChangeType type)
        {
            Type = type;
        }

        #endregion
    }
}

