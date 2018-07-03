using System;
using System.ComponentModel;

namespace Model.PropertyGrid
{
    /// <summary>
    ///     Частоста
    /// </summary>
    public class Frequency
    {
        /// <summary>
        ///     Частота
        /// </summary>
        private double _value = 1;

        [DisplayName("Значение")]
        public double Value
        {
            get => _value;
            set
            {
                if (value < 1 || value > 1000000000000)
                {
                    throw new Exception(
                        "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
                }

                _value = value;
            }
        }

        /// <summary>
        ///     Возвращает название класса
        /// </summary>
        /// <returns>Название класса</returns>
        public override string ToString()
        {
            return "Частота";
        }
    }
}