using System.Collections.Generic;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Узел
    /// </summary>
    public interface INode
    {
        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        Complex CalculateZ(double frequency);
    }
}