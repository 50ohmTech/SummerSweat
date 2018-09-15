﻿using System;
using System.Numerics;
using Model.Elements.Checks;

namespace Model.Elements
{
    /// <summary>
    ///     Катушка индуктивности.
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="inductance">Индуктивность.</param>
        public Inductor(string name, double inductance) : base(name, inductance)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента.
        /// </summary>
        /// <param name="frequency">Частоста.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Calculation.CheckFrequencies(frequency);
            double valueZ = 2 * Math.PI * frequency * Value;
            return new Complex(0, valueZ);
        }

        #endregion
    }
}