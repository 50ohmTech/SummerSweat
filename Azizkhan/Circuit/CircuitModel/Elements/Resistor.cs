using System.Numerics;

namespace CircuitModel.Elements
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
        /// <param name="name"></param>
        public Resistor(double value, string name) : base(value, name)
        {
        }

        /// <summary>
        ///     Вернуть тип элемента
        /// </summary>
        public override ElementType Type => ElementType.Resistor;

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