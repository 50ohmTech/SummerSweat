using System.Collections.Generic;
using System.Numerics;


namespace ElementsLibrary.Circuits
{
    /// <summary>
    /// Базовый класс подцепи <see cref="SubcircuitBase"/>
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Static fields

        /// <summary>
        ///     Идентификатор
        /// </summary>
        private static uint _globalID;

        #endregion

        #region Properties

        /// <summary>
        ///     Идентификатор
        /// </summary>
        public uint uniqueID { get; }

        /// <summary>
        ///     Главный узел
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        ///     Тип подключения
        /// </summary>
        public NodeType NodeType { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор
        /// </summary>
        public SubcircuitBase()
        {
            uniqueID = _globalID;
            _globalID++;
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