using System;
using System.Numerics;


namespace ElementsLibrary.Circuits
{
    /// <summary>
    /// Параллельное соединение цепи <see cref="ParallelSubcircuit"/>
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        /// Метод расчета импеданса
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public override Complex CalculateZ(double frequency)
        {
            if ((frequency <= 0) || (frequency > 1000000000000))
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }

            if (Nodes.Count <= 1)
            {
                throw new
                    ArgumentException("Для параллельного соединения нужно два элемента!");
            }

            var resistance = Complex.Zero;

            foreach (var nodeElements in Nodes)
            {
                resistance += 1 / nodeElements.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion

    }
}