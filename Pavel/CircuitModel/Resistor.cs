using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Резистор
    /// </summary>
    public class Resistor:Element
    {
        /// <summary>
        /// Конструктор класса Resistor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Resistor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        /// Расчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns>Комплекное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, Value);
        }
    }
}
