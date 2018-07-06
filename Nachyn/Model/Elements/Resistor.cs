﻿using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор
    /// </summary>
    public class Resistor : ElementBase
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="resistance">Сопротивление</param>
        public Resistor(string name, double resistance = 0) : base(name, resistance)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency < 1 || frequency > 1000000000000)
            {
                throw new ArgumentException(
                    "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
            }

            return new Complex(Value, 0);
        }
    }
}