using System;
using System.Windows.Forms;

namespace CircuitView
{
    /// <summary>
    ///     Class for checking the input parameters in the value
    ///     of the electrical circuit element
    /// </summary>
    public static class ValueTextBoxTools
    {
        #region Constants

        /// <summary>
        ///     The minimum value that the element  takes
        /// </summary>
        private const double _minValue = 0.000001;

        /// <summary>
        ///     The maximum value that the element  takes
        /// </summary>
        private const double _maxValue = 1000000000000;

        #endregion

        #region Private methods

        /// <summary>
        ///     Checks the string for more than one comma in the field 'Value'
        /// </summary>
        /// <param name="symbol">Enter symbol</param>
        /// <param name="textBox">Text</param>
        /// <returns>true/false</returns>
        private static bool IsCorrectLine(char symbol, string textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox) && symbol == ',')
            {
                return false;
            }

            var text = textBox.ToCharArray();
            for (var i = 0; i < text.Length; i++)
            {
                if (text[i] == ',')
                {
                    if (symbol == ',' || text.Length - i > 6)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        ///     Checking the received number
        /// </summary>
        /// <param name="valueString">string to check</param>
        /// <returns>
        ///     Greater - true / less - false
        /// </returns>
        private static bool IsGreaterThanMaximum(string valueString)
        {
            double.TryParse(valueString, out var number);
            return number > _maxValue;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Enter floating-point numbers only
        /// </summary>
        /// <param name="e">Event parameter</param>
        /// <param name="sender">Event sender</param>
        public static void DoubleKeyPress(KeyPressEventArgs e, object sender)
        {
            if (!(sender is TextBox textBox))
            {
                throw new ArgumentException("The object is not a TextBox");
            }

            if (e.KeyChar != (char) Keys.Back)
            {
                if (IsGreaterThanMaximum(textBox.Text))
                {
                    e.Handled = true;
                }

                if (!IsCorrectLine(e.KeyChar, textBox.Text) ||
                    !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        ///     Checking the correctness of the entered characters
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <returns>True/False</returns>
        public static bool TextChanged(object sender)
        {
            if (!(sender is TextBox textBox))
            {
                throw new ArgumentException("The object is not a TextBox");
            }

            var valueText = textBox.Text;
            double.TryParse(valueText, out var number);
            var isNumber = number >= _minValue && number <= _maxValue &&
                           !string.IsNullOrWhiteSpace(valueText);

            return isNumber;
        }

        /// <summary>
        ///     Event when leaving the TextBox
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <returns></returns>
        public static bool Leave(object sender)
        {
            if (!(sender is TextBox textBox))
            {
                throw new ArgumentException("The object is not a TextBox");
            }

            var resultValue = TextChanged(sender);
            if (!resultValue)
            {
                textBox.Clear();
            }

            return resultValue;
        }

        /// <summary>
        ///     Checking string for emptiness
        /// </summary>
        /// <param name="text">Text to check</param>
        /// <returns>Text is empty</returns>
        public static bool IsTextEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        #endregion
    }
}