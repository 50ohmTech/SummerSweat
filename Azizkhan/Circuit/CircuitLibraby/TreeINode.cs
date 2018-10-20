using System;
using System.Windows.Forms;
using CircuitLibrary;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;

namespace CircuitLibraby
{
    public class TreeINode : TreeNode
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
        public TreeINode(INode node)
        {
            if (node == null)
            {
                return;
            }

            Value = node ?? throw new ArgumentNullException(nameof(node));

            Value = node;

            switch (node)
            {
                case SerialSubcircuit serial:
                    Text = $"[Послед] (Id:{serial.Id})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Паралл] (Id:{parallel.Id})";
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