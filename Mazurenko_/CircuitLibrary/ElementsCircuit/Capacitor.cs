using System;
using System.Numerics;
using CircuitLibrary.Validation;

namespace CircuitLibrary
{
    /// <summary>
    ///     The capacitor element of the electric circuit
    /// </summary>
    public sealed class Capacitor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="name">Element name</param>
        /// <param name="value">Element value</param>
        public Capacitor(string name, double value) : base(name, value)
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

            return new Complex(0, 1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}