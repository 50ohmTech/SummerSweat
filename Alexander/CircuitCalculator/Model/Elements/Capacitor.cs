using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    ///     Конденсатор.
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="capacity">Емкость.</param>
        public Capacitor(string name, double capacity) : base(name, capacity)
        {
        }

        /// <summary>
        ///     Расчет импеданса.
        /// </summary>
        /// <param name="frequency">Частоста сигнала.</param>
        /// <returns>Импеданс.</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException("Частота не может быть меньше нуля");
            }

            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}
