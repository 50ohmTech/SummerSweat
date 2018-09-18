using System;
using System.Windows.Forms;
using Model.Elements;

namespace Model.TreeView
{
    //TODO: Неудачное название. Лучше тогда CircuitTreeNode
    /// <summary>
    ///     Узел TreeView содержащий INode.
    /// </summary>
    public class NodeTreeNode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Значение.
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="node">Нода.</param>
        public NodeTreeNode(INode node)
        {
            Value = node ?? throw new ArgumentNullException(nameof(node));

            Value = node;

            switch (node)
            {
                case SeriesSubcircuit series:
                    Text = $"[Послед] (Id:{series.Id})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Паралл] (Id:{parallel.Id})";
                    break;
                case Resistor resistor:
                    Text = $"[R] [{resistor.Value}] ({resistor.Name})";
                    break;
                case Capacitor capacitor:
                    Text = $"[C] [{capacitor.Value}] ({capacitor.Name})";
                    break;
                case Inductor inductor:
                    Text = $"[L] [{inductor.Value}] ({inductor.Name})";
                    break;
                default:
                    throw new InvalidOperationException(nameof(node));
            }
        }

        #endregion
    }
}