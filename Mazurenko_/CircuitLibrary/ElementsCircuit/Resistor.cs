using System.Numerics;
using CircuitLibrary.Validation;

namespace CircuitLibrary
{
    public sealed class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Constructor with parameters
        /// </summary>
        /// <param name="name">Element name</param>
        /// <param name="value">Element value</param>
        public Resistor(string name, double value) : base(name, value)
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

            return new Complex(Value, 0);
        }

        #endregion
    }
}