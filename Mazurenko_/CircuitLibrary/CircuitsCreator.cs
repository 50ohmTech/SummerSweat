using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitLibrary;
using CircuitLibrary.Subcircuit;

namespace CircuitView
{
    public sealed class CircuitsCreator
    {
        #region Ordinary fields

        /// <summary>
        ///     List of all electrical circuits
        /// </summary>
        public List<Circuit> Circuits;

        #endregion

        #region Public methods

        public INode GetNodeType(NodeType node, double value,Circuit ss)
        {            
            switch (node)
            {
                case NodeType.Parallel:
                {
                    return new ParallelSubcircuit();
                }
                case NodeType.Serial:
                {
                    return new SerialSubcircuit();
                }
                case NodeType.Resistor:
                {
                    return new Resistor(ss.GetNameResistor, value);
                }
                case NodeType.Capacitor:
                {
                    return new Capacitor(ss.GetNameCapacitor, value);
                }
                case NodeType.Inductor:
                {
                    return new Inductor(ss.GetNameInductor, value);
                }
                default:
                {
                    throw new ArgumentException("Invalid node type");
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CircuitsCreator()
        {                   
            InitializeCircuits();
        } 

        /// <summary>
        ///     Initialization of all electrical circuits
        /// </summary>
        private void InitializeCircuits()
        {
            Circuits = new List<Circuit>();

            var firstCircuit = new Circuit();
            
            SubcircuitBase serialSubcircuit1 = new SerialSubcircuit();            
            firstCircuit.AddAfter(null, serialSubcircuit1);
            firstCircuit.AddAfter(serialSubcircuit1,
                new Resistor(firstCircuit.GetNameResistor, 10));
            firstCircuit.AddAfter(serialSubcircuit1,
                new Resistor(firstCircuit.GetNameResistor, 23));

            SubcircuitBase parallelSubcircuit1 = new ParallelSubcircuit();
            firstCircuit.AddAfter(serialSubcircuit1, parallelSubcircuit1);
            firstCircuit.AddAfter(parallelSubcircuit1,
                new Inductor(firstCircuit.GetNameInductor, 55));
            firstCircuit.AddAfter(serialSubcircuit1,
                new Capacitor(firstCircuit.GetNameCapacitor, 22));
            Circuits.Add(firstCircuit);            

            var secondCircuit = new Circuit();            
            SubcircuitBase serialSubcircuit2 = new SerialSubcircuit();
            secondCircuit.AddAfter(null, serialSubcircuit2);
            secondCircuit.AddAfter(serialSubcircuit2,
                new Resistor(secondCircuit.GetNameResistor, 130));
            secondCircuit.AddAfter(serialSubcircuit2, new Inductor(secondCircuit.GetNameInductor, 52));

            SubcircuitBase parallelSubcircuit21 = new ParallelSubcircuit();
            secondCircuit.AddAfter(serialSubcircuit2, parallelSubcircuit21);
            secondCircuit.AddAfter(parallelSubcircuit21,
                new Inductor(secondCircuit.GetNameInductor, 44));
            secondCircuit.AddAfter(serialSubcircuit2, new Resistor(secondCircuit.GetNameResistor, 52));
            SubcircuitBase parallelSubcircuit22 = new ParallelSubcircuit();
            secondCircuit.AddAfter(serialSubcircuit2, parallelSubcircuit22);
            secondCircuit.AddAfter(parallelSubcircuit22, new Capacitor(secondCircuit.GetNameCapacitor, 52));
            Circuits.Add(secondCircuit);

            var thirtCircuit = new Circuit();
            SubcircuitBase serialSubcircuitThird = new SerialSubcircuit();
            SubcircuitBase parallelSubcircuitThird = new ParallelSubcircuit();
            thirtCircuit.AddAfter(null, serialSubcircuitThird);
            thirtCircuit.AddAfter(serialSubcircuitThird, new Capacitor(thirtCircuit.GetNameCapacitor, 3));
            thirtCircuit.AddAfter(serialSubcircuitThird, new Inductor(thirtCircuit.GetNameInductor, 5));
            thirtCircuit.AddAfter(serialSubcircuitThird, parallelSubcircuitThird);
            thirtCircuit.AddAfter(parallelSubcircuitThird, new Inductor(thirtCircuit.GetNameInductor, 32));
            thirtCircuit.AddAfter(serialSubcircuitThird, new Resistor(thirtCircuit.GetNameResistor, 5));
            Circuits.Add(thirtCircuit);            

            var fourCircuit = new Circuit();
            SubcircuitBase serialSubcircuitFour = new SerialSubcircuit();
            SubcircuitBase parallelSubcircuitFour = new ParallelSubcircuit();

            fourCircuit.AddAfter(null, serialSubcircuitFour);
            fourCircuit.AddAfter(serialSubcircuitFour, new Inductor(fourCircuit.GetNameInductor, 3));
            fourCircuit.AddAfter(serialSubcircuitFour, new Resistor(fourCircuit.GetNameResistor, 21));
            fourCircuit.AddAfter(serialSubcircuitFour, parallelSubcircuitFour);
            fourCircuit.AddAfter(parallelSubcircuitFour, new Inductor(fourCircuit.GetNameInductor, 94));
            fourCircuit.AddAfter(serialSubcircuitFour, new Resistor(fourCircuit.GetNameResistor, 2));
            Circuits.Add(fourCircuit);            

            var fiveCircuit = new Circuit();
            SubcircuitBase serialSubcircuitFive = new SerialSubcircuit();
            SubcircuitBase parallelSubcircuitFive = new ParallelSubcircuit();

            fiveCircuit.AddAfter(null, serialSubcircuitFive);
            fiveCircuit.AddAfter(serialSubcircuitFive, new Resistor(fiveCircuit.GetNameResistor, 3));
            fiveCircuit.AddAfter(serialSubcircuitFive, new Resistor(fiveCircuit.GetNameResistor, 5));
            fiveCircuit.AddAfter(serialSubcircuitFive, parallelSubcircuitFive);
            fiveCircuit.AddAfter(parallelSubcircuitFive, new Inductor(fiveCircuit.GetNameInductor, 3));
            Circuits.Add(fiveCircuit);            
        }

        #endregion
    }
}