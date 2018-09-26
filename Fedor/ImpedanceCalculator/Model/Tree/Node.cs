using System;
using System.Collections.Generic;
using Model.Elements;
using Model.Enums;

namespace Model.Tree
{
    /// <summary>
    /// Ячейка дерева.
    /// </summary>
    public class Node
    {
        #region - - Поля - -

        //TODO: Childs вместо Childs - brood это понятие из другой сферы
        //+
        /// <summary>
        /// Список дочерних ячеек.
        /// </summary>
        private List<Node> _childs;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Родительская ячейка.
        /// </summary>
        public Node Parent { get; set; }

        /// <summary>
        /// Список дочерних ячеек.
        /// </summary>
        public List<Node> Childs
        {
            get => _childs;
            set => _childs = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Значение ячейки.
        /// </summary>
        public ElementBase Element { get; }

        //TODO: Для таких вещей надо делать перечисления, а не булевы флаги
        //+
        /// <summary>
        /// Тип соединения.
        /// </summary>
        public ConnectionType ConnectionType { get; set; }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса Node.
        /// </summary>
        /// <param name="element">Значение ячейки.</param>
        /// <param name="parent">Родительская ячейка.</param>
        /// <param name="connectionType">Тип соединения.</param>
        public Node(ElementBase element, Node parent, ConnectionType connectionType)
        {
            ConnectionType = connectionType;
            Element = element;

            Parent = parent;
            Childs = new List<Node>();
        }

        #endregion
    }
}
