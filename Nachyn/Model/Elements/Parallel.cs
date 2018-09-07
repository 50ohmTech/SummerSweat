using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Параллельная подцепь
    /// </summary>
    internal class Parallel : Subcircuit
    {
        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        public override Complex CalculateZ(double frequency)
        {
            throw new NotImplementedException();
        }
    }
}