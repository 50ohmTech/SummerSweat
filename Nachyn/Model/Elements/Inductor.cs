using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    public class Inductor : ElementBase
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="inductance">Индуктивность</param>
        public Inductor(string name, double inductance = 0) : base(name, inductance)
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
            if (frequency < 1 || frequency > 1000000000000)
            {
                throw new ArgumentException(
                    "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
            }

            double valueZ = 2 * Math.PI * frequency * Value;
            return new Complex(0, valueZ);
        }
    }
}