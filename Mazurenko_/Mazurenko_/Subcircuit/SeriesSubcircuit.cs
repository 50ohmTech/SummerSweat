using System.Numerics;

namespace CircuitLibrary.Subcircuit
{
    /// <summary>
    ///     Serial connection
    /// </summary>
    public sealed class SeriesSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>The complex impedance value</returns>
        public override Complex CalculateZ(double frequency)
        {
            var impedance = new Complex();
            foreach (var node in Nodes)
            {
                impedance += node.CalculateZ(frequency);
            }

            return impedance;
        }

        #endregion
    }
}