using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;
using Model.Events;

namespace Model.Circuit
{
    /// <summary>
    /// Подцепь.
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Fields

        #region Static fields

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        private static int _id;

        #endregion

        #region Ordinary fields

        /// <summary>
        /// Родитель.
        /// </summary>
        public INode _parent;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; } = _id;

        /// <summary>
        /// Родитель.
        /// </summary>
        public INode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                ParentChanged?.Invoke(this,
                    new SubcircuitEventArgs("Изменен родитель", value));
            }
        }

        /// <summary>
        /// Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        #region Events

        /// <summary>
        /// Событие на изменение родителя.
        /// </summary>
        public event EventHandler<SubcircuitEventArgs> ParentChanged;

        /// <summary>
        /// Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Номинал импеданса.</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор.
        /// </summary>
        protected SubcircuitBase()
        {
            _id++;
        }

        #endregion
    }
}