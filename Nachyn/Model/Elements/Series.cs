using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Последовательная подцепь
    /// </summary>
    internal class Series : Subcircuit
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