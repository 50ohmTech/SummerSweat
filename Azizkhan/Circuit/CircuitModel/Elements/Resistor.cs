using System;
using System.Numerics;

namespace Circuit
{
    /// <summary>
    ///     Резистор
    /// </summary>
    internal class Resistor : ElementBase
    {
        /// <summary>
        ///     Конструктор сущности Resistor
        /// </summary>
        /// <param name="value"></param>
        public Resistor(double value)
        {
            Value = value;
        }

        /// <summary>
        ///     Вернуть и установить номинал Resistor
        /// </summary>
        public sealed override double Value
        {
            get => Value;
            set
            {
                if (value > 0)
                {
                    Value = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Сопротивление не должно быть меньше или равно 0!");
                }
            }
        }

        /// <summary>
        ///     Метод для расчёта импеданса у резистора
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return Value;
        }
    }
}