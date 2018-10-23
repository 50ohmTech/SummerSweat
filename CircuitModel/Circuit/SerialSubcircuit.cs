using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Последовательное соединение элементов цепи.
    /// </summary>
    public class SerialSubcircuit : SubcircuitBase
    {
        #region ~ Публичные методы ~

        /// <summary>
        /// Метод для расчета комплексного сопротивления.
        /// </summary>
        /// <param name="frequency"> Значение частоты. </param>
        /// <returns> Комплексное сопротивление. </returns>
        public override Complex CalculateZ(double frequency)
        {
            if ((frequency <= 0) || (frequency > 1000000000000))
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }

            var resistance = Complex.Zero;

            foreach (var nodeElements in Nodes)
            {
                resistance += nodeElements.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion
    }
}
