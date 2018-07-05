using System;
using System.Numerics;
using Model.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Базовый элемент эл. элементов
    /// </summary>
    public abstract class ElementBase
    {
        /// <summary>
        ///     Имя
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        protected ElementBase(string name, double value = 0)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        ///     Имя элемента
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name));
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Номинал
        /// </summary>
        public double Value
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                double oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueEventArgs
                    ("Изменил(ось/ась/ся) " + ToString(), oldValue, _value));
            }
            get => _value;
        }

        /// <summary>
        ///     Событие на изменение номинала
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        /// <summary>
        ///     Расчитать комплексное сопротивление
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);
    }
}