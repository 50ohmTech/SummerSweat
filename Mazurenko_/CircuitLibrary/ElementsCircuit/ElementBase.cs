using System;
using System.Collections.Generic;
using System.Numerics;
using CircuitLibrary.Events;
using CircuitLibrary.Validation;

namespace CircuitLibrary
{
    /// <summary>
    ///     Abstract class containing general data of all
    ///     elements of the electrical circuit
    /// </summary>
    public abstract class ElementBase : INode
    {
        #region Private fields

        /// <summary>
        ///     The name of the element of an electric circuit
        /// </summary>
        private string _name;

        /// <summary>
        ///     The value of the electrical circuit element
        /// </summary>
        private double _value;

        #endregion

        #region Properties

        /// <summary>
        ///     The name of the element of an electric circuit
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

                _name = value;
            }
        }

        /// <summary>
        ///     The value of the electrical circuit element
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                ValidationElementValue.ValidationSetValue(value);
                _value = value;
                ValueChanged?.Invoke(this,
                    new ValueChangedEventArgs(Name + " has been changed", _value));
            }
        }

        /// <summary>
        ///     List of child nodes
        /// </summary>
        public List<INode> Nodes { get; set; }

        /// <summary>
        ///     Parent node
        /// </summary>
        public INode Parent { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///     Event to change the value of element
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="name">Element name</param>
        /// <param name="value">Element value</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency">Frequency</param>
        /// <returns>The complex impedance value</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}