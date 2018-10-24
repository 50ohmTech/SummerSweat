using System.Collections.Generic;

namespace CircuitLibrary
{
    /// <summary>
    ///     Electrical circuits list class
    /// </summary>
    public sealed class CircuitsCreator
    {
        #region Properties

        /// <summary>
        ///     List of all electrical circuits
        /// </summary>
        public List<Circuit> Circuits { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public CircuitsCreator()
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
            var serial = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(null, serial);
            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            circuit.AddAfter(serial,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            var parallelFirst = circuit.NodeCreate.GetElementNode(NodeType.Parallel, 0);
            var serialParallelFirst =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(serial, parallelFirst);
            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 20));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 20));

            var serialParallelSecond =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

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
            var serial = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);
            circuit.AddAfter(null, serial);

            var parallelFirst = circuit.NodeCreate.GetElementNode(NodeType.Parallel, 0);
            circuit.AddAfter(serial, parallelFirst);

            var serialParallelFirst =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 10));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 10));

            var serialParallelSecond =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(parallelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 10));

            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 10));

            var serialParallelThird =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

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
            var serial = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);
            var parallelFirst = circuit.NodeCreate.GetElementNode(NodeType.Parallel, 0);
            circuit.AddAfter(null, serial);
            circuit.AddAfter(serial, parallelFirst);

            var serialParallelFirst =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(parallelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Capacitor, 50));

            var serialParallelSecond =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(parallelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            var serialParallelThird =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(parallelFirst, serialParallelThird);
            circuit.AddAfter(serialParallelThird,
                circuit.NodeCreate.GetElementNode(NodeType.Inductor, 50));

            circuit.AddAfter(serialParallelThird,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 50));

            var serialParallelFour =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

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
            var serial = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);
            var parallelFirst = circuit.NodeCreate.GetElementNode(NodeType.Parallel, 0);
            var serialParallelFirst =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            var serialParallelSecond =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

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
            var serialFirst = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);
            var paralllelFirst = circuit.NodeCreate.GetElementNode(NodeType.Parallel, 0);
            var serialParallelFirst =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(null, serialFirst);
            circuit.AddAfter(serialFirst, paralllelFirst);
            circuit.AddAfter(paralllelFirst, serialParallelFirst);
            circuit.AddAfter(serialParallelFirst,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 20));

            var serialParallelSecond =
                circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);

            circuit.AddAfter(paralllelFirst, serialParallelSecond);
            circuit.AddAfter(serialParallelSecond,
                circuit.NodeCreate.GetElementNode(NodeType.Resistor, 10));

            var subParallel = circuit.NodeCreate.GetElementNode(NodeType.Parallel, 0);
            circuit.AddAfter(serialParallelSecond, subParallel);
            var subSerialFirst = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);
            var subSerialSecond = circuit.NodeCreate.GetElementNode(NodeType.Serial, 0);
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