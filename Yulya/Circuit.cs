using System;
using System.Collections.Generic;
using System.Numerics;

namespace Yulya
{
    /// <summary>
    /// Класс цепи (Circuit).
    /// </summary>
    public class Circuit
    {
        #region Свойства

        /// <summary>
        /// Список элементов цепи.
        /// </summary>
        public List<Element> Elements { get; }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса Circuit.
        /// </summary>
        public Circuit(List<Element> elements)
        {
            Elements = elements;
        }

        /// <summary>
        /// Расчитать импедансы цепи для списка частот.
        /// </summary>
        /// <param name="frequencies">Список частот сигнала.</param>
        /// <returns>Список импедансов цепи.</returns>
        public List<Complex> GetImpedance(List<double> frequencies)
        {
            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                var impedance = new Complex();

                foreach (var element in Elements)
                {
                    impedance += element.GetImpedance(frequency);
                }

                impedances.Add(impedance);
            }

            return impedances;
        }

        #endregion
    }
}
