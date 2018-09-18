using System;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса Inductor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    "Частота не может быть меньше или равна нулю");
            }

            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}