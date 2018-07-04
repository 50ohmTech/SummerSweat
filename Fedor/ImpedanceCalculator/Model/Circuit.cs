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
        /// <param name="node">Корень поддерева.</param>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns></returns>
        private Complex CalculateZ(ElementsTree.Node node, double frequency)
        {
            if (node.Brood.Count == 0)
            {
                return node.Element.CalculateZ(frequency);
            }

            var impedance = new Complex();
            if (node.IsSerial)
            {
                foreach (var child in node.Brood)
                {
                    impedance += 1 / CalculateZ(child, frequency);
                }

                return 1 / impedance;
            }
            else
            {
                foreach (var child in node.Brood)
                {
                    impedance += CalculateZ(child, frequency);
                }

                return impedance;
            }
        }

        #endregion
    }
}
