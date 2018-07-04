using System;
namespace Model
{
    /// <summary>
    /// Аргументы события Changed.
    /// </summary>
    public class ChangedEventArgs : EventArgs
    {
        #region - - Свойства - -

        /// <summary>
        /// Возможные изменения.
        /// </summary>
        public enum ChangeType
        {
            Add,
            Delete,
            Clear
        }

        /// <summary>
        /// Тип изменения.
        /// </summary>
        public ChangeType Type { get; }

        /// <summary>
        /// Добавленный элемент.
        /// </summary>
        public Element Element { get; }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса ChangedEventArgs.
        /// </summary>
        /// <param name="element">Добавляемый элемент.</param>
        public ChangedEventArgs(Element element, ChangeType type)
        {
            Element = element;
            Type = type;
        }

        public ChangedEventArgs(ChangeType type)
        {
            Type = type;
        }

        #endregion
    }
}

