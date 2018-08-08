using System;
using System.Numerics;

namespace Gpt.Model
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    public class Capacitor : ElementBase
    {
        /// <summary>
        ///     Конструктор для создание объекта ёмкости
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="capacity">Ёмкость</param>
        public Capacitor(string name, double capacity) : base(name, capacity)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления конденсатор
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns >Комплексное сопротивлени</returns>
        public override Complex CalculateZ(double frequency)
        {
            var valueZ = 1 / (2 * Math.PI * frequency * Value);
            return new Complex(0, valueZ);
        }
    }
}