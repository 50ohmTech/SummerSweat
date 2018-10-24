using System;
using System.Collections.Generic;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary.Subcircuits
{
    /// <summary>
    ///     Базовый класс узла подцепи
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Fields

        #region Static fields

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        private static uint _id;

        #endregion

        #region Ordinary fields

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode parent;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public uint Id { get; } = _id;

        /// <inheritdoc />
        public INode Parent
        {
            get => parent;
            set
            {
                if (value != parent)
                {
                    parent = value;
                    SubcircuitChanged?.Invoke(this,
                        new SubcircuitChangedEventArgs("Родитель изменен", value));
                }
            }
        }

        /// <inheritdoc />
        public abstract NodeType Type { get; }

        /// <inheritdoc />
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        #region Events

        //TODO: событие срабатывает только при изменении родителя, но не срабатывает при изменении дочерних элементов. Исправить
        /// <summary>
        ///     Событие на изменение родителя.
        /// </summary>
        public event EventHandler<SubcircuitChangedEventArgs> SubcircuitChanged;

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

        #region Public methods

        /// <inheritdoc />
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}