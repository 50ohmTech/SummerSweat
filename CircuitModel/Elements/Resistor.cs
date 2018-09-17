using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Резистор.
    /// </summary>
    public class Resistor : ElementBase
    {
        #region ~ Конструктор ~

        /// <summary>
        /// Конструктор класса Resistor.
        /// </summary>
        /// <param name="name"> Название элемента. </param>
        /// <param name="value"> Значение элемента. </param>
        public Resistor(string name, double value) : base(name, value)
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
            return new Complex(Value, 0);
        }

        #endregion
    }
}
