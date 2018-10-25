using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Катушка индуктивности.
    /// </summary>
    public class Inductor : ElementBase
    {
        #region ~ Конструктор ~

        /// <summary>
        /// Конструктор класса Inductor.
        /// </summary>
        /// <param name="name"> Название элемента. </param>
        /// <param name="value"> Значение элемента. </param>
        public Inductor(string name, double value) : base(name, value)
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
            if (frequency > 1000000000000)
            {
                throw new ArgumentOutOfRangeException(
                   "Значение частоты не должно превышать 10 в 12 степени!");
            }
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Значение частоты должно быть больше нуля!");
            }
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}
