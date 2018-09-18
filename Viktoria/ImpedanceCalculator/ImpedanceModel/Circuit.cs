using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Private fields

        /// <summary>
        ///     Начало цепи.
        /// </summary>
        private Subcircuit _root;

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчет комплексного сопротивления цепи для диапазона частот.
        /// </summary>
        /// <param name="frequencies"> Диапазон частот. </param>
        /// <returns> Список сопротивлений для каждой частоты из заданного диапазона. </returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedances.Add(_root.CalculateZ(frequency));
            }

            return impedances;
        }

        #endregion
    }
}