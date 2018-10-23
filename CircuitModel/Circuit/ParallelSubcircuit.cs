using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Параллельное соединение элементов цепи.
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
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

            if (Nodes.Count <= 1)
            {
                throw new
                    ArgumentException("Для параллельного соединения необходимо, как минимум, два элемента!");
            }

            var resistance = Complex.Zero;

            foreach (var nodeElements in Nodes)
            {
                resistance += 1 / nodeElements.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion
    }
}
