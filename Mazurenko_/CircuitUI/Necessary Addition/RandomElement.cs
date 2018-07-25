using System;
using CircuitLibrary;

namespace CircuitUI
{
    /// <summary>
    /// Class for creating a random element of an electrical circuit
    /// </summary>
    public sealed class RandomElement
    {
        #region Fields

        /// <summary>
        /// Field for storing a random value of the electrical circuit element
        /// </summary>
        private double _valueRandom;

        /// <summary>
        /// Field for storing a random name of an electric circuit element
        /// </summary>
        private string _nameRandom;

        /// <summary>
        /// A field to store a random type of element of an electric circuit
        /// </summary>
        private string _typeRandom;

        /// <summary>
        /// Field for initializing the pseudo-random number generator
        /// </summary>
        private Random _rand;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Method for creating a random element of an electrical circuit
        /// </summary>
        /// <returns></returns>
        public IElement CreateRandomElement()
        {
            _rand = new Random();
            _valueRandom = _rand.Next(1, 1000) * 0.4;
            _typeRandom = CreateType();
            _nameRandom = CreateName();

            IElement newElement;
            if (_typeRandom == "Resistor")
            {
                newElement = new Resistor(_nameRandom, Convert.ToDouble(_valueRandom));
            }
            else if (_typeRandom == "Inductor")
            {
                newElement = new Indutor(_nameRandom, Convert.ToDouble(_valueRandom));
            }
            else
            {
                newElement = new Capacitor(_nameRandom, Convert.ToDouble(_valueRandom));
            }

            return newElement;
        }

        /// <summary>
        /// Method for creating a random type of electrical circuit element
        /// </summary>
        /// <returns></returns>
        private string CreateType()
        {
            string type = null;
            int current = _rand.Next(3);
            switch (current)
            {
                case 0:
                {
                    type = "Resistor";
                    break;
                }
                case 1:
                {
                    type = "Capacitor";
                    break;
                }
                case 2:
                {
                    type = "Inductor";
                    break;
                }
            }

            return type;
        }

        /// <summary>
        /// Method for creating a random name for an electrical circuit element
        /// </summary>
        /// <returns></returns>
        private string CreateName()
        {
            string name = null;
            switch (_typeRandom)
            {
                case "Resistor":
                    name += "R";
                    break;
                case "Capacitor":
                    name += "C";
                    break;
                case "Inductor":
                    name += "I";
                    break;
            }

            name += _rand.Next(10).ToString();
            return name;
        }

        #endregion Methods

    }
}
