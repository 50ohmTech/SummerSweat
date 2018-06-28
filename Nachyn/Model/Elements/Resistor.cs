using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор
    /// </summary>
    public class Resistor : ElementBase
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="branch">Ветвь</param>
        /// <param name="name">Имя</param>
        /// <param name="resistance">Сопротивление</param>
        public Resistor(Branch branch, string name, double resistance = 0) : base(branch,
            name, resistance)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(Value, 0);
        }
    }
}