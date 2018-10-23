using System;
using System.Collections.Generic;
using System.Numerics;
using ElementsLibrary.Circuits;
using ElementsLibrary.Elements;

namespace ElementsLibrary
{
    /// <summary>
    ///     Класс электрическая цепь Circuit
    /// </summary>
    public class Circuit
    {
        #region Private fields

        /// <summary>
        ///     Список элементов цепи
        /// </summary>
        private List<ElementBase> _elements;

        #endregion

        #region Properties

        /// <summary>
        ///     Корень дерева
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод очистки
        /// </summary>
        public void Clean()
        {
            Root = null;
        }

        /// <summary>
        ///     Метод расчета полного импеданса цепи
        /// </summary>
        /// <param name="frequencies">Частота</param>
        /// <returns>Импеданс всей цепи</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedance = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedance.Add(Root.CalculateZ(frequency));
            }

            return impedance;
        }

        /// <summary>
        ///     Функция добавления
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="newNode"></param>
        public void AddAfter(INode currentNode, INode newNode)
        {
            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (currentNode is SubcircuitBase subcircuit)
            {
                subcircuit.Nodes.Add(newNode);

                if (newNode is SubcircuitBase newSubcircuit)
                {
                    newSubcircuit.Parent = subcircuit;
                }

                if (newNode is ElementBase newElementBase)
                {
                    newElementBase.Parent = subcircuit;
                }
            }
        }

        /// <summary>
        ///     Проверка на null
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        #endregion
    }
}