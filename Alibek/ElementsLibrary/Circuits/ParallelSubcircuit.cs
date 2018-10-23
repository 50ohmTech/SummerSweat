﻿using System;
using System.Numerics;

namespace ElementsLibrary.Circuits
{
    /// <summary>
    ///     Параллельное соединение цепи <see cref="ParallelSubcircuit" />
    /// </summary>
    public class ParallelSubcircuit : SubcircuitBase
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

            if (Nodes.Count <= 1)
            {
                throw new
                    ArgumentException("Для параллельного соединения нужно два элемента!");
            }

            var impedance = Complex.Zero;

            foreach (var nodeElements in Nodes)
            {
                 impedance += 1 / nodeElements.CalculateZ(frequency);
            }

            return 1 / impedance;
        }

        #endregion
    }
}