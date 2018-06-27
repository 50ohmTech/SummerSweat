using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace CircuitLibrary
{
    class Circuit
    {
        #region Constructor
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
            if (elements.Any())
            {
                Elements = elements;
            }

            foreach (var element in Elements)
            {
                element.ValueChanged += CircuitChanged;
            }
        }
        #endregion Constructor

        #region Properties

        public List<IElement> Elements { get; set; }

        #endregion Properties

        #region Events

        /// <summary>
        /// Event, when changing one of the elements of the electrical circuit
        /// </summary>
        public event StateValueHandle CircuitChanged;

        #endregion Events

        #region Methods

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
        #endregion Methods

    }   
}
