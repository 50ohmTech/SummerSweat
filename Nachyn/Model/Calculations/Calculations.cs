using System;
using System.Numerics;

namespace Model.Calculations
{
    /// <summary>
    ///     Рассчеты
    /// </summary>
    public class Calculations
    {
        #region Private

        /// <summary>
        ///     Частота
        /// </summary>
        private double _frequency = 1;

        #endregion

        #region Public

        /// <summary>
        /// Проверить частоты на значения, которые они могут принимать.
        /// В случае ошибки выбрасывается ArgumentException исключение.
        /// </summary>
        /// <param name="frequncies"></param>
        public static void CheckFrequencies(params double[] frequncies)
        {
            foreach (double frequency in frequncies)
            {
                if (frequency < 1 || frequency > 1000000000000)
                {
                    throw new ArgumentException(
                        "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
                }
            }
        }

        /// <summary>
        ///     Возвращает частоту
        /// </summary>
        public double Frequency
        {
            get => _frequency;
            set
            {
                CheckFrequencies(value);
                _frequency = value;
            }
        }

        /// <summary>
        ///     Импеданс
        /// </summary>
        public Complex Impedance { get; set; }

        #endregion
    }
}