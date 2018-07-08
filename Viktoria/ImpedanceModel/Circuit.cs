﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceModel
{
    public class Circuit
    {
        #region -- Поля --

        /// <summary>
        ///     Список пассивных элементов
        /// </summary>
        public List<IElement> elements;

        public bool isAngular;

        #endregion

        #region -- Публичные методы --

        public Circuit()
        {
            elements = new List<IElement>();
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления цепи для диапазона частот
        /// </summary>
        /// <param name="minFrequency"> Минимальное значение частоты</param>
        /// <param name="maxFrequency"> Максимальное значение частоты</param>
        /// <param name="step"> Цена деления/Шаг</param>
        /// <returns> Список сопротивлений для каждой частоты из заданного диапазона с заданным шагом</returns>
        public List<Complex> CalculateImpedance(double minFrequency, double maxFrequency,
            double step)
        {
            var impedances = new List<Complex>();

            for (var i = minFrequency; i <= maxFrequency; i = i + step)
            {
                Complex impedance = 0;
                for (var n = 0; n <= elements.Count - 1; n++)
                {
                    var currentFrequency = i;
                    if (isAngular)
                    {
                        currentFrequency = i / (2 * Math.PI);
                    }
                    impedance += elements[n].CalculateImpedance(currentFrequency);
                }
                impedances.Add(impedance);
            }
            return impedances;
        }

        #endregion
    }
}