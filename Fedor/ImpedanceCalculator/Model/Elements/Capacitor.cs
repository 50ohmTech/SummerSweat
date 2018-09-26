﻿using Model.Validators;
using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    /// Конденсатор.
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса Capacitor.
        /// </summary>
        /// <param name="name">Имя элемента.</param>
        /// <param name="value">Номинал элемента.</param>
        public Capacitor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns>Комплексное значение импеданса.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Validator.CheckFrequency(frequency);

            return new Complex(0, -1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}