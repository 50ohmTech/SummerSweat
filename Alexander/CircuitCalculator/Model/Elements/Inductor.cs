using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    ///     Катушка индуктивности.
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="inductance">Индуктивность.</param>
        public Inductor(string name, double inductance) : base(name, inductance)
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
                throw new ArgumentOutOfRangeException("Частота должна быть больше нуля");
            }

            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}
