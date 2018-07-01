using System;
using System.Numerics;
using System.Collections.Generic;

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
        public List<Element> Elements { get; }

        #endregion

        #region – – Публичные методы – –

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
        public List<Complex> CalculateZ(List<double> frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                var impedance = new Complex();

                foreach (var element in Elements)
                {
                    impedance += element.CalculateZ(frequency);
                }

                impedances.Add(impedance);
            }

            return impedances;
        }

        #endregion

        #region – – События – –

        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event EventHandler<ChangedEventArgs> CircuitChanged;

        #endregion
    }
}
