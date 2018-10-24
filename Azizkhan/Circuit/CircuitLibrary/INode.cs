using System.Collections.Generic;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    ///     Узел дерева
    /// </summary>
    public interface INode
    {
        #region Properties

        /// <summary>
        ///     Узел-родитель
        /// </summary>
        INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        List<INode> Nodes { get; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        Complex CalculateZ(double frequency);

        #endregion
    }
}