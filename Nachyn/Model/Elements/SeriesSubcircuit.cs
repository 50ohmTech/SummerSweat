﻿using System.Numerics;
using Model.Elements.Checks;

namespace Model.Elements
{
    /// <summary>
    ///     Последовательная подцепь.
    /// </summary>
    public class SeriesSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Calculation.CheckFrequencies(frequency);

            Complex resistance = Complex.Zero;

            foreach (INode node in Nodes)
            {
                resistance += node.CalculateZ(frequency);
            }

            return resistance;
        }

        #endregion
    }
}