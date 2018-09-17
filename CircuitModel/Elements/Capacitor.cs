using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Конденсатор.
    /// </summary>
    class Capacitor : ElementBase
    {
        #region ~ Конструктор ~

        /// <summary>
        /// Конструктор класса Capacitor.
        /// </summary>
        /// <param name="name"> Название элнмента. </param>
        /// <param name="value"> Значение элемента. </param>
        public Capacitor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region ~ Публичне методы ~

        /// <summary>
        /// Расчет импеданса.
        /// </summary>
        /// <param name="frequency"> Значение частоты. </param>
        /// <returns> Комплексное сопротивление. </returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Значение частоты должно быть больше нуля!");
            }
            return new Complex(0, 1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}
