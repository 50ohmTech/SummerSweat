using System;
using System.Numerics;
using CircuitLibrary.Validation;

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
        /// <param name="name">Element name</param>
        /// <param name="value">Element value</param>
        public Inductor(string name, double value) : base(name, value)
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

            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}