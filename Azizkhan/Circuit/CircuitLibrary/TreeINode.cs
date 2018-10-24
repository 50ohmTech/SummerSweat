using System;
using System.Windows.Forms;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;

namespace CircuitLibrary
{
    /// <summary>
    ///     Модифицированный узел для TreeNode
    /// </summary>
    public class TreeINode : TreeNode
    {
        #region Properties

        /// <summary>
        ///     Значение
        /// </summary>
        public INode Value { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор узла TreeView
        /// </summary>
        /// <param name="treeNode">Узел</param>
        public TreeINode(INode treeNode, NodeType type)
        {
            Value = treeNode ?? throw new ArgumentNullException(nameof(treeNode));
            
            switch (treeNode)
            {
                case SerialSubcircuit series:
                    Text = $"[{type.ToString()}] (Id:{series.Id})";
                    break;
                case ParallelSubcircuit parallel:
                    Text = $"[{type.ToString()}] (Id:{parallel.Id})";
                    break;
                case Resistor resistor:
                    Text = $"[{type.ToString() + resistor.Name[1]}] = {resistor.Value}";
                    break;
                case Capacitor capacitor:
                    Text = $"[{type.ToString() + capacitor.Name[1]}] = {capacitor.Value}";
                    break;
                case Inductor inductor:
                    Text = $"[{type.ToString() + inductor.Name[1]}] = {inductor.Value}";
                    break;
                default:
                    throw new InvalidOperationException(nameof(treeNode));
            }
        }

        #endregion
    }
}