using System;
using System.Windows.Forms;
using Model;
using Model.Elements;

namespace MainForm
{
    /// <summary>
    ///     Узел TreeView содержащий INode.
    /// </summary>
    public class CircuitTreeNode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Значение.
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="node">Нода.</param>
        public CircuitTreeNode(INode node)
        {
            Value = node ?? throw new ArgumentNullException(nameof(node));

            Value = node;

            switch (node)
            {
                case SeriesSubcircuit series:
                    Text = "[Последовательное]";
                    break;
                case ParallelSubcircuit parallel:
                    Text = "[Параллельное]";
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