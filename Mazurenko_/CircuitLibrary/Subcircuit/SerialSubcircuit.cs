using System;
using System.Numerics;
using CircuitLibrary.Validation;

namespace CircuitLibrary.Subcircuit
{
    /// <summary>
    ///     Serial connection
    /// </summary>
    public sealed class SerialSubcircuit : SubcircuitBase
    {
        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="id">Id</param>
        public SerialSubcircuit(uint id) : base(id)
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