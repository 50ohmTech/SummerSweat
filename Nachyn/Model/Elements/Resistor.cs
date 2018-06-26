using System;
using System.Numerics;
using Model.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор
    /// </summary>
    public class Resistor : IElement
    {
        private const string NameError = "Имя не может быть пустым";

        private const string ResistorError = "Сопротивление не может быть отрицательным";

        /// <summary>
        ///     Имя элемента
        /// </summary>
        private string _name;

        /// <summary>
        ///     (R) сопротивление
        /// </summary>
        private double _value;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="resistance">Сопротивление</param>
        public Resistor(string name, double resistance = 0)
        {
            Name = name;
            Value = resistance;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Имя элемента
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException
                        (NameError);

                _name = value;
            }
        }

        /// <summary>
        ///     Возвращает и задает (R) сопротивление
        /// </summary>
        public double Value
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(ResistorError);

                var oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueArgs
                    ("Изменилось сопротивление (L)", oldValue, _value));
            }
            get => _value;
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public Complex CalculateZ(double frequency)
        {
            return new Complex(_value, 0);
        }

        /// <summary>
        ///     Обработчик события на изменение номинала
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;
    }
}