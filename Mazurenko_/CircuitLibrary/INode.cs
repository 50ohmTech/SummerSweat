using System.Collections.Generic;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    ///     Interface of node
    /// </summary>
    public interface INode
    {
        #region Properties

        /// <summary>
        ///     List of child nodes
        /// </summary>
        List<INode> Nodes { get; set; }

        /// <summary>
        ///     Parent node
        /// </summary>
        INode Parent { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of complex resistance
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        Complex CalculateZ(double f);

        #endregion
    }
}