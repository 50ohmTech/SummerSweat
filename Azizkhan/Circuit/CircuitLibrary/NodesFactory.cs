using System;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuit;
using CircuitLibrary.Subcircuits;

namespace CircuitLibrary
{
    /// <summary>
    ///     Фабрика узлов цепи
    /// </summary>
    public class NodesFactory
    {
        #region Fields

        #region Static fields

        /// <summary>
        ///     Итератор для C
        /// </summary>
        public static uint CapacitorIterator;

        /// <summary>
        ///     Итератор для I
        /// </summary>
        public static uint InductorIterator;

        /// <summary>
        ///     Итератор для R
        /// </summary>
        public static uint ResistorIterator;

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        ///     Получить узел
        /// </summary>
        /// <param name="nodeType">Тип узла</param>
        /// <param name="value">Номинал</param>
        /// <returns>Элемент</returns>
        public static INode GetNode(NodeType nodeType,
            double value)
        {
            INode newNode;
            switch (nodeType)
            {
                case NodeType.Resistor:
                    newNode = new Resistor("R" + ResistorIterator++, value);

                    break; //TODO: неправильное именование элемента

                //+
                case NodeType.Inductor:
                    newNode = new Inductor("L" + InductorIterator++, value);

                    break;
                case NodeType.Capacitor:
                    newNode = new Capacitor("C" + CapacitorIterator++, value);

                    break;
                case NodeType.Parallel:
                    newNode = new ParallelSubcircuit();
                    break;
                case NodeType.Serial:
                    newNode = new SerialSubcircuit();
                    break;
                default:
                    throw new ArgumentException("Некорректный тип узла.");
            }

            return newNode;
        }

        /// <summary>
        ///     Обнулить все итераторы
        /// </summary>
        public static void IteratorsToZero()
        {
            InductorIterator = CapacitorIterator = ResistorIterator = 1;
        }

        /// <summary>
        ///     Получить статически заданную цепь
        /// </summary>
        /// <param name="circuitIndex">Индекс цепи</param>
        /// <returns>Цепь</returns>
        public static Circuit GetCircuit(int circuitIndex)
        {
            SubcircuitBase parallelSubcircuit = new ParallelSubcircuit();
            SubcircuitBase serialSubcircuit = new SerialSubcircuit();
            var circuit = new Circuit();
            IteratorsToZero();
            switch (circuitIndex)
            {
                case 0:
                {
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit,
                        GetNode(NodeType.Inductor, 5));

                    circuit.AddAfter(serialSubcircuit,
                        GetNode(NodeType.Resistor, 5));

                    circuit.AddAfter(serialSubcircuit, parallelSubcircuit);
                    circuit.AddAfter(parallelSubcircuit, GetNode(NodeType.Inductor, 10));
                    circuit.AddAfter(parallelSubcircuit, GetNode(NodeType.Resistor, 10));
                    break;
                }


                case 1:
                {
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit, parallelSubcircuit);
                    circuit.AddAfter(parallelSubcircuit, GetNode(NodeType.Capacitor, 10));
                    SubcircuitBase secondSerialSubcircuit = new SerialSubcircuit();
                    circuit.AddAfter(parallelSubcircuit, secondSerialSubcircuit);
                    circuit.AddAfter(secondSerialSubcircuit,
                        GetNode(NodeType.Inductor, 20));

                    SubcircuitBase secondParallelSubcircuit = new ParallelSubcircuit();
                    circuit.AddAfter(secondSerialSubcircuit, secondParallelSubcircuit);
                    circuit.AddAfter(secondParallelSubcircuit,
                        GetNode(NodeType.Resistor, 13.5));

                    circuit.AddAfter(secondParallelSubcircuit,
                        GetNode(NodeType.Inductor, 13.5));

                    break;
                }
                case 2:
                {
                    var resistor1 = GetNode(NodeType.Resistor, 20);
                    var inductor2 = GetNode(NodeType.Inductor, 20);
                    var inductor3 = GetNode(NodeType.Inductor, 20);
                    var inductor4 = GetNode(NodeType.Inductor, 20);
                    var resistor5 = GetNode(NodeType.Resistor, 20);
                    var resistor6 = GetNode(NodeType.Resistor, 20);
                    var inductor7 = GetNode(NodeType.Inductor, 20);

                    var parallelSubcircuit1 = new ParallelSubcircuit();

                    var serialSubcurcuit = new SerialSubcircuit();
                    var serialSubcurcuit2 = new SerialSubcircuit();

                    parallelSubcircuit1.Nodes.Add(serialSubcurcuit);
                    serialSubcurcuit.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(serialSubcurcuit2);
                    serialSubcurcuit2.Parent = parallelSubcircuit1;

                    var parallelSubcircuit2 = new ParallelSubcircuit();
                    var parallelSubcircuit3 = new ParallelSubcircuit();

                    serialSubcurcuit.Nodes.Add(inductor3);
                    inductor3.Parent = serialSubcurcuit;
                    serialSubcurcuit.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = serialSubcurcuit;
                    parallelSubcircuit2.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit2;

                    serialSubcurcuit2.Nodes.Add(inductor2);
                    inductor2.Parent = serialSubcurcuit2;
                    serialSubcurcuit2.Nodes.Add(resistor5);
                    resistor5.Parent = serialSubcurcuit2;
                    serialSubcurcuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Parent = serialSubcurcuit2;
                    parallelSubcircuit3.Nodes.Add(resistor6);
                    resistor6.Parent = parallelSubcircuit3;
                    parallelSubcircuit3.Nodes.Add(inductor7);
                    inductor7.Parent = parallelSubcircuit3;
                    circuit.AddAfter(null, parallelSubcircuit1);
                    break;
                }
                case 3:
                {
                    var resistor1 = GetNode(NodeType.Resistor, 20);
                    var capacitor2 = GetNode(NodeType.Capacitor, 20);
                    var resistor3 = GetNode(NodeType.Resistor, 20);
                    var inductor4 = GetNode(NodeType.Inductor, 20);
                    var resistor5 = GetNode(NodeType.Resistor, 20);
                    var inductor6 = GetNode(NodeType.Inductor, 20);

                    var serialSubcurcuit = new SerialSubcircuit();
                    var parallelSubcircuit1 = new ParallelSubcircuit();
                    var parallelSubcircuit2 = new ParallelSubcircuit();

                    serialSubcurcuit.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = serialSubcurcuit;
                    serialSubcurcuit.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = serialSubcurcuit;
                    serialSubcurcuit.Nodes.Add(resistor3);
                    resistor3.Parent = serialSubcurcuit;
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit1;
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    capacitor2.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(resistor5);
                    resistor5.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    inductor6.Parent = parallelSubcircuit2;
                    circuit.AddAfter(null, serialSubcurcuit);

                    break;
                }

                case 4:
                {
                    var resistor1 = GetNode(NodeType.Resistor, 20);
                    var capacitor2 = GetNode(NodeType.Capacitor, 20);
                    var resistor3 = GetNode(NodeType.Resistor, 20);
                    var inductor4 = GetNode(NodeType.Inductor, 20);
                    var resistor5 = GetNode(NodeType.Resistor, 20);
                    var inductor6 = GetNode(NodeType.Inductor, 20);
                    var resistor7 = GetNode(NodeType.Resistor, 20);
                    var inductor8 = GetNode(NodeType.Inductor, 20);

                    var serialSubcurcuit1 = new SerialSubcircuit();
                    var serialSubcurcuit2 = new SerialSubcircuit();
                    var parallelSubcircuit1 = new ParallelSubcircuit();
                    var parallelSubcircuit2 = new ParallelSubcircuit();
                    var parallelSubcircuit3 = new ParallelSubcircuit();
                    serialSubcurcuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = serialSubcurcuit1;
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit1;

                    serialSubcurcuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = serialSubcurcuit1;
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    capacitor2.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(serialSubcurcuit2);
                    serialSubcurcuit2.Parent = parallelSubcircuit2;
                    serialSubcurcuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Parent = serialSubcurcuit2;
                    serialSubcurcuit2.Nodes.Add(resistor7);
                    resistor7.Parent = serialSubcurcuit2;
                    parallelSubcircuit3.Nodes.Add(resistor5);
                    resistor5.Parent = parallelSubcircuit3;
                    parallelSubcircuit3.Nodes.Add(inductor8);
                    inductor8.Parent = parallelSubcircuit3;
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    inductor6.Parent = parallelSubcircuit2;
                    serialSubcurcuit1.Nodes.Add(resistor3);
                    resistor3.Parent = serialSubcurcuit1;

                    circuit.AddAfter(null, serialSubcurcuit1);
                    break;
                }


                default:
                    throw new ArgumentException("Некорректный номер цепи.");
            }

            return circuit;
        }

        #endregion
    }
}