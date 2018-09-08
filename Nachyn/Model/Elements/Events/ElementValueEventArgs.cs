using System;

namespace Model.Elements.Events
{
    /// <summary>
    ///     Класс для обработчика события ValueChanged
    /// </summary>
    public class ElementValueEventArgs : EventArgs
    {
        #region Private

        /// <summary>
        ///     Имя
        /// </summary>
        private string _name;

        /// <summary>
        ///     Новое значение
        /// </summary>
        private double _newValue;

        #endregion

        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Сообщение</param>
        /// <param name="newValue">Новое значение</param>
        public ElementValueEventArgs(string name, double newValue)
        {
            Name = name;
            NewValue = newValue;
        }

        /// <summary>
        ///     Новое значение
        /// </summary>
        public double NewValue
        {
            set => _newValue = value;
            get => _newValue;
        }

        /// <summary>
        ///     Сообщение
        /// </summary>
        public string Name
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name));
                }

                _name = value;
            }
            get => _name;
        }

        #endregion
    }
}