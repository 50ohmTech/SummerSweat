using System.Collections.Generic;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Узел
    /// </summary>
    public interface INode
    {
        #region Properties

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        ///     Родитель
        /// </summary>
        INode Parent { get; }

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