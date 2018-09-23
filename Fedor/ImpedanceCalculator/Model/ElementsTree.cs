using System;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// Дерево элементов электрической цепи.
    /// </summary>
    public class ElementsTree
    {
        #region - - Свойства - -

        /// <summary>
        /// Корень дерева.
        /// </summary>
        public Node Root { get; }

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
        /// Конструктор класса ElementsTree.
        /// </summary>
        public ElementsTree()
        {
            //TODO: а нельзя сразу инициализировать поле при объявлении?
            Root = new Node(null, null, false);
        }

        /// <summary>
        /// Добавить первый элемент в дерево.
        /// </summary>
        /// <param name="element">Элемент электрической цепи.</param>
        public void Add(ElementBase element)
        {
            if (Root.Brood.Count != 0)
            {
                throw new InvalidCastException(
                    "Метод добавления первого элемента можно использовать только для пустого дерева");
            }

            var node = new Node(element, Root, true);
            Root.Brood.Add(node);
            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(element, ChangeType.Add));
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
                new ChangedEventArgs(element, ChangeType.Add));
        }

        /// <summary>
        /// Удалить элемент из дерева.
        /// </summary>
        /// <param name="elementName">Имя удаляемого элемента.</param>
        public void Delete(string elementName)
        {
            var elementNode = Search(Root, elementName);
            var parent = elementNode.Parent;

            if (parent != Root && parent.Brood.Count == 2)
            {
                var brother = parent.Brood[0] == elementNode
                    ? parent.Brood[1]
                    : parent.Brood[0];

                if (brother.Element != null)
                {
                    brother.Parent = parent.Parent;
                    parent.Parent.Brood.Add(brother);
                }
                else
                {
                    foreach (var child in brother.Brood)
                    {
                        child.Parent = parent.Parent;
                        parent.Parent.Brood.Add(child);
                    }
                }

                parent.Parent.Brood.Remove(parent);
            }
            else
            {
                parent.Brood.Remove(elementNode);
            }

            UpdateName(Root, elementName);

            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(elementNode.Element,
                    ChangeType.Delete));
        }

        /// <summary>
        /// Очистить дерево.
        /// </summary>
        public void Clear()
        {
            Root.Brood = new List<Node>();
            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(ChangeType.Clear));
        }

        //TODO: Search - искать, Find - найти
        /// <summary>
        /// Найти ячейку в дереве по имени элемента.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="elementName">Имя элемента.</param>
        /// <returns>Ячейка дерева.</returns>
        public Node Search(Node root, string elementName)
        {
            if (root.Element != null)
            {
                if (root.Element.Name == elementName)
                {
                    return root;
                }
            }

            foreach (var child in root.Brood)
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
            if (root.Element != null)
            {
                return types.Contains(root.Element.GetType()) ? 1 : (uint) 0;
            }

            uint count = 0;
            foreach (var child in root.Brood)
            {
                count += GetCount(child, types);
            }

            return count;
        }

        //TODO: Так метод меняет имя или удаляет элемент? Разберись с именами переменных и комментариями
        /// <summary>
        /// Обновить имя элемента цепи.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        /// <param name="deleteName">Имя удаляемого элемента.</param>
        private void UpdateName(Node root, string deleteName)
        {
            if (root.Element != null)
            {
                var number = uint.Parse(root.Element.Name.Substring(1));
                var deleteNumber = uint.Parse(deleteName.Substring(1));

                if (root.Element.Name[0] != deleteName[0] || number <= deleteNumber) return;

                number--;
                root.Element.Name = root.Element.Name[0] + number.ToString();
                return;
            }

            foreach (var child in root.Brood)
            {
                UpdateName(child, deleteName);
            }
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
