using System;

namespace Model.Events
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

        /// <summary>
        ///     Старое значение
        /// </summary>
        private double _oldValue;

        #endregion

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
        public double OldValue
        {
            set
            {
                Calculations.Calculations.CheckFrequencies(value);
                _oldValue = value;
            }
            get => _oldValue;
        }

        /// <summary>
        ///     Новое значение
        /// </summary>
        public double NewValue
        {
            set
            {
                Calculations.Calculations.CheckFrequencies(value);
                _newValue = value;
            }
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