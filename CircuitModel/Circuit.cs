using System;
using System.Collections.Generic;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Класс цепи.
    /// </summary>
    public class Circuit
    {
        #region ~ Приватные переменные ~

        /// <summary>
        /// Список элементов цепи.
        /// </summary>
        private List<ElementBase> _elements;

        #endregion

        #region ~ Свойства ~

        public INode Root { get; private set; }

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Добавление нового узла.
        /// </summary>
        /// <param name="currentNode"> Узел. </param>
        /// <param name="newNode"> Новый узел. </param>
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
        /// Расчет импеданса цепи для списка частот.
        /// </summary>
        /// <param name="frequencies"> Список частот сигнала. </param>
        /// <returns> Список импедансов цепи. </returns>
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
        /// Удаление электрической цепи.
        /// </summary>
        public void Clear()
        {
            Root = null;
        }

        /// <summary>
        /// Проверка: присутствует ли элемент в цепи.
        /// </summary>
        /// <returns> Результат: да или нет. </returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        /// <summary>
        /// Удаление элемента.
        /// </summary>
        public void Remove(INode node)
        {
            if (node == Root)
            {
                Root = null;
                return;
            }

            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), 
                    "Выбранный узел пустой.");
            }

            node.Parent.Nodes.Remove(node);
        }

        #endregion
    }
}
