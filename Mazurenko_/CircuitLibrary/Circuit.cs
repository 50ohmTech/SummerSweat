using System;
using System.Collections.Generic;
using System.Numerics;

namespace CircuitLibrary
{
    /// <summary>
    ///     Electrical circuit
    /// </summary>
    public class Circuit
    {
        #region Readonly fields

        /// <summary>
        ///     Create element of node
        /// </summary>
        public readonly NodeCreate NodeCreate;

        #endregion

        #region Properties

        /// <summary>
        ///     Root node
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public Circuit()
        {
            NodeCreate = new NodeCreate();
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of complex resistance
        /// </summary>
        /// <param name="frequencies">Frequency</param>
        /// <returns>The complex impedance value</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies),
                    "Frequency list is empty");
            }

            var result = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                result.Add(Root.CalculateZ(frequency));
            }

            return result;
        }

        /// <summary>
        ///     Checking the presence of electrical circuit elements
        /// </summary>
        /// <returns>Are there elements in the electrical circuit?</returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        /// <summary>
        ///     Cleaning the electrical circuit
        /// </summary>
        public void Clear()
        {
            Root = null;
        }

        /// <summary>
        ///     Removing a node
        /// </summary>
        /// <param name="node">Node to remove</param>
        public void Remove(INode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node), "The node is empty");
            }

            if (node == Root)
            {
                Root = null;
                return;
            }

            node.Parent.Nodes.Remove(node);
        }

        /// <summary>
        ///     Adding a new node
        /// </summary>
        /// <param name="node">The node to which is adding node </param>
        /// <param name="newNode">New node</param>
        public void AddAfter(INode node, INode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The newNode is empty");
            }

            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (node is ElementBase)
            {
                throw new ArgumentException(
                    "You cannot add to the element of an electric circuit");
            }

            if (node is SubcircuitBase subcircuit)
            {
                if (subcircuit.Nodes == null)
                {
                    throw new ArgumentNullException(nameof(subcircuit.Nodes),
                        "Children nodes is null");
                }

                subcircuit.Nodes.Add(newNode);
                if (newNode is SubcircuitBase newSubcircuit)
                {
                    newSubcircuit.Parent = subcircuit;
                }

                if (newNode is ElementBase newElementBase)
                {
                    newElementBase.Parent = subcircuit;
                }
            }
        }

        #endregion
    }
}