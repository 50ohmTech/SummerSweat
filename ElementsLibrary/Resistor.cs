using System;
using System.Numerics;

namespace ElementsLibrary
{
    /// <summary>
    /// Класс резистор <see cref="Resistor"/>
    /// </summary>
    public class Resistor : ElementBase
    {
        /// <summary>
        /// Конструктор класса <see cref="Resistor"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public Resistor(double value, string name) : base(name, value)
        {

        }

        /// <summary>
        /// Метод расчета импеданса в резисторе <see cref="CalculateZ"/>
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }
            return new Complex(Value , 0);
        }
    }
}
