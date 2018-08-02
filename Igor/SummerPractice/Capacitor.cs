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
        ///     Расчет комслексного сопротивления конденсатор
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            var valueZ = 1 / (2 * Math.PI * frequency * Value);
            return new Complex(0, valueZ);
        }
    }
}