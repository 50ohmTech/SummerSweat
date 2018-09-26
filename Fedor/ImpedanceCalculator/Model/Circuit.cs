using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Enums;
using Model.Tree;

namespace Model
{
    /// <summary>
    /// Электрическая цепь.
    /// </summary>
    public class Circuit
    {
        #region - - Поля - -

        /// <summary>
        /// Коллекция элементов цепи.
        /// </summary>
        private ElementsTree _elements;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Коллекция элементов цепи.
        /// </summary>
        public ElementsTree Elements
        {
            get => _elements;
            set => _elements = value ?? throw new ArgumentNullException(nameof(value));
        }

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
            if (root.Childs.Count == 0)
            {
                return root.Element.CalculateZ(frequency);
            }

            var impedance = new Complex();
            if (root.ConnectionType == ConnectionType.Serial)
            {
                foreach (var child in root.Childs)
                {
                    impedance += 1 / CalculateZ(child, frequency);
                }

                return 1 / impedance;
            }
            else
            {
                foreach (var child in root.Childs)
                {
                    impedance += CalculateZ(child, frequency);
                }

                return impedance;
            }
        }

        #endregion
    }
}
