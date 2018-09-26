using System;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    ///     Inductance coil, element of the electrical circuit
    /// </summary>
    public sealed class Inductor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>The complex impedance value</returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}