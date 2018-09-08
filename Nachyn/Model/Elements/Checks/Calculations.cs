using System;

namespace Model.Elements.Checks
{
    public class Calculations
    {
        /// <summary>
        ///     Проверить частоты на значения, которые они могут принимать.
        ///     В случае ошибки выбрасывается ArgumentException исключение.
        /// </summary>
        /// <param name="frequncies">Частоты</param>
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
    }
}