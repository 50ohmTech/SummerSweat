﻿using System;
using CircuitLibrary.Elements;
using CircuitLibrary.Subcircuits;

namespace CircuitLibrary
{
    public class NodesFactory
    {
        #region Fields

        #region Static fields

        public static uint _capacitorIterator;
        public static uint _inductorIterator;
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

        public static void IteratorsToZero()
        {
            SubcircuitBase._id =
                _inductorIterator = _capacitorIterator = _resistorIterator = 0;
        }

        public static Circuit GetCircuit(int index)
        {
            SubcircuitBase parallelSubcircuit = new ParallelSubcircuit();
            SubcircuitBase serialSubcircuit = new SerialSubcircuit();
            var circuit = new Circuit();
            switch (index)
            {
                case 0:
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit,
                        new Resistor("R" + _resistorIterator++, 1));

                    circuit.AddAfter(serialSubcircuit,
                        new Resistor("R" + _resistorIterator++, 5.5));

                    circuit.AddAfter(serialSubcircuit, parallelSubcircuit);
                    circuit.AddAfter(parallelSubcircuit,
                        new Resistor("R" + _resistorIterator++, 6.2));

                    break;
                case 1:
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 55.1));

                    circuit.AddAfter(serialSubcircuit,
                        new Resistor("R" + _resistorIterator++, 34.5));

                    circuit.AddAfter(serialSubcircuit,
                        new Inductor("L" + _inductorIterator++, 6.2));

                    break;
                case 2:
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit, parallelSubcircuit);
                    circuit.AddAfter(parallelSubcircuit,
                        new Resistor("R" + _resistorIterator++, 56));

                    circuit.AddAfter(parallelSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 59.1));

                    circuit.AddAfter(parallelSubcircuit,
                        new Resistor("R" + _resistorIterator++, 33.3));

                    break;
                case 3:
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit,
                        new Resistor("R" + _resistorIterator++, 22));

                    circuit.AddAfter(serialSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 59.1));

                    circuit.AddAfter(serialSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 33.3));

                    circuit.AddAfter(serialSubcircuit,
                        new Resistor("R" + _resistorIterator++, 11.34));

                    break;
                case 4:
                    circuit.AddAfter(null, serialSubcircuit);
                    circuit.AddAfter(serialSubcircuit,
                        new Resistor("R" + _resistorIterator++, 22));

                    circuit.AddAfter(serialSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 59.1));

                    circuit.AddAfter(serialSubcircuit,
                        new Capacitor("C" + _capacitorIterator++, 33.3));

                    circuit.AddAfter(serialSubcircuit, parallelSubcircuit);
                    circuit.AddAfter(parallelSubcircuit,
                        new Resistor("R" + _resistorIterator++, 99.2));

                    break;
                default:
                    throw new ArgumentException("Некорректный номер цепи.");
            }

            IteratorsToZero();

            return circuit;
        }

        #endregion
    }
}