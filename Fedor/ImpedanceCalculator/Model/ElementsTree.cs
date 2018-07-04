using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Дерево элементов электрической цепи.
    /// </summary>
    public class ElementsTree
    {
        #region – – Внутренние классы – –

        /// <summary>
        /// Ячейка дерева.
        /// </summary>
        public class Node
        {
            #region - - Свойства - -

            /// <summary>
            /// Родительская ячейка.
            /// </summary>
            public Node Parent { get; set; }

            /// <summary>
            /// Список дочерних ячеек.
            /// </summary>
            public List<Node> Brood { get; set; }

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

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Корень дерева.
        /// </summary>
        public Node Root { get; }

        /// <summary>
        /// Количесвто элементов.
        /// </summary>
        public uint Count => GetCount(Root);

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса ElementsTree.
        /// </summary>
        public ElementsTree()
        {
            Root = new Node(null, null, false);
        }

        /// <summary>
        /// Добавить первый элемент в дерево.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        public void Add(ElementBase element)
        {
            if (Root.Brood.Count != 0) return;

            var node = new Node(element, Root, true);
            Root.Brood.Add(node);
            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(element, ChangedEventArgs.ChangeType.Add));
        }

        /// <summary>
        /// Добавить элемент в дерево.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="brotherName">Связующий элемент.</param>
        /// <param name="isSerial">Тип соединения.</param>
        public void Add(ElementBase element, string brotherName, bool isSerial)
        {
            var brother = Search(Root, brotherName);

            if (isSerial == brother.IsSerial)
            {
                var node = new Node(element, brother.Parent, isSerial);
                brother.Parent.Brood.Add(node);
            }
            else
            {
                var parentNode = new Node(null, brother.Parent, brother.IsSerial);
                var node = new Node(element, parentNode, isSerial);

                brother.Parent.Brood.Remove(brother);
                brother.Parent.Brood.Add(parentNode);

                brother.Parent = parentNode;
                brother.IsSerial = isSerial;

                parentNode.Brood.Add(brother);
                parentNode.Brood.Add(node);
            }

            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(element, ChangedEventArgs.ChangeType.Add));
        }

        /// <summary>
        /// Удалить элемент из дерева.
        /// </summary>
        /// <param name="elementName">Имя удаляемого элемента.</param>
        public void Delete(string elementName)
        {
            var elementNode = Search(Root, elementName);
            var parent = elementNode.Parent;

            if (parent == Root)
            {
                parent.Brood.Remove(elementNode);

                ElementsChanged?.Invoke(this,
                    new ChangedEventArgs(elementNode.Element, ChangedEventArgs.ChangeType.Delete));

                return;
            }

            if (parent.Brood.Count == 2)
            {
                var brother = parent.Brood[0] == elementNode
                    ? parent.Brood[1]
                    : parent.Brood[0];

                brother.Parent = parent.Parent;
                parent.Parent.Brood.Add(brother);
                parent.Parent.Brood.Remove(parent);
            }
            else
            {
                parent.Brood.Remove(elementNode);
            }

            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(elementNode.Element,
                    ChangedEventArgs.ChangeType.Delete));
        }

        /// <summary>
        /// Очистить дерево.
        /// </summary>
        public void Clear()
        {
            Root.Brood = new List<Node>();
            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(ChangedEventArgs.ChangeType.Clear));
        }

        /// <summary>
        /// Найти ячейку в дереве по имени элемента.
        /// </summary>
        /// <param name="node">Корень поддерева.</param>
        /// <param name="elementName">Имя элемента.</param>
        /// <returns>Ячейка дерева.</returns>
        public Node Search(Node node, string elementName)
        {
            if (node.Element != null)
            {
                if (node.Element.Name == elementName)
                {
                    return node;
                }
            }

            foreach (var child in node.Brood)
            {
                var searhNode = Search(child, elementName);
                if (searhNode != null)
                {
                    return searhNode;
                }
            }

            return null;
        }

        #endregion

        #region - - Приватные методы - -

        /// <summary>
        /// Получить количество элементов дерева.
        /// </summary>
        /// <param name="node">Корень поддерева.</param>
        /// <returns>Количество элементов.</returns>
        private uint GetCount(Node node)
        {
            if (node.Element != null)
            {
                return 1;
            }

            uint count = 0;
            foreach (var child in node.Brood)
            {
                count += GetCount(child);
            }

            return count;
        }

        #endregion

        #region - - События - -

        /// <summary>
        /// Событие, загорающееся при добавлении, удалении, очистке дерева.
        /// </summary>
        public event EventHandler<ChangedEventArgs> ElementsChanged;

        #endregion
    }
}
