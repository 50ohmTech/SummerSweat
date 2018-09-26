using System;
using System.Numerics;

namespace CircuitLibrary.Subcircuits
{
    /// <summary>
    ///     Параллельное соединение
    /// </summary>
    internal class ParallelSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count <= 1)
            {
                throw new InvalidOperationException(
                    "Для расчета параллельного соединения необходимо минимум 2 ноды");
            }

            var impedance = Complex.Zero;

            foreach (var node in Nodes)
            {
                impedance += 1 / node.CalculateZ(frequency);
            }

            return 1 / impedance;
        }

        #endregion
    }
}