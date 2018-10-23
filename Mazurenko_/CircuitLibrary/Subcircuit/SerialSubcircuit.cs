using System;
using System.Numerics;

namespace CircuitLibrary.Subcircuit
{
    /// <summary>
    ///     Serial connection
    /// </summary>
    public sealed class SerialSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency">Frequency</param>
        /// <returns>The complex impedance value</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count < 1)
            {
                throw new InvalidOperationException("Serial connection has no nodes");
            }

            var impedance = Complex.Zero;
            foreach (var node in Nodes)
            {
                impedance += node.CalculateZ(frequency);
            }

            return impedance;
        }

        #endregion
    }
}