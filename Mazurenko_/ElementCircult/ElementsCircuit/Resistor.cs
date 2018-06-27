using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitLibrary
{
    public sealed class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        /// Empty constructor
        /// </summary>
        Resistor() { }

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
        /// <param name="R"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double R)
        {
            return new Complex(R, 0);
        }

        #endregion Methods    
    }
}
