﻿using System;
using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Катушка индуктивности.
    /// </summary>
    internal class Inductor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        /// <param name="name"> Название элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        /// <param name="frequency"> Частота. </param>
        /// <returns> Значение комплексного сопротивления элемента. </returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}