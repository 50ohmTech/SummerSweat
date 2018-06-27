using System;
using System.Numerics;

namespace CircuitCalculator
{
    /// <summary>
    /// Конденсатор
    /// </summary>
    public class Capacitor :Element
    {
        /// <summary>
        /// Конструктор класса Capacitor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Capacitor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        /// Расчет импеданса
        /// </summary>
        /// <param name="f">Частота сигнала</param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }
    }
}
