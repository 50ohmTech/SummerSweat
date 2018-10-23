using System.Collections.Generic;
using CircuitLibrary.Subcircuit;

namespace CircuitLibrary
{
    public sealed class CircuitsCreate
    {
        #region Ordinary fields

        /// <summary>
        ///     List of all electrical circuits
        /// </summary>
        public List<Circuit> Circuits;

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public CircuitsCreate()
        {
            InitializeCircuits();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Initialization of all electrical circuits
        /// </summary>
        private void InitializeCircuits()
        {
            Circuits = new List<Circuit>
            {
                new Circuit(),
                GetFirstTestCircuit(),
                GetSecondTestCircuit(),
                GetThirdTestCircuit(),
                GetFourthTestCircuit(),
                GetFifthTestCircuit()
            };
        }

        /// <summary>
        ///     Get first test circuit
        /// </summary>
        /// <returns>First test circuit</returns>
        private Circuit GetFirstTestCircuit()
        {
            var circuit = new Circuit();
            SubcircuitBase serial = new SerialSubcircuit();
            circuit.AddAfter(null, serial);
            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            SubcircuitBase parallelFirst = new ParallelSubcircuit();
            SubcircuitBase serialParallelFirst = new SerialSubcircuit();

            circuit.AddAfter(serial, parallelFirst);
            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 20));

            SubcircuitBase serialParallelSecond = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 20));

            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            return circuit;
        }

        /// <summary>
        ///     Get second test circuit
        /// </summary>
        /// <returns>Second test circuit</returns>
        private Circuit GetSecondTestCircuit()
        {
            var circuit = new Circuit();
            SubcircuitBase serial = new SerialSubcircuit();
            circuit.AddAfter(null, serial);

            SubcircuitBase parallelFirst = new ParallelSubcircuit();
            circuit.AddAfter(serial, parallelFirst);

            SubcircuitBase serialParallelFirst = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 10));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 10));

            SubcircuitBase serialParallelSecond = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 10));

            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 10));

            SubcircuitBase serialParallelThird = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelThird);
            circuit.AddAfter(serialParallelThird,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 10));

            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 10));

            return circuit;
        }

        /// <summary>
        ///     Get third test circuit
        /// </summary>
        /// <returns>Third test circuit</returns>
        private Circuit GetThirdTestCircuit()
        {
            var circuit = new Circuit();
            SubcircuitBase serial = new SerialSubcircuit();
            SubcircuitBase parallelFirst = new ParallelSubcircuit();
            circuit.AddAfter(null, serial);
            circuit.AddAfter(serial, parallelFirst);

            SubcircuitBase serialParallelFirst = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 50));

            SubcircuitBase serialParallelSecond = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            SubcircuitBase serialParallelThird = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelThird);
            circuit.AddAfter(serialParallelThird,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 50));

            circuit.AddAfter(serialParallelThird,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            SubcircuitBase serialParallelFour = new SerialSubcircuit();
            circuit.AddAfter(parallelFirst, serialParallelFour);
            circuit.AddAfter(serialParallelFour,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            circuit.AddAfter(serialParallelFour,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 50));

            circuit.AddAfter(serialParallelFour,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            return circuit;
        }

        /// <summary>
        ///     Get fourth test circuit
        /// </summary>
        /// <returns>Fourth test circuit</returns>
        private Circuit GetFourthTestCircuit()
        {
            var circuit = new Circuit();
            SubcircuitBase serial = new SerialSubcircuit();
            SubcircuitBase parallelFirst = new ParallelSubcircuit();
            SubcircuitBase serialParallelFirst = new SerialSubcircuit();
            SubcircuitBase serialParallelSecond = new SerialSubcircuit();
            circuit.AddAfter(null, serial);
            circuit.AddAfter(serial, parallelFirst);
            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(parallelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            return circuit;
        }

        /// <summary>
        ///     Get fifth test circuit
        /// </summary>
        /// <returns>Fifth test circuit</returns>
        private Circuit GetFifthTestCircuit()
        {
            var circuit = new Circuit();
            SubcircuitBase serialFirst = new SerialSubcircuit();
            SubcircuitBase paralllelFirst = new ParallelSubcircuit();
            SubcircuitBase serialParallelFirst = new SerialSubcircuit();
            circuit.AddAfter(null, serialFirst);
            circuit.AddAfter(serialFirst, paralllelFirst);
            circuit.AddAfter(paralllelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            SubcircuitBase serialParallelSecond = new SerialSubcircuit();
            circuit.AddAfter(paralllelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 10));

            SubcircuitBase subParallel = new ParallelSubcircuit();
            circuit.AddAfter(serialParallelSecond, subParallel);
            SubcircuitBase subSerialFirst = new SerialSubcircuit();
            SubcircuitBase subSerialSecond = new SerialSubcircuit();
            circuit.AddAfter(subParallel, subSerialFirst);
            circuit.AddAfter(subSerialFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(subParallel, subSerialSecond);
            circuit.AddAfter(subSerialSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(serialFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(serialFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            return circuit;
        }

        #endregion
    }
}