using System;
using System.Numerics;

namespace CircuitLibrary.Subcircuits
{
    /// <summary>
    ///     Последовательное соединение
    /// </summary>
    public class SerialSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (Nodes.Count < 1)
            {
                throw new InvalidOperationException(
                    $"В последовательном соединении (Id: {Id}) нет узлов.");
            }

            var impedance = Complex.Zero;

            foreach (var node in Nodes)
            {
                impedance += node.CalculateZ(frequency);
            }

            return impedance;
        }

        #endregion
    }
}