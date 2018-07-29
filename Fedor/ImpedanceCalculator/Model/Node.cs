using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Ячейка дерева.
    /// </summary>
    public class Node
    {
        #region - - Поля - -

        /// <summary>
        /// Список дочерних ячеек.
        /// </summary>
        private List<Node> _brood;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Родительская ячейка.
        /// </summary>
        public Node Parent { get; set; }

        /// <summary>
        /// Список дочерних ячеек.
        /// </summary>
        public List<Node> Brood
        {
            get => _brood;
            set => _brood = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Значение ячейки.
        /// </summary>
        public ElementBase Element { get; }

        /// <summary>
        /// Тип соединения.
        /// </summary>
        public bool IsSerial { get; set; }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса Node.
        /// </summary>
        /// <param name="element">Значение ячейки.</param>
        /// <param name="parent">Родительская ячейка.</param>
        /// <param name="isSerial">Тип соединения.</param>
        public Node(ElementBase element, Node parent, bool isSerial)
        {
            IsSerial = isSerial;
            Element = element;

            Parent = parent;
            Brood = new List<Node>();
        }

        #endregion
    }
}
