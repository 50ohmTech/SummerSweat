using System.Collections.Generic;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    ///     Subcircuit of an electrical circuit
    /// </summary>
    public abstract class SubcircuitBase : INode
    {
        #region Static fields

        /// <summary>
        ///     Unique identifier
        /// </summary>
        private static uint _id;

        #endregion

        #region Properties

        /// <summary>
        ///     Unique identifier
        /// </summary>
        public uint ID { get; } = _id;

        /// <summary>
        ///     Children node
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        ///     Parent node
        /// </summary>
        public INode Parent { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        protected SubcircuitBase()
        {
            _id++;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Calculation of impedance
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>The complex impedance value</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}