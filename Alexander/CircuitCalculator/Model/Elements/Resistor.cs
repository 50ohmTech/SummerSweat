using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор.
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="resistance">Сопротивление.</param>
        public Resistor(string name, double resistance) : base(name, resistance)
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

            return new Complex(Value, 0);
        }

        #endregion
    }
}
