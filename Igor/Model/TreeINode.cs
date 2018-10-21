using System;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using Model.Elements;

namespace Model
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
                case SerialSubcircuit series:
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

