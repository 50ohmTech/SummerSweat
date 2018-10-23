using System;
using System.Windows.Forms;
using ElementsLibrary.Circuits;
using ElementsLibrary.Elements;

namespace ElementsLibrary
{
    /// <summary>
    ///     Модифицированный узел для TreeNode
    /// </summary>
    public class TreeViewNode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Значение
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="node"></param>
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
                    Text = $"[Послед] (Id:{series.UniqueId})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Паралл] (Id:{parallel.UniqueId})";
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
    }
}