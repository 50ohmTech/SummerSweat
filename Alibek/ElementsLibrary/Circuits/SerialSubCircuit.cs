using System;
using System.Numerics;


namespace ElementsLibrary.Circuits
{
    /// <summary>
    /// Последовательное соединение цепи <see cref="SerlialSubcircuit"/>
    /// </summary>
    public class SerialSubcircuit : SubcircuitBase
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

            var resistance = Complex.Zero;

            foreach (var nodeElements in Nodes)
            {
                resistance += nodeElements.CalculateZ(frequency);
            }

            return 1 / resistance;
        }

        #endregion
    }
}