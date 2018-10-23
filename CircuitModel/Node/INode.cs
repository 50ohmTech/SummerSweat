using System.Collections.Generic;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Интерфейс узла дерева.
    /// </summary>
    public interface INode
    {
        #region ~ Публичные методы ~

        /// <summary>
        /// Расчет импеданса.
        /// </summary>
        /// <param name="frequency"> Значение частоты. </param>
        /// <returns> Комплексное сопротивление. </returns>
        Complex CalculateZ(double frequency);

        #endregion

        #region ~ Свойства ~

        /// <summary>
        /// Дочерние узлы.
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        /// Родитель элемента.
        /// </summary>
        INode Parent { get; set; }

        #endregion
    }
}
