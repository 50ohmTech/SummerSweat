using System;
using CircuitLibrary.Validation;

namespace CircuitLibrary.Events
{
    public class ValueChangedEventArgs
    {
        #region Private fields

        /// <summary>
        ///     Message
        /// </summary>
        private string _message;

        /// <summary>
        ///     New value of element
        /// </summary>
        private double _value;

        #endregion

        #region Properties

        /// <summary>
        ///     Get / set new value of element
        /// </summary>
        private double Value
        {
            get => _value;
            set
            {
                ValidationElementValue.ValidationSetValue(value);
                _value = value;
            }
        }

        /// <summary>
        ///     Get/Set message about changing the value of element
        /// </summary>
        private string Message
        {
            get => _message;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Message is empty");
                }

                _message = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="newValue">New value of element</param>
        public ValueChangedEventArgs(string message, double newValue)
        {
            Message = message;
            Value = newValue;
        }

        #endregion
    }
}