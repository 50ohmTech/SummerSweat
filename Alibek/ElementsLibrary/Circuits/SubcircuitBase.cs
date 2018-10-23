using System.Collections.Generic;
using System.Numerics;

namespace ElementsLibrary.Circuits
{
    /// <summary>
    ///     Базовый класс подцепи 
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Static fields

        /// <summary>
        ///     Идентификатор
        /// </summary>
        private static uint _globalId;

        #endregion

        #region Properties

        /// <summary>
        ///     Идентификатор
        /// </summary>
        public uint UniqueId { get; }

        /// <summary>
        ///     Тип подключения
        /// </summary>
        public NodeType NodeType { get; set; }

        /// <summary>
        ///     Главный узел
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор
        /// </summary>
        public SubcircuitBase()
        {
            UniqueId = _globalId;
            _globalId++;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет импеданса <see cref="CalculateZ" />
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}