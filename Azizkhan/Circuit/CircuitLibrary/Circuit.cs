using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;

namespace CircuitLibrary
{
    /// <summary>
    ///     Класс цепи
    /// </summary>
    internal class Circuit
    {
        #region Properties

        /// <summary>
        ///     Корень.
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Пуста ли цепь
        /// </summary>
        /// <returns>Пуста ли цепь</returns>
        public bool IsEmpty()
        {
            return Root == null || Root.Nodes.Count < 1;
        }

        /// <summary>
        ///     Очистить цепь
        /// </summary>
        public void Clear()
        {
            Root = null;
        }

        /// <summary>
        ///     Рассчитать импедансы.
        /// </summary>
        /// <param name="frequencies">Частоты.</param>
        /// <returns>Импедансы.</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (Root == null)
            {
                throw new NullReferenceException("В цепи нет элементов.");
            }

            return frequencies.Select(frequency => Root.CalculateZ(frequency)).ToList();
        }

        /// <summary>
        ///     Удаление ноды
        /// </summary>
        /// <param name="node">Удаляемый узел дерева</param>
        public void Remove(INode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "Пустой узел дерева!");
            }

            if (node == Root)
            {
                Root = null;
                return;
            }

            node.Parent.Nodes.Remove(node);
        }

        /// <summary>
        ///     Добавление новой ноды
        /// </summary>
        /// <param name="node">Нода, к которой добавляем</param>
        /// <param name="newNode">Нода, которую добавляем</param>
        public void AddAfter(INode node, INode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode),
                    "Нельзя добавить пустую ноду");
            }

            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (node is ElementBase)
            {
                throw new ArgumentException("Нельзя добавлять к элементу цепи!!");
            }

            if (node is SubcircuitBase subcircuit)
            {
                if (subcircuit.Nodes == null)
                {
                    throw new ArgumentNullException(nameof(subcircuit.Nodes),
                        "Дочерние ноды пусты!");
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