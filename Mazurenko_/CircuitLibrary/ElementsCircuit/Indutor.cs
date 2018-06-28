using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitLibrary.ElementsCircuit
{
    /// <summary>
    /// Inductance coil, element of the electrical circuit
    /// </summary>
    public sealed class Indutor : ElementBase
    {
        #region Constructor

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Indutor(string name, double value) : base(name, value)
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
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion Methods
    }
}
