using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Интерфейс ноды.
    /// </summary>
    public interface INode
    {
        #region Properties

        /// <summary>
        ///     Список дочерних нод.
        /// </summary>
        List<INode> Nodes { get; set; }

        /// <summary>
        ///     Нода - родитель.
        /// </summary>
        INode Parent { get; set; }

        ///// <summary>
        /////     Типы элементов и соединений, которые могут быть в Node.
        ///// </summary>
        //NodeType Type { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        /// <param name="frequency"> Частота. </param>
        /// <returns> Значение комплексного сопротивления элемента. </returns>
        Complex CalculateZ(double frequency);

        #endregion
    }
}