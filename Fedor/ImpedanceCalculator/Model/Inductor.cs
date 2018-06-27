using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Катушка индуктивности.
    /// </summary>
    public class Inductor : Element
    {
        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса Inductor.
        /// </summary>
        /// <param name="name"> Имя элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency"> Частота сигнала. </param>
        /// <returns> Комплексное значение импеданса. </returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}