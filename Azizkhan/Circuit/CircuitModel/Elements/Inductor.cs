using System;
using System.Numerics;

namespace Circuit
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    internal class Inductor : ElementBase
    {
        /// <summary>
        ///     Конструктор сущности Катушка индуктивности
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public Inductor(double value, string name) : base(value, name)
        {
        }

        /// <summary>
        ///     Вернуть тип элемента
        /// </summary>
        public override ElementType Type => ElementType.Inductor;

        /// <summary>
        ///     Метод для расчёта импеданса катушки индуктивности
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return 2 * Math.PI * Value * frequency;
        }
    }
}