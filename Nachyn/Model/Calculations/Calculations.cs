using System;
using System.Numerics;

namespace Model.Calculations
{
    /// <summary>
    ///     Рассчеты
    /// </summary>
    public class Calculations
    {
        /// <summary>
        ///     Частота
        /// </summary>
        private double _frequency = 1;

        /// <summary>
        ///     Возвращает частоту
        /// </summary>
        public double Frequency
        {
            get => _frequency;
            set
            {
                if (value < 1 || value > 1000000000000)
                {
                    throw new ArgumentException(
                        "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
                }

                _frequency = value;
            }
        }

        /// <summary>
        ///     Импеданс
        /// </summary>
        public Complex Impedance { get; set; }
    }
}