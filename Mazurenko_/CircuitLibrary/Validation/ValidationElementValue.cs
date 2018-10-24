using System;

namespace CircuitLibrary.Validation
{
    /// <summary>
    ///     Validation the entered value of the element
    /// </summary>
    public static class ValidationElementValue
    {
        #region Public methods

        /// <summary>
        ///     Validation the entered value of the element
        /// </summary>
        /// <param name="value">Value of element</param>
        public static void ValidationSetValue(double value)
        {
            if (!IsDouble(value))
            {
                throw new ArgumentException(
                    "The value of element is not a float-point number");
            }

            if (value < ConstantValues.MinValue)
            {
                throw new ArgumentException(
                    "The value of element cannot be less than 1e-6");
            }

            if (value > ConstantValues.MaxValue)
            {
                throw new ArgumentException(
                    "The value of element cannot be more than 1e12");
            }
        }

        /// <summary>
        ///     Validation whether the value is a double
        /// </summary>
        /// <param name="value">Check of value</param>
        /// <returns></returns>
        public static bool IsDouble(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        #endregion
    }
}