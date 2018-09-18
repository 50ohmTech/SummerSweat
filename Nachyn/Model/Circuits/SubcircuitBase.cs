using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;
using Model.Events;

namespace Model.Circuits
{
    //TODO: цепи - это тоже не элементы. Должны быть в отдельной папке(+)
    /// <summary>
    ///     Подцепь.
    /// </summary>
    public abstract class SubcircuitBase : ICircuitNode
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
        public ICircuitNode _parent;

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
        public ICircuitNode Parent
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
        public List<ICircuitNode> Nodes { get; } = new List<ICircuitNode>();

        #endregion

        #region Events

        /// <summary>
        ///     Событие на изменение родителя.
        /// </summary>
        public event EventHandler<SubcircuitParentEventArgs> ParentChanged;

        /// <summary>
        ///     Рассчитать импеданс.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns>Импеданс.</returns>
        public abstract Complex CalculateZ(double frequency);

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
    }
}