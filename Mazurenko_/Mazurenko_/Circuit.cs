using System;
using System.Collections.Generic;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary
{
    /// <summary>
    ///     Electrical circuit
    /// </summary>
    public class Circuit
    {
        #region Private fields

        /// <summary>
        ///     Root node
        /// </summary>
        private INode _root;

        #endregion

        #region Properties

        /// <summary>
        ///     Root node
        /// </summary>
        public INode Root { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///     Event, when changing one of the elements of the electrical circuit
        /// </summary>
        public event ValueStateEventHandler CircuitChanged;

        #endregion

        #region Public methods

        /// <summary>
        ///     Calculation of complex resistance
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns>The complex impedance value</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies),
                    " Frequency list empty");
            }

            var result = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                result.Add(_root.CalculateZ(frequency));
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
        /// <param name="node"></param>
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
        /// <param name="node"></param>
        /// <param name="newNode"></param>
        public void AddAfter(INode node, INode newNode)
        {
            if (newNode == null)
            {
                throw new ArgumentNullException(nameof(newNode), "The node is empty");
            }

            if (IsEmpty())
            {
                Root = newNode;
                return;
            }

            if (node is ElementBase)
            {
                throw new ArgumentException("Error! Node cannot be an element !");
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