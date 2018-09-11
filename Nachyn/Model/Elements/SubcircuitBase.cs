using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements.Events;

namespace Model.Elements
{
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

        public INode _parent;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public int Id { get; } = _id;

        #endregion

        #region Events

        public event EventHandler<SubcircuitParentEventArgs> ParentChanged;

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        protected SubcircuitBase()
        {
            _id++;
        }

        #endregion

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                ParentChanged?.Invoke(this,
                    new SubcircuitParentEventArgs("Родитель изменен", value));
            }
        }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public abstract Complex CalculateZ(double frequency);
    }
}