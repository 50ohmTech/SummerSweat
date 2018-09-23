using System;
using System.Numerics;

namespace CircuitLibrary
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

            var resistance = Complex.Zero;

            foreach (var node in Nodes)
            {
                resistance += 1 / node.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion
    }