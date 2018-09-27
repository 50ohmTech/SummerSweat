using System;
using System.Numerics;

namespace Model.Circuit
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
            if (Nodes.Count <= 1)
            {
                throw new InvalidOperationException(
                    $"В параллельном соединении (Id: {Id}) необходимо минимум 2 узла.");
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
}
