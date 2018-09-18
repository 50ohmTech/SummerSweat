#region

using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;

#endregion

namespace Model
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Корень цепи.
        /// </summary>
        private INode _root;

        #endregion

        #endregion


        /// <summary>
        ///     Корень.
        /// </summary>
        public INode Root { get; private set; }

        #region Public methods

        /// <summary>
        ///     Проверка на наличие элементов в цепи.
        /// </summary>
        /// <returns>Есть ли в цепи элементы</returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        /// <summary>
        ///     Очистка цепи.
        /// </summary>
        public void Clear()
        {
            Root = null;
        }


        /// <summary>
        ///     Расчитать импедансы цепи для списка частот.
        /// </summary>
        /// <param name="frequencies">Список частот сигнала.</param>
        /// <returns>Список импедансов цепи.</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedances.Add(_root.CalculateZ(frequency));
            }

            return impedances;
        }

        /// <summary>
        ///     Удалить узел.
        /// </summary>
        /// <param name="node">Узел.</param>
        /// <returns>Удален ли узел.</returns>
        public void Remove(INode node)
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Цепь пуста. Удалять нечего.");
            }

            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Узел не может быть null, потому что в цепи есть узлы.");
            }

            if (node == Root)
            {
                Root = null;
                return;
            }

            node.Parent.Nodes.Remove(node);
        }

        /// <summary>
        ///     Добавить новый узел в дочерний элемент узла.
        ///     
        /// </summary>
        /// <param name="node">Узел в который добавляют дочерние элемнты.</param>
        /// <param name="newNode">Новый узел.</param>
        /// <param name="nodeType">Тип узла.</param>
        public void AddAfter(INode node, INode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "Новый узел не может быть не определен.");
            }

            if (node == newNode)
            {
                throw new ArgumentOutOfRangeException("Узел был равен новому узлу");
            }

            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (!IsEmpty() && node == null)
            {
                throw new ArgumentNullException(nameof(newNode), "Выберите узел относительно которого будет происходить добавление. Для добавления нового корня сделайте очистку цепи или удалите корень.");
            }

            if (node is ElementBase)
            {
                throw new ArgumentException("Узел не может быть элементом.");
            }

            if (node is SubcircuitBase subcircuit)
            {
                if (subcircuit.Nodes == null)
                {
                    throw new InvalidOperationException("Дети узла были null");
                }
                subcircuit.Nodes.Add(newNode);

                if (newNode is SubcircuitBase newSubcircuit)
                {
                    newSubcircuit.Parent = subcircuit;
                    ;
                }

                if (newNode is ElementBase newElementBase)
                {
                    newElementBase.Parent = subcircuit;
                }
            }
        }

        #endregion
    }
}