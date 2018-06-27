using System;
using System.Numerics;

namespace Circuit
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    internal class Capacitor : ElementBase
    {
        /// <summary>
        ///     Вернуть и установить ёмкость
        /// </summary>
        public override double Value
        {
            get => Value;
            set
            {
                if (value > 0)
                {
                    Value = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Ёмкость не должна быть меньше или равно 0!");
                }
            }
        }

        /// <summary>
        ///     Расчёт импеданса для конденсатора
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return 1 / (2 * Math.PI * frequency * Value);
        }
    }
}