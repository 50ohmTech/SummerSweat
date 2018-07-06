using System;
using System.Numerics;

namespace ElementsLibrary
{
    /// <summary>
    /// Класс катушка индуктивности <see cref="Inductor"/>
    /// </summary>
    public class Inductor : ElementBase
    {
        /// <summary>
        /// Конструктор класса <see cref="Inductor"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Inductor(string name, double value) : base(name, value)
        {

        }

        /// <summary>
        /// Метод расчета импенданса в катушке индуктивности <see cref="CalculateZ"/>
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }
            return new Complex(0, 2 * Math.PI * Value);
        }
    }
}
