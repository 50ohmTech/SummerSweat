using System;
using System.Numerics;

namespace Model.Circuit
{
    /// <summary>
    /// Последовательная подцепь.
    /// </summary>
    public class SeriesSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        /// Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Номинал импеданса.</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count < 1)
            {
                throw new InvalidOperationException(
                    $"В последовательном соединении (Id: {Id}) нет узлов.");
            }

            var resistance = Complex.Zero;

            foreach (var node in Nodes)
            {
                resistance += node.CalculateZ(frequency);
            }

            return resistance;
        }

        #endregion
    }
}