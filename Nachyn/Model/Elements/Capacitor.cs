using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="capacity">Емкость</param>
        public Capacitor(string name, double capacity = 0) : base(name, capacity)
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

            double valueZ = -1 / (2 * Math.PI * frequency * Value);
            return new Complex(0, valueZ);
        }

        #endregion
    }
}