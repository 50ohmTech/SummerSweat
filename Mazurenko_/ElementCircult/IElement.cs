using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitLibrary
{
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
        event StateValueHandle ValueChanged;

        #endregion Events

    }

    /// <summary>
    /// Delegate storing the signal signature
    /// </summary>
    /// <param name="data"></param>
    /// <param name="valueObject"></param>
    public delegate void StateValueHandle(object data, object valueObject);
}
