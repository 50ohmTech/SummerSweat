using System;
using System.Numerics;
using Model.ComboBoxType;
using Model.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Базовый элемент эл. элементов
    /// </summary>
    public abstract class ElementBase
    {
        #region Protected

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

        #endregion

        #region Public

        /// <summary>
        ///     Возвращает символ номинала
        /// </summary>
        /// <returns>Обозначение номинала</returns>
        public static string GetSymbol(ElementType elementType)
        {
            switch (elementType)
            {
                case ElementType.Resistor:
                    return "R";
                case ElementType.Inductor:
                    return "L";
                case ElementType.Capacitor:
                    return "C";
                default:
                    return null;
            }
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
                    (Name, oldValue, _value));
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

        #endregion

        #region Private

        /// <summary>
        ///     Имя
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        #endregion
    }
}