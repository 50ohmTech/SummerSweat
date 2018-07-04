using System;
using System.Collections.Generic;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Электрическая цепь.
    /// </summary>
    public class Circuit
    {
        #region - - Свойства - -

        /// <summary>
        /// Коллекция элементов цепи.
        /// </summary>
        public ElementsTree Elements { get; }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса Circuit.
        /// </summary>
        public Circuit(ElementsTree elements)
        {
            Elements = elements;
        }

        /// <summary>
        /// Расчитать импедансы цепи для списка частот.
        /// </summary>
        /// <param name="frequencies">Список частот сигнала.</param>
        /// <returns>Список импедансов цепи.</returns>
        public List<Complex> CalculateZ(List<double> frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedances.Add(Elements.CalculateZ(frequency));
            }

            return impedances;
        }

        #endregion
    }
}
