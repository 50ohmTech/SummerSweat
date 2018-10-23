using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircuitLibrary.Validation
{
    /// <summary>
    /// Validation the entered value of the element
    /// </summary>
    public static class ValidationElementValue
    {
        /// <summary>
        /// Validation the entered value of the element
        /// </summary>
        /// <param name="value">Value of element</param>
        public static void ValidationSetValue(double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentException("The value of element is not a float-point number");
            }

            var minValue = 0.000001;
            if (value < minValue)
            {
                throw new ArgumentException("The value of element cannot be less than 1e-6");
            }

            double maxValue = 1000000000000;
            if (value > maxValue)
            {
                throw new ArgumentException(
                    "The value of element cannot be more than 1e12");
            }
        }
    }
}
