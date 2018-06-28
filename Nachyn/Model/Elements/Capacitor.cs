using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    public class Capacitor : ElementBase
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="branch">Ветвь</param>
        /// <param name="name">Имя</param>
        /// <param name="capacity">Емкость</param>
        public Capacitor(Branch branch, string name, double capacity = 0) : base(branch,
            name, capacity)
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
            var valueZ = 1 / (2 * Math.PI * frequency * Value);
            return new Complex(0, valueZ);
        }
    }
}