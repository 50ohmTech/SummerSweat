using System.Numerics;

namespace CircuitLibrary.Subcircuits
{
    /// <summary>
    ///     Последовательное соединение
    /// </summary>
    internal class SeriesSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        public override Complex CalculateZ(double frequency)
        {
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