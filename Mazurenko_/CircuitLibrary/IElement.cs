using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary
{
    /// <summary>
    /// Interface of electrical circuit elements
    /// </summary>
    interface IElement
    {
        #region Properties

        /// <summary>
        /// The name of the element of an electric circuit
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The value of the electrical circuit element
        /// </summary>
        double Value { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        Complex CalculateZ(double frequency);

        #endregion Methods

        #region Events
        /// <summary>
        /// Signal changes in the nominal value of the electrical circuit element
        /// </summary>
        event ValueStateEventHandler ValueChanged;

        #endregion Events
    }   
}
