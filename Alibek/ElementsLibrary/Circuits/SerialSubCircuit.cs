using System;
using System.Numerics;

namespace ElementsLibrary.Circuits
{
    public abstract class SerlialSubcircuit : SubcircuitBase
    {
        #region Public methods

        /// <summary>
        /// Метод расчета импеданса
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public override Complex CalculateZ(double frequency)
        {
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