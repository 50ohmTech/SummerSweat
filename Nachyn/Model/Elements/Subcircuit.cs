using System.Collections.Generic;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Подцепь
    /// </summary>
    public abstract class Subcircuit : INode
    {
        #region Fields

        #region Static fields

        /// <summary>
        ///     Уникальный идентификатор
        /// </summary>
        private static int _id;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Уникальный идентификатор
        /// </summary>
        public int Id { get; } = _id;

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор
        /// </summary>
        protected Subcircuit()
        {
            _id++;
        }

        #endregion

        /// <summary>
        ///     Родитель
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        public abstract Complex CalculateZ(double frequency);
    }
}