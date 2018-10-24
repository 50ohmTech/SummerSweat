using System;
using System.Numerics;
using CircuitLibrary.Validation;

namespace CircuitLibrary.Subcircuit
{
    /// <summary>
    ///     Parallel connection
    /// </summary>
    public sealed class ParallelSubcircuit : SubcircuitBase
    {
        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">ID</param>
        public ParallelSubcircuit(uint id) : base(id)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency">Frequency</param>
        /// <returns>The complex impedance value</returns>
        public override Complex CalculateZ(double frequency)
        {
            ValidationElementValue.ValidationSetValue(frequency);

            if (Nodes.Count < 2)
            {
                throw new InvalidOperationException(
                    "At least two nodes are required to count the parallel connection");
            }

            var impedance = Complex.Zero;

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