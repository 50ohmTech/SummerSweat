using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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

        #endregion

        //public bool TryRemove(ElementBase element)
        //{
        //    return false;
        //}

        //public void AddAfter(ElementBase element, ElementBase newElement)
        //{
        //}
    }
}