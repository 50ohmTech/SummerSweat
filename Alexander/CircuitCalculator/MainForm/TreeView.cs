using System;
using System.Windows.Forms;
using Model.Elements;
using Model.Circuit;

namespace MainForm
{
    /// <summary>
    /// Узел TreeView содержащий INode.
    /// </summary>
    public class CircuitTreeNode : TreeNode
    {
        #region Properties

        /// <summary>
        /// Значение.
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="node">Узел.</param>
        public CircuitTreeNode(INode node)
        {
            Value = node ?? throw new ArgumentNullException(nameof(node));

            Value = node;

            switch (node)
            {
                case SeriesSubcircuit series:
                    Text = $"[Последовательно] (Id:{series.Id})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Параллельно] (Id:{parallel.Id})";
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
