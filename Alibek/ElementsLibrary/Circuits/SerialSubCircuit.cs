using System;
using System.Numerics;

namespace ElementsLibrary.Circuits
{
    /// <summary>
    ///     Последовательное соединение цепи 
    /// </summary>
    public class SerialSubcircuit : SubcircuitBase
    {
        #region Constants

        private const double _maxFrequency = 1000000000000;

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод расчета импеданса
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0 || frequency > _maxFrequency)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }

            var resistance = Complex.Zero;

            foreach (var nodeElements in Nodes)
            {
                resistance += nodeElements.CalculateZ(frequency);
            }

            return  1/resistance;
        }

        #endregion
    }
}