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
        private double _value;

        #endregion

        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Сообщение</param>
        /// <param name="value">Новое значение</param>
        public ElementValueEventArgs(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        ///     Новое значение
        /// </summary>
        public double Value
        {
            set
            {
                if (_value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _value = value;
            }
            get => _value;
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