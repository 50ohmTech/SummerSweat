using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Класс цепи.
    /// </summary>
    class Circuit
    {
        private INode _root;

        #region ~ Публичные методы ~

        /// <summary>
        /// Расчет импеданса цепи для списка частот.
        /// </summary>
        /// <param name="frequencies"> Список частот сигнала. </param>
        /// <returns> Список импедансов цепи. </returns>
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
