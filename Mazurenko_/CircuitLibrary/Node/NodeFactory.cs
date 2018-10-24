using System;
using CircuitLibrary.Subcircuit;

namespace CircuitLibrary
{
    /// <summary>
    ///     Class for node creation
    /// </summary>
    public sealed class NodeFactory
    {
        #region Private fields

        /// <summary>
        ///     Capacitor counter
        /// </summary>
        private uint _capacitorCounter;

        /// <summary>
        ///     Connection id counter
        /// </summary>
        private uint _idCounter;

        /// <summary>
        ///     Inductor counter
        /// </summary>
        private uint _inductorCounter;

        /// <summary>
        ///     Resistor counter
        /// </summary>
        private uint _resistorCounter;

        #endregion

        #region Properties

        /// <summary>
        ///     Get a new name for the Resistor
        /// </summary>
        private string GetNameResistor => "R" + _resistorCounter++;

        /// <summary>
        ///     Get a new name for the Capacitor
        /// </summary>
        private string GetNameCapacitor => "C" + _capacitorCounter++;

        /// <summary>
        ///     Get a new name for the Inductor
        /// </summary>
        private string GetNameInductor => "L" + _inductorCounter++;

        /// <summary>
        ///     Connection id counter
        /// </summary>
        private uint IdCounter => _idCounter++;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public NodeFactory()
        {
            ResetCounter();
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Reset counter
        /// </summary>
        public void ResetCounter()
        {
            _capacitorCounter = 1;
            _inductorCounter = 1;
            _resistorCounter = 1;
            _idCounter = 1;
        }

        /// <summary>
        ///     Get a new element of node
        /// </summary>
        /// <param name="node">Type node</param>
        /// <param name="value">Value of node</param>
        /// <returns>New Node</returns>
        public INode GetElementNode(NodeType node, double value)
        {
            switch (node)
            {
                case NodeType.Parallel:
                {
                    return new ParallelSubcircuit(IdCounter);
                }
                case NodeType.Serial:
                {
                    return new SerialSubcircuit(IdCounter);
                }
                case NodeType.Resistor:
                {
                    return new Resistor(GetNameResistor, value);
                }
                case NodeType.Capacitor:
                {
                    return new Capacitor(GetNameCapacitor, value);
                }
                case NodeType.Inductor:
                {
                    return new Inductor(GetNameInductor, value);
                }
                default:
                {
                    throw new ArgumentException("Invalid node type");
                }
            }
        }

        #endregion
    }
}