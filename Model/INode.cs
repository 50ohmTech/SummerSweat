using System.Collections.Generic;
using System.Numerics;

namespace Model
{
    internal interface INode
    {
        #region Properties

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        ///     Родитель.
        /// </summary>
        INode Parent { get; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Подсчет комлпксного сопротивления.
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns></returns>
        Complex CalculateZ(double frequency);

        #endregion
    }
}