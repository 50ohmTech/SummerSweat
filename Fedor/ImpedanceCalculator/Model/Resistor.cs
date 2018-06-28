﻿using System.Numerics;

namespace Model
{
    /// <summary>
    /// Резистор.
    /// </summary>
    public class Resistor : Element
    {
        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса Resistor.
        /// </summary>
        /// <param name="name">Имя элемента.</param>
        /// <param name="value">Номинал элемента.</param>
        public Resistor(string name, double value) : base(name, value)
        {
        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns>Комплексное значение импеданса.</returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(Value, 0);
        }

        #endregion
    }
}