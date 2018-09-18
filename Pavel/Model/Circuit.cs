#region

using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;

#endregion

namespace Model
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Корень цепи.
        /// </summary>
        private INode _root;

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчитать импедансы цепи для списка частот.
        /// </summary>
        /// <param name="frequencies">Список частот сигнала.</param>
        /// <returns>Список импедансов цепи.</returns>
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