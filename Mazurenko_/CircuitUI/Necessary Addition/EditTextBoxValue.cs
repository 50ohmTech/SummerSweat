using System.Windows.Forms;

namespace CircuitUI
{
    /// <summary>
    /// Class for checking the input parameters in the value of the electrical circuit element
    /// </summary>
    public abstract class EditTextBoxValue
    {
        #region Methods

        /// <summary>
        /// Event when you press a key in the 'Value' field
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="symbol"></param>
        public static bool IsCurrectionTextBoxValue_Edit(string stringValue, char symbol)
        {
            if (symbol != (char)Keys.Back)
            {
                if (!IsCorrectLine(symbol, stringValue))
                {
                    return false;
                }

                if (!char.IsDigit(symbol) && symbol != ',')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the string for more than one comma in the field 'Value'
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="textBoxt"></param>
        /// <returns></returns>
        private static bool IsCorrectLine(char symbol, string textBoxt)
        {
            if (textBoxt == "" && symbol == ',')
            {
                return false;
            }
            char[] text = textBoxt.ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ',')
                {
                    if (symbol == ',' || (text.Length - i) > 6)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion Methods
    }
}
