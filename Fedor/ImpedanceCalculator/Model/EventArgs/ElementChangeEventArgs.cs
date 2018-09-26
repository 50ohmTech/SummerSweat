using System;
using Model.Elements;
using Model.Enums;

namespace Model.EventArgs
{
    //TODO: Название типа данных не описывает изменения чего она отражает
    //+
    /// <summary>
    /// Аргументы события ElementChange.
    /// </summary>
    public class ElementChangeEventArgs : System.EventArgs
    {
        #region - - Поля - -

        private ElementBase _element;

        #endregion

        #region – – Свойства – –

        /// <summary>
        /// Тип изменения.
        /// </summary>
        public ElementsChangeType Type { get; }

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
        /// Конструктор класса ChangeEventArgs.
        /// </summary>
        /// <param name="element">Изменяемый элемент.</param>
        /// <param name="type">Тип изменения.</param>
        public ElementChangeEventArgs(ElementBase element, ElementsChangeType type)
        {
            Element = element;
            Type = type;
        }

        /// <summary>
        /// Конструктор класса ChangeEventArgs.
        /// </summary>
        /// <param name="type">Тип изменения.</param>
        public ElementChangeEventArgs(ElementsChangeType type)
        {
            Type = type;
        }

        #endregion
    }
}

