using System;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    /// Inductance coil, element of the electrical circuit
    /// </summary>
    public sealed class Indutor : ElementBase
    {
        #region -- Public Methods --

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Indutor(string name, double value) : base(name, value)
        {

        }

        /// <summary>
        /// Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion -- Public Methods --
    }
}
