using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;

namespace Model.Circuit
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Private fields

        #region Fields

        #region Private fields

        /// <summary>
        ///     Корень цепи.
        /// </summary>
        private INode _root;

        #endregion

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Корень.
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Проверка на наличие элементов в цепи.
        /// </summary>
        /// <returns>Наличие элементов в цепи.</returns>
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
        ///     Расчитать импеданс цепи для списка частот.
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
                impedances.Add(Root.CalculateZ(frequency));
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
                throw new InvalidOperationException("Удалять нечего. Цепь пуста.");
            }

            if (node == null)
            {
                throw new ArgumentNullException(nameof(node),
                    "Попытка передачи неопределенного элемента в функцию.");
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
        /// </summary>
        /// <param name="node">Узел в который добавляют дочерние элемнты.</param>
        /// <param name="newNode">Новый узел.</param>
        public void AddAfter(INode node, INode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode),
                    "Новый узел не может быть неопределенным.");
            }

            if (node == newNode)
            {
                throw new ArgumentOutOfRangeException("Узел равен новому узлу.");
            }

            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (!IsEmpty() && node == null)
            {
                throw new ArgumentNullException(nameof(newNode),
                    "Выберите узел.");
            }

            if (node is ElementBase)
            {
                throw new ArgumentException("Выберите узел, а не элемент.");
            }

            if (node is SubcircuitBase subcircuit)
            {
                if (subcircuit.Nodes == null)
                {
                    throw new InvalidOperationException("Дети узла равны null.");
                }

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

        #endregion
    }
}