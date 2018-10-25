using System;
using System.Numerics;
using CircuitLibrary.Subcircuits;

namespace CircuitLibrary.Subcircuit
{
    /// <summary>
    ///     Параллельное соединение
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
    {
        #region Properties

        /// <inheritdoc />
        public override NodeType Type { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор класса ParallelSubcircuit
        /// </summary>
        public ParallelSubcircuit()
        {
            Type = NodeType.Parallel;
        }

        #endregion

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