using System;
using System.Numerics;
using Model.Elements.Checks;

namespace Model.Elements
{
    /// <summary>
    ///     Параллельная подцепь.
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Calculation.CheckFrequencies(frequency);
            if (Nodes.Count <= 1)
            {
                throw new InvalidOperationException(
                    "Для расчета параллельного соединения необходимо минимум 2 ноды");
            }

            Complex resistance = Complex.Zero;

            foreach (INode node in Nodes)
            {
                resistance += 1 / node.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion
    }
}