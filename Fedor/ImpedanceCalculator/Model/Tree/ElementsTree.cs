using Model.Elements;
using Model.Enums;
using Model.EventArgs;
using System;
using System.Collections.Generic;

namespace Model.Tree
{
    /// <summary>
    /// Дерево элементов электрической цепи.
    /// </summary>
    public class ElementsTree
    {
        #region - - Свойства - -

        //TODO: а нельзя сразу инициализировать поле при объявлении?
        //+
        /// <summary>
        /// Корень дерева.
        /// </summary>
        public Node Root { get; } = new Node(null, null, ConnectionType.Parallel);

        /// <summary>
        /// Количество элементов.
        /// </summary>
        public uint Count => GetCount(Root,
            new List<Type>() {typeof(Resistor), typeof(Capacitor), typeof(Inductor)});

        /// <summary>
        /// Количество резисторов.
        /// </summary>
        public uint ResistorCount => GetCount(Root, new List<Type>() { typeof(Resistor)});

        /// <summary>
        /// Количество конденсаторов.
        /// </summary>
        public uint CapacitorCount => GetCount(Root, new List<Type>() { typeof(Capacitor)});

        /// <summary>
        /// Количество катушек индуктивности.
        /// </summary>
        public uint InductorCount => GetCount(Root, new List<Type>() { typeof(Inductor)});

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Добавить первый элемент в дерево.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        public void Add(ElementBase element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (Root.Childs.Count != 0)
            {
                throw new InvalidCastException(
                    "Метод добавления первого элемента можно использовать только для пустого дерева");
            }

            var node = new Node(element, Root, ConnectionType.Serial);
            Root.Childs.Add(node);
            ElementsChanged?.Invoke(this,
                new ElementChangeEventArgs(element, ElementsChangeType.Add));
        }

        /// <summary>
        /// Добавить элемент в дерево.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="brotherName">Связующий элемент.</param>
        /// <param name="connectionType">Тип соединения.</param>
        public void Add(ElementBase element, string brotherName, ConnectionType connectionType)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            var brother = Search(Root, brotherName);

            if (connectionType == brother.ConnectionType)
            {
                var node = new Node(element, brother.Parent, connectionType);
                brother.Parent.Childs.Add(node);
            }
            else
            {
                var parentNode = new Node(null, brother.Parent, brother.ConnectionType);
                var node = new Node(element, parentNode, connectionType);

                brother.Parent.Childs.Remove(brother);
                brother.Parent.Childs.Add(parentNode);

                brother.Parent = parentNode;
                brother.ConnectionType = connectionType;

                parentNode.Childs.Add(brother);
                parentNode.Childs.Add(node);
            }

            ElementsChanged?.Invoke(this,
                new ElementChangeEventArgs(element, ElementsChangeType.Add));
        }

        /// <summary>
        /// Удалить элемент из дерева.
        /// </summary>
        /// <param name="elementName">Имя удаляемого элемента.</param>
        public void Delete(string elementName)
        {
            var elementNode = Search(Root, elementName);
            var parent = elementNode.Parent;

            if (parent != Root && parent.Childs.Count == 2)
            {
                var brother = parent.Childs[0] == elementNode
                    ? parent.Childs[1]
                    : parent.Childs[0];

                if (brother.Element != null)
                {
                    brother.Parent = parent.Parent;
                    parent.Parent.Childs.Add(brother);
                }
                else
                {
                    foreach (var child in brother.Childs)
                    {
                        child.Parent = parent.Parent;
                        parent.Parent.Childs.Add(child);
                    }
                }

                parent.Parent.Childs.Remove(parent);
            }
            else
            {
                parent.Childs.Remove(elementNode);
            }

            UpdateName(Root, elementName);

            ElementsChanged?.Invoke(this,
                new ElementChangeEventArgs(elementNode.Element,
                    ElementsChangeType.Delete));
        }

        /// <summary>
        /// Очистить дерево.
        /// </summary>
        public void Clear()
        {
            Root.Childs = new List<Node>();
            ElementsChanged?.Invoke(this,
                new ElementChangeEventArgs(ElementsChangeType.Clear));
        }

        //TODO: Search - искать, Find - найти
        //+
        /// <summary>
        /// Искать ячейку в дереве по имени элемента.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="elementName">Имя элемента.</param>
        /// <returns>Ячейка дерева.</returns>
        public Node Search(Node root, string elementName)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (root.Element != null)
            {
                if (root.Element.Name == elementName)
                {
                    return root;
                }
            }

            foreach (var child in root.Childs)
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
        /// <param name="root">Корень поддерева.</param>
        /// <param name="types">Типы элементов.</param>
        /// <returns>Количество элементов.</returns>
        private uint GetCount(Node root, ICollection<Type> types)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (root.Element != null)
            {
                return types.Contains(root.Element.GetType()) ? 1 : (uint) 0;
            }

            uint count = 0;
            foreach (var child in root.Childs)
            {
                count += GetCount(child, types);
            }

            return count;
        }

        //TODO: Так метод меняет имя или удаляет элемент? Разберись с именами переменных и комментариями
        //+
        /// <summary>
        /// Обновить имена элементов цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="deleteName">Имя удаленного элемента.</param>
        private void UpdateName(Node root, string deleteName)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            if (root.Element != null)
            {
                var number = uint.Parse(root.Element.Name.Substring(1));
                var deleteNumber = uint.Parse(deleteName.Substring(1));

                if (root.Element.Name[0] != deleteName[0] || number <= deleteNumber) return;

                number--;
                root.Element.Name = root.Element.Name[0] + number.ToString();
                return;
            }

            foreach (var child in root.Childs)
            {
                UpdateName(child, deleteName);
            }
        }

        #endregion

        #region - - События - -

        /// <summary>
        /// Событие, загорающееся при добавлении, удалении, очистке дерева.
        /// </summary>
        public event EventHandler<ElementChangeEventArgs> ElementsChanged;

        #endregion
    }
}
