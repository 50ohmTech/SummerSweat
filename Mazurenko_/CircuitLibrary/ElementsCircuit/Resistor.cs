using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    /// The resistor part of the circuit
    /// </summary>
    public sealed class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Resistor(string name, double value) : base(name, value)
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
            return new Complex(Value, 0);
        }

        #endregion Methods    
    }
}
