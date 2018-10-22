using System;
using CircuitLibrary.Elements;
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
        public static uint _capacitorIterator;

        /// <summary>
        ///     Итератор для I
        /// </summary>
        public static uint _inductorIterator;

        /// <summary>
        ///     Итератор для R
        /// </summary>
        public static uint _resistorIterator;

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        ///     Получить узел
        /// </summary>
        /// <param name="nodeType">Тип узла</param>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        /// <returns>Элемент</returns>
        public static INode GetNode(NodeType nodeType,
            double value)
        {
            INode newNode;
            switch (nodeType)
            {
                case NodeType.Resistor:
                    newNode = new Resistor("R" + _resistorIterator++, value);

                    break;
                case NodeType.Inductor:
                    newNode = new Inductor("I" + _inductorIterator++, value);

                    break;
                case NodeType.Capacitor:
                    newNode = new Capacitor("C" + _capacitorIterator++, value);

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
            SubcircuitBase._id =
                _inductorIterator = _capacitorIterator = _resistorIterator = 1;
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
                    var resistor1 = new Resistor("R1", 20);
                    var inductor2 = new Inductor("L2", 20);
                    var inductor3 = new Inductor("L3", 20);
                    var inductor4 = new Inductor("L4", 20);
                    var resistor5 = new Resistor("R5", 20);
                    var resistor6 = new Resistor("R6", 20);
                    var inductor7 = new Inductor("L7", 20);

                    var parallelSubcircuit1 = new ParallelSubcircuit();

                    var seriesSubcircuit1 = new SerialSubcircuit();
                    var seriesSubcircuit2 = new SerialSubcircuit();

                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit1);
                    seriesSubcircuit1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit2);
                    seriesSubcircuit2.Parent = parallelSubcircuit1;

                    var parallelSubcircuit2 = new ParallelSubcircuit();
                    var parallelSubcircuit3 = new ParallelSubcircuit();

                    seriesSubcircuit1.Nodes.Add(inductor3);
                    inductor3.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    parallelSubcircuit2.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit2;

                    seriesSubcircuit2.Nodes.Add(inductor2);
                    inductor2.Parent = seriesSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(resistor5);
                    resistor5.Parent = seriesSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Parent = seriesSubcircuit2;
                    parallelSubcircuit3.Nodes.Add(resistor6);
                    resistor6.Parent = parallelSubcircuit3;
                    parallelSubcircuit3.Nodes.Add(inductor7);
                    inductor7.Parent = parallelSubcircuit3;
                    circuit.AddAfter(null, parallelSubcircuit1);
                    break;
                }
                case 3:
                {
                    var resistor1 = new Resistor("R1", 1);
                    var capacitor2 = new Capacitor("C2", 20);
                    var resistor3 = new Resistor("R3", 20);
                    var inductor4 = new Inductor("L4", 20);
                    var resistor5 = new Resistor("R5", 20);
                    var inductor6 = new Inductor("L6", 20);

                    var seriesSubcircuit1 = new SerialSubcircuit();
                    var parallelSubcircuit1 = new ParallelSubcircuit();
                    var parallelSubcircuit2 = new ParallelSubcircuit();

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    seriesSubcircuit1.Nodes.Add(resistor3);
                    resistor3.Parent = seriesSubcircuit1;
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
                    circuit.AddAfter(null, seriesSubcircuit1);

                    break;
                }

                case 4:
                {
                    var resistor1 = new Resistor("R1", 20);
                    var capacitor2 = new Capacitor("C2", 20);
                    var resistor3 = new Resistor("R3", 20);
                    var inductor4 = new Inductor("L4", 20);
                    var resistor5 = new Resistor("R5", 20);
                    var inductor6 = new Inductor("L6", 20);
                    var resistor7 = new Resistor("R7", 20);
                    var inductor8 = new Inductor("L8", 20);

                    var seriesSubcircuit1 = new SerialSubcircuit();
                    var seriesSubcircuit2 = new SerialSubcircuit();
                    var parallelSubcircuit1 = new ParallelSubcircuit();
                    var parallelSubcircuit2 = new ParallelSubcircuit();
                    var parallelSubcircuit3 = new ParallelSubcircuit();
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Parent = seriesSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    resistor1.Parent = parallelSubcircuit1;
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    inductor4.Parent = parallelSubcircuit1;

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Parent = seriesSubcircuit1;
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    capacitor2.Parent = parallelSubcircuit2;
                    parallelSubcircuit2.Nodes.Add(seriesSubcircuit2);
                    seriesSubcircuit2.Parent = parallelSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Parent = seriesSubcircuit2;
                    seriesSubcircuit2.Nodes.Add(resistor7);
                    resistor7.Parent = seriesSubcircuit2;
                    parallelSubcircuit3.Nodes.Add(resistor5);
                    resistor5.Parent = parallelSubcircuit3;
                    parallelSubcircuit3.Nodes.Add(inductor8);
                    inductor8.Parent = parallelSubcircuit3;
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    inductor6.Parent = parallelSubcircuit2;
                    seriesSubcircuit1.Nodes.Add(resistor3);
                    resistor3.Parent = seriesSubcircuit1;

                    circuit.AddAfter(null, seriesSubcircuit1);
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