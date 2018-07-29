using System;

namespace Model
{
    /// <summary>
    /// Аргументы события Changed.
    /// </summary>
    public class ChangedEventArgs : EventArgs
    {
        #region - - Поля - -

        private ElementBase _element;

        #endregion

        #region – – Свойства – –

        /// <summary>
        /// Тип изменения.
        /// </summary>
        public ChangeType Type { get; }

        /// <summary>
        /// Добавленный элемент.
        /// </summary>
        public ElementBase Element
        {
            get => _element;
            private set => _element = value ?? throw new ArgumentNullException(nameof(value));
        }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса ChangedEventArgs.
        /// </summary>
        /// <param name="element">Изменяемый элемент.</param>
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

