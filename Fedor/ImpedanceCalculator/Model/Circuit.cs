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
                impedances.Add(CalculateZ(Elements.Root, frequency));
            }

            return impedances;
        }

        #endregion

        #region – – Приватные методы – –

        /// <summary>
        /// Расчитать импеданс цепи рекурсивно.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns></returns>
        private Complex CalculateZ(Node root, double frequency)
        {
            if (root.Brood.Count == 0)
            {
                return root.Element.CalculateZ(frequency);
            }

            var impedance = new Complex();
            if (root.IsSerial)
            {
                foreach (var child in root.Brood)
                {
                    impedance += 1 / CalculateZ(child, frequency);
                }

                return 1 / impedance;
            }
            else
            {
                foreach (var child in root.Brood)
                {
                    impedance += CalculateZ(child, frequency);
                }

                return impedance;
            }
        }

        #endregion
    }
}
