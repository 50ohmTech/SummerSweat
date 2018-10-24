using System;
using System.Collections.Generic;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary
{
    /// <summary>
    ///     Subcircuit of an electrical circuit
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Private fields

        /// <summary>
        ///     Parent node
        /// </summary>
        private INode _parent;

        #endregion

        #region Properties

        /// <summary>
        ///     Unique identifier
        /// </summary>
        public uint Id { get; }

        /// <summary>
        ///     Parent node
        /// </summary>
        public INode Parent
        {
            get => _parent;
            set
            {
                _parent = value;
                SubcircuitChanged?.Invoke(this,
                    new SubcircuitChangedEventArgs(value, "The parent was changed"));
            }
        }

        /// <summary>
        ///     Children node
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        #region Events

        /// <summary>
        ///     Event to change the parent
        /// </summary>
        private event EventHandler<SubcircuitChangedEventArgs> SubcircuitChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        protected SubcircuitBase(uint id)
        {
            Id = id;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of impedance
        /// </summary>
        /// <param name="frequency">Frequency</param>
        /// <returns>The complex impedance value</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}