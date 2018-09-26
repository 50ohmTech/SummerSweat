using System;
using System.Numerics;

namespace CircuitLibrary.Subcircuit
{
    /// <summary>
    ///     Parallel connection
    /// </summary>
    public sealed class ParallelSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>The complex impedance value</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count < 2)
            {
                throw new InvalidOperationException(
                    "At least two nodes are required to count the parallel connection");
            }

            var impedance = new Complex();

            foreach (var node in Nodes)
            {
                impedance += 1 / node.CalculateZ(frequency);
            }

            var result = 1 / impedance;
            return result;
        }

        #endregion
    }
}