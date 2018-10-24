﻿#region

using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using Model.Elements;

#endregion

namespace Model
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Properties

        /// <summary>
        /// Количество элементов.
        /// </summary>
        public uint Count => GetCount(Root,
            new List<Type>() { typeof(Resistor), typeof(Capacitor), typeof(Inductor) });

        /// <summary>
        /// Количество резисторов.
        /// </summary>
        public uint ResistorCount => GetCount(Root, new List<Type>() { typeof(Resistor) });

        /// <summary>
        /// Количество конденсаторов.
        /// </summary>
        public uint CapacitorCount => GetCount(Root, new List<Type>() { typeof(Capacitor) });

        /// <summary>
        /// Количество катушек индуктивности.
        /// </summary>
        public uint InductorCount => GetCount(Root, new List<Type>() { typeof(Inductor) });

        /// <summary>
        ///     Корень.
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Проверка на наличие элементов в цепи.
        /// </summary>
        /// <returns>Есть ли в цепи элементы.</returns>
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

            var impedance = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedance.Add(Root.CalculateZ(frequency));
            }

            return impedance;
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
                throw new ArgumentNullException(nameof(node),
                    "Попытка передачи неопределенного элемента в функцию.");
            }

            if (node == Root)
            {
                Root = null;
                return;
            }

            node.Parent.Nodes.Remove(node);

            UpdateName(Root, (node as ElementBase).Name );
        }

        private uint GetCount(INode root, ICollection<Type> types)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (root is ElementBase)
            {
                return types.Contains(root.GetType()) ? 1 : (uint)0;
            }

            uint count = 0;
            foreach (var child in root.Nodes)
            {
                count += GetCount(child, types);
            }

            return count;
        }

        /// <summary>
        /// Обновить имена элементов цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="deleteName">Имя удаленного элемента.</param>
        private void UpdateName(INode root, string deleteName)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (root is ElementBase elementBase)
            {
                var number = uint.Parse(elementBase.Name.Substring(1));
                var deleteNumber = uint.Parse(deleteName.Substring(1));

                if (elementBase.Name[0] != deleteName[0] || number <= deleteNumber) return;

                number--;
                elementBase.Name = elementBase.Name[0] + number.ToString();
                return;
            }

            foreach (var child in root.Nodes)
            {
                UpdateName(child, deleteName);
            }
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
                    "Новый узел не может быть не определен.");
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