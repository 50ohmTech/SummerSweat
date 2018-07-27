using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary
{
    /// <summary>
    /// Electrical circuit
    /// </summary>
    public class Circuit
    {
        #region -- Properties --

        /// <summary>
        /// List of electrical circuit elements
        /// </summary>
        public List<IElement> Elements { get; set; }

        #endregion -- Properties --

        #region -- Events --

        /// <summary>
        /// Event, when changing one of the elements of the electrical circuit
        /// </summary>
        public event ValueStateEventHandler CircuitChanged;

        #endregion -- Events --

        #region -- Public Methods --

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Circuit() { }

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="elements"></param>
        public Circuit(List<IElement> elements)
        {
            Elements = elements.Any() ? elements : new List<IElement>();
            if (Elements != null)
            {
                foreach (var element in Elements)
                {
                    element.ValueChanged += CircuitChanged;
                }
            }
        }

        /// <summary>
        /// Calculation of complex resistance
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns></returns>
        public Complex[] CalculateZ(double[] frequencies)
        {
            var result = new Complex[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++)
            {
                foreach (var element in Elements)
                {
                    result[i] = Complex.Add(result[i],
                        element.CalculateZ(frequencies[i]));
                }
            }

            return result;
        }

        #endregion -- Public Methods --
    }
}
