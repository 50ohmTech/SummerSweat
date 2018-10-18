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

        #region Readonly fields

        /// <summary>
        ///     Глобальный ID
        /// </summary>
        private readonly int _global;

        #endregion

        #region Ordinary fields

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode _parent;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Уникальный идентификатор.
        /// </summary>
        public uint Id { get; } = _id;

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                SubcircuitChanged?.Invoke(this,
                    new SubcircuitChangedEventArgs("Родитель изменен", value));
            }
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
        //NOTE: XML ?
        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}