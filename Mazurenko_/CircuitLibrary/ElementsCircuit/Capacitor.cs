using System;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    /// The capacitor element of the electric circuit
    /// </summary>
    public sealed class Capacitor : ElementBase
    {
        #region Constructor    

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Capacitor(string name, double value) : base(name, value)
        {

        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion Methods
    }
}
