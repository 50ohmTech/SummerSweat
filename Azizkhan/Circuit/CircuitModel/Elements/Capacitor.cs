using System;
using System.Numerics;

namespace CircuitModel.Elements
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    internal class Capacitor : ElementBase
    {
        /// <summary>
        ///     Конструктор сущности Конденсатор
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public Capacitor(double value, string name) : base(value, name)
        {
        }

        /// <summary>
        ///     Вернуть тип элемента
        /// </summary>
        public override ElementType Type => ElementType.Capacitor;

        /// <summary>
        ///     Расчёт импеданса для конденсатора
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return 1 / (2 * Math.PI * frequency * Value);
        }
    }
}