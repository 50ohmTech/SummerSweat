using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    /// The resistor part of the circuit
    /// </summary>
    public sealed class Resistor : ElementBase
    {
        #region -- Public Methods --

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Resistor(string name, double value) : base(name, value)
        {

        }

        /// <summary>
        /// Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(Value, 0);
        }

        #endregion -- Public Methods --    
    }
}
