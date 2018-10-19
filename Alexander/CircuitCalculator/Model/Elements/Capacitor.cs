using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор.
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="capacity">Номинал емкости.</param>
        public Capacitor(string name, double capacity) : base(name, capacity)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет импеданса.
        /// </summary>
        /// <param name="frequency">Частоста сигнала.</param>
        /// <returns>Номинал импеданса.</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException("Частота должна быть больше нуля");
            }

            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}