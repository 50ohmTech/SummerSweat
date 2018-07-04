using System;
using System.Collections.Generic;
using System.Numerics;

namespace Model
{
    public class ElementsTree
    {
        public class Node
        {
            public Node Parent { get; set; }
            public List<Node> Brood { get; set; }

            public Element Element { get; }
            public bool IsSerial { get; set; }

            public Node(Element element, Node parent, bool isSerial)
            {
                IsSerial = isSerial;
                Element = element;

                Parent = parent;
                Brood = new List<Node>();
            }
        }

        public Node Root { get;}

        public uint Count => GetCount(Root);

        public ElementsTree()
        {
            Root = new Node(null, null, false);
        }

        public Complex CalculateZ(double frequency)
        {
            return CalculateZ(Root, frequency);
        }

        private Complex CalculateZ(Node node, double frequency)
        {
            if (node.Brood.Count == 0)
            {
                return node.Element.CalculateZ(frequency);
            }

            var impedance = new Complex();
            if (node.IsSerial)
            {
                foreach (var child in node.Brood)
                {
                    impedance += 1 / CalculateZ(child, frequency);
                }

                return 1 / impedance;
            }
            else
            {
                foreach (var child in node.Brood)
                {
                    impedance += CalculateZ(child, frequency);
                }

                return impedance;
            }

        }

        public void Add(Element element)
        {
            if (Root.Brood.Count == 0)
            {
                var node = new Node(element, Root, true);
                Root.Brood.Add(node);
                ElementsChanged?.Invoke(this,
                    new ChangedEventArgs(element, ChangedEventArgs.ChangeType.Add));
            }
        }

        public void Add(Element element, string brotherName, bool isSerial)
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

        public void Clear()
        {
            Root.Brood = new List<Node>();
            ElementsChanged?.Invoke(this,
                new ChangedEventArgs(ChangedEventArgs.ChangeType.Clear));
        }

        private Node Search(Node node, string elementName)
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

        private uint GetCount(Node node)
        {
            if (node.Brood.Count == 0)
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

        public event EventHandler<ChangedEventArgs> ElementsChanged;
    }
}
