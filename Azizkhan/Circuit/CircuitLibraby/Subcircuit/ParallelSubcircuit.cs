using System;
using System.Numerics;

namespace CircuitLibrary.Subcircuits
{
    /// <summary>
    ///     Параллельное соединение
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
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
                //NOTE: А по одному элементу нельзя вычислить ? 
                throw new InvalidOperationException(
                    "Для расчета параллельного соединения необходимо минимум 2 узла. Добавьте элементы в параллельное соединение или удалите параллельное соединение целиком!");
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