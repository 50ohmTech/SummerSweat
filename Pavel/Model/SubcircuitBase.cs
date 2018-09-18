using System.Collections.Generic;
using System.Numerics;
using Model.Elements;

namespace Model
{
    /// <summary>
    ///     Делегат хранящий подписчиков события ValueChanged
    /// </summary>
    /// <param name="value">Изменившееся значение</param>
    /// <param name="сhangedElement">Изменившийся элемент</param>
    public delegate void SubcircuitEventHandler(object value, object сhangedElement);

    /// <summary>
    ///     Подцепь.
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Fields

        #region Static fields

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        private static int _id;

        #endregion

        #region Ordinary fields

        /// <summary>
        ///     Родитель
        /// </summary>
        public INode _parent;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public int Id { get; } = _id;

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode Parent
        {
            get => _parent;
            set => _parent = value;
        }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        #region Events

        /// <summary>
        ///     Событие на изменение родителя.
        /// </summary>
        public event SubcircuitEventHandler ParentChanged;

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        protected SubcircuitBase()
        {
            _id++;
        }

        #endregion
    }
}