using System.Numerics;

namespace CircuitLibrary
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