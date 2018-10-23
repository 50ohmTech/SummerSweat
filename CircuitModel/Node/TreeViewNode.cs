using System;
using System.Windows.Forms;

namespace CircuitModel
{
    /// <summary>
    /// Модифицируемый узел TreeNode.
    /// </summary>
    public class TreeViewNode : TreeNode
    {
        #region ~ Конструктор ~

        /// <summary>
        /// Конструктор класса TreeViewNode.
        /// </summary>
        /// <param name="node"> Узел дерева. </param>
        public TreeViewNode(INode node)
        {
            if (node == null)
            {
                return;
            }

            Value = node;

            switch (node)
            {
                case SerialSubcircuit series:
                    Text = $"[Послед] (Id:{series.uniqueID})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Паралл] (Id:{parallel.uniqueID})";
                    break;
                case Resistor resistor:
                    Text = $"({resistor.Name}) [{resistor.Value}]";
                    break;
                case Capacitor capacitor:
                    Text = $"({capacitor.Name}) [{capacitor.Value}]";
                    break;
                case Inductor inductor:
                    Text = $"({inductor.Name}) [{inductor.Value}]";
                    break;
                default:
                    throw new InvalidOperationException(nameof(node));
            }
        }

        #endregion

        #region ~ Свойства ~

        /// <summary>
        /// Значение.
        /// </summary>
        public INode Value { get; }

        #endregion

    }
}
