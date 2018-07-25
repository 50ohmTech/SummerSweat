using System;
using System.Linq;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary
{
    /// <summary>
    /// Abstract class containing general data of all
    /// elements of the electrical circuit
    /// </summary>
    public abstract class ElementBase: IElement
    {
        #region Constructor

        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion Constructor

        #region Fields

        /// <summary>
        /// The name of the element of an electric circuit  
        /// </summary>        
        private string _name;

        /// <summary>
        /// The value of the electrical circuit element
        /// </summary>
        private double _value;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The name of the element of an electric circuit
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Element name cannot be empty");
                }

                if (value.Contains(' '))
                {
                    throw new FormatException("There should not be a space inside the name");
                }

                value = value.ToUpper();
                if (!IsName(value))
                {
                    throw new FormatException("Name entered incorrectly !");
                }
                _name = value;
            }
        }

        /// <summary>
        /// The value of the electrical circuit element
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException("The value is not a real number");
                }

                double minValue = 0.000001;
                if (value < minValue)
                {
                    throw new ArgumentException("The value cannot be less than 0.000001");
                }

                double maxValue = 100000000000000;
                if (value > maxValue)
                {
                    throw new ArgumentException("The value cannot be more than 100000000000000");
                }
                _value = value;
                ValueChanged?.Invoke(_value, this);
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Calculation of impedance
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double f);        

        /// <summary>
        /// Name validation
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static bool IsName(string source)
        {
            foreach (var current in source)
            {
                if (!IsEnglishLetter(current) && !char.IsDigit(current))
                {
                    return false;
                }
            }

            return true;
        }
        
        /// <summary>
        /// Checking for the symbol of the English alphabet
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static bool IsEnglishLetter(char symbol)
        {
            return (symbol >= 'A' && symbol <= 'Z');
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Signal changes in the nominal value of the electrical circuit element
        /// </summary>
        public event ValueStateEventHandler ValueChanged;

        #endregion Events
    }
}
