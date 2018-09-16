using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary
{
    /// <summary>
    ///     Electrical circuit
    /// </summary>
    public class Circuit
    {
        #region Private fields

        /// <summary>
        ///     Electrical circuit root
        /// </summary>
        private INode _root;

        #endregion

        #region Properties

        /// <summary>
        ///     List of electrical circuit elements
        /// </summary>
        public List<ElementBase> Elements { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///     Event, when changing one of the elements of the electrical circuit
        /// </summary>
        public event ValueStateEventHandler CircuitChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor with parameters
        /// </summary>
        /// <param name="elements"></param>
        public Circuit(List<ElementBase> elements)
        {
            Elements = elements.Any() ? elements : new List<ElementBase>();
            if (Elements != null)
            {
                foreach (var element in Elements)
                {
                    element.ValueChanged += CircuitChanged;
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of complex resistance
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns></returns>
        public Complex[] CalculateZ(double[] frequencies)
        {
            var result = new Complex[frequencies.Length];
            for (var i = 0; i < frequencies.Length; i++)
            {
                foreach (var element in Elements)
                {
                    result[i] = Complex.Add(result[i],
                        element.CalculateZ(frequencies[i]));
                }
            }

            return result;
        }

        #endregion
    }
}