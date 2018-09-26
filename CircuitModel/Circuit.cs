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
        /// Корень дерева.
        /// </summary>
        private INode _root;

        #endregion

        #region ~ Свойства ~

        public INode Root { get; set; }

        #endregion

        #region ~ Публичные методы ~

        #region Недописанная функция, в последствии будет исправлено.
        /// <summary>
        /// Добавление нового узла.
        /// </summary>
        /// <param name="node"> Узел. </param>
        /// <param name="newNode"> Новый узел. </param>
        //public void AddAfter(INode node, INode newNode)
        //{
        //    if (IsEmpty())
        //    {
        //        Root = newNode;
        //        return;
        //    }

        //    if (newNode == null)
        //    {
        //        throw new ArgumentNullException(nameof(newNode), 
        //            "Выбранный узел пуст.");
        //    }

        //}
        #endregion

        /// <summary>
        /// Расчет импеданса цепи для списка частот.
        /// </summary>
        /// <param name="frequencies"> Список частот сигнала. </param>
        /// <returns> Список импедансов цепи. </returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(
                    "Значение частоты должно быть больше нуля!");
            }

            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                impedances.Add(_root.CalculateZ(frequency));
            }
            return impedances;
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
