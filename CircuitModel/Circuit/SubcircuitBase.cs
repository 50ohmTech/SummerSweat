using System.Collections.Generic;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Базовый класс подцепи.
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region  ~ Статические переменные ~

        /// <summary>
        /// Идентификатор.
        /// </summary>
        private static uint _globalID;

        #endregion

        #region ~ Конструктор ~

        /// <summary>
        /// Конструктор класса SubcircuitBase.
        /// </summary>
        public SubcircuitBase()
        {
            uniqueID = _globalID;
            _globalID++;
        }

        #endregion

        #region ~ Свойства ~

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public uint uniqueID { get; }

        /// <summary>
        /// Главный узел.
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        /// Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        /// Тип подключения.
        /// </summary>
        public NodeType NodeType { get; set; }

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Расчет импеланса.
        /// </summary>
        /// <param name="frequency"> Значение частоты. </param>
        /// <returns> Комплексное сопротивление. </returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}
