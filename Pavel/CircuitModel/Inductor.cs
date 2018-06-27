using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Катушка индуктивности
    /// </summary>
    public class Inductor:Element
    {
        /// <summary>
        /// Конструктор класса Inductor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        /// Расчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }
    }
}
