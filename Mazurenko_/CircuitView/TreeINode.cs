using System;
using System.Windows.Forms;
using CircuitLibrary;
using CircuitLibrary.Subcircuit;

namespace CircuitView
{
    /// <summary>
    ///     Tree element class
    /// </summary>
    public class TreeINode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Value
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="node">Node</param>
        public TreeINode(INode node)
        {
            Value = node ?? throw new ArgumentNullException(nameof(node));

            switch (Value)
            {
                case SerialSubcircuit serial:
                    Text = $"[Serial] ID: {serial.Id}";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[Parallel] ID:{parallel.Id}";
                    break;
                case Resistor resistor:
                    Text = $"[{resistor.Name}] ({resistor.Value})";
                    break;
                case Capacitor capacitor:
                    Text = $"[{capacitor.Name}] ({capacitor.Value})";
                    break;
                case Inductor inductor:
                    Text = $"[{inductor.Name}] ({inductor.Value})";
                    break;
                default:
                    throw new ArgumentException(
                        "The transferred node does not correspond to the proposed elections");
            }
        }

        #endregion
    }
}