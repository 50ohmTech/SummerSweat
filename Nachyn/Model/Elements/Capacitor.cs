using System;
using System.Numerics;
using Model.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    public class Capacitor : IElement
    {
        /// <summary>
        /// Описание ошибки с именем
        /// </summary>
        private const string _nameError = "Имя не может быть пустым";

        private const string _capacitorError = "Емкость не может быть отрицательная";

        /// <summary>
        ///     Имя элемента
        /// </summary>
        private string _name;

        /// <summary>
        ///     (C) емкость
        /// </summary>
        private double _value;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="capacity">Емкость</param>
        public Capacitor(string name, double capacity = 0)
        {
            Name = name;
            Value = capacity;
            
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
                    throw new ArgumentOutOfRangeException(_nameError);
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Возвращает и задает (C) емкость
        /// </summary>
        public double Value
        {
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(_capacitorError);
                }

                var oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueArgs
                    ("Изменилась емкость (L)", oldValue, _value));
            }
            get => _value;
        }

        /// <summary>
        ///     Обработчик события на изменение номинала
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public Complex CalculateZ(double frequency)
        {
            var valueZ = 1 / (2 * Math.PI * frequency * _value);
            return new Complex(0, valueZ);
        }
    }
}