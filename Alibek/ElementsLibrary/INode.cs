using System.Collections.Generic;
using System.Numerics;

namespace ElementsLibrary
{
    /// <summary>
    ///     Интерфейс узла дерева <see cref="INode" />
    /// </summary>
    public interface INode
    {
        #region Properties

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        ///     Главный узел
        /// </summary>
        INode Parent { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод расчета импеданса в ноде <see cref="CalculateZ" />
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        Complex CalculateZ(double frequency);

        #endregion
    }
}