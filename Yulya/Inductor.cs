using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Класс Inductor.
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Публичные методы

        /// <summary>
        /// Конструктор класса Inductor.
        /// </summary>
        /// <param name="name">Имя элемента.</param>
        /// <param name="value">Номинал элемента.</param>
        public Inductor(string name, double value) : base(name, value)
        {

        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns>Комплексное значение импеданса.</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}
