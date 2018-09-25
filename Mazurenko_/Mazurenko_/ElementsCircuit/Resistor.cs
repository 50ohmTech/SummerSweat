using System.Numerics;

namespace CircuitLibrary
{
    public sealed class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Constructor with parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Resistor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="R"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double R)
        {
            return new Complex(R, 0);
        }

        #endregion
    }
}