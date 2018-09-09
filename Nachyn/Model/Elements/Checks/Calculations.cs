using System;

namespace Model.Elements.Checks
{
    public class Calculations
    {
        #region Public methods

        /// <summary>
        ///     Проверить частоты на значения, которые они могут принимать.
        /// </summary>
        /// <param name="frequncies">Частоты</param>
        /// <exception cref="ArgumentException">Выбрасывает если частоты вне диапазона от 1 Гц. до 1Тгц.</exception>
        public static void CheckFrequencies(params double[] frequncies)
        {
            foreach (double frequency in frequncies)
            {
                if (frequency < 1 || frequency > 1000000000000)
                {
                    throw new ArgumentException(
                        "Частота может принимать значение только от 1 Гц. до 1 ТГц.");
                }
            }
        }

        #endregion
    }
}