using System;
using System.Numerics;

namespace Circuit
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    internal class Inductor : ElementBase
    {
        /// <summary>
        ///     Вернуть и установить индуктивность
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
                        "Индуктивность не должна быть меньше или равно 0!");
                }
            }
        }

        /// <summary>
        ///     Метод для расчёта импеданса катушки индуктивности
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public override Complex CalculateZ(double frequency)
        {
            return 2 * Math.PI * Value * frequency;
        }
    }
}