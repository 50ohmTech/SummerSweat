using System;
using System.Numerics;
using Model.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    public class Inductor : IElement
    {
        private const string InductorError = "Индуктивность не может быть отрицательная";

        private const string NameError = "Имя не может быть пустым";

        /// <summary>
        ///     Имя элемента
        /// </summary>
        private string _name;

        /// <summary>
        ///     (L) индуктивность
        /// </summary>
        private double _value;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="inductance">Индуктивность</param>
        public Inductor(string name, double inductance = 0)
        {
            Name = name;
            Value = inductance;
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
                    throw new ArgumentOutOfRangeException(NameError);
                _name = value;
            }
        }

        /// <summary>
        ///     Возвращает и задает (L) индуктивность
        /// </summary>
        public double Value
        {
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(InductorError);
                var oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueArgs
                    ("Изменилась индуктивность (L)", oldValue, _value));
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
            var valueZ = 2 * Math.PI * frequency * _value;
            return new Complex(0, valueZ);
        }
    }
}