using System.Numerics;

namespace Gpt.Model
{
    /// <summary>
    ///     Резистор (сопротивление)
    /// </summary>
    public class Resistor : ElementBase
    {
        /// <summary>
        ///     Конструктор для создания резистора
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="resistance">Сопротивление</param>
        public Resistor(string name, double resistance) : base(name, resistance)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления резистора
        /// </summary>
        /// <param name="f">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double f)
        {
            return new Complex(Value, 0);
        }
    }
}