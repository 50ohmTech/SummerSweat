using System.Windows.Forms;

namespace CircuitLibrary
{
    /// <summary>
    ///     Class for checking the specified frequency range
    /// </summary>
    public static class FrequencyRange
    {
        #region Constants

        /// <summary>
        ///     Minimum frequency allowed
        /// </summary>
        private const double _minValue = 0.000001;

        /// <summary>
        ///     Maximum frequency allowed
        /// </summary>
        private const double _maxValue = 1000000000000;

        /// <summary>
        ///     No step
        /// </summary>
        private const double _noStep = 0;

        #endregion

        #region Private methods

        /// <summary>
        ///     Checking the value for the appropriate range
        /// </summary>
        /// <param name="valueName">Value name</param>
        /// <param name="value">Value</param>
        /// <returns>Is the value in the specified range of numbers</returns>
        private static bool IsCorrectValue(string valueName, double value)
        {
            if (value >= _minValue && value <= _maxValue)
            {
                return true;
            }

            ShowMessage(valueName + " should be in the range of 1e-6 to 1e12");

            return false;
        }

        /// <summary>
        ///     Checking the entered range
        /// </summary>
        /// <param name="startValue">Start value</param>
        /// <param name="endValue">End value</param>
        /// <returns>Greater - false / less - true</returns>
        private static bool IsCorrectRange(double startValue, double endValue)
        {
            if (startValue > endValue)
            {
                ShowMessage("\"Start value\" is greater than \"End value\"");
                return false;
            }

            return true;
        }

        /// <summary>
        ///     The output of the error message
        /// </summary>
        /// <param name="message">Message</param>
        private static void ShowMessage(string message)
        {
            MessageBox.Show(message, "Attention",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Checking the entered frequency
        /// </summary>
        /// <param name="startValue">Start value</param>
        /// <param name="endValue">End value</param>
        /// <returns>Is the value in the specified range of numbers</returns>
        public static bool IsCorrectStartEnd(double startValue, double endValue)
        {
            if (!IsCorrectValue("\"Start value\" ", startValue) ||
                !IsCorrectValue("\"End value\" ", endValue))
            {
                return false;
            }

            if (!IsCorrectRange(startValue, endValue))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Checking the entered step
        /// </summary>
        /// <param name="startValue">Start value</param>
        /// <param name="endValue">End value</param>
        /// <param name="step">Step</param>
        /// <returns>Is correct step</returns>
        public static bool IsCorrectStep(double startValue, double endValue, double step)
        {
            if (endValue - startValue < step)
            {
                ShowMessage("The step cannot be greater than the end value.");
                return false;
            }

            if (step == _noStep)
            {
                ShowMessage("Step cannot be 0");
                return false;
            }

            return true;
        }

        #endregion
    }
}