using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор.
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="resistance">Номинал сопротивления.</param>
        public Resistor(string name, double resistance) : base(name, resistance)
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

            return new Complex(Value, 0);
        }

        #endregion
    }
}