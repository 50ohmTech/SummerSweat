﻿using Model;
using Model.Elements;
using Model.Elements.Types;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Класс проверки цепей")]
    internal class CircuitTests
    {
        #region Public methods

        [Test(Description = "Тест правильности расчета сложной цепи")]
        public void NodeTest()
        {
            SeriesSubcircuit seriesRoot = new SeriesSubcircuit();
            SeriesSubcircuit seriesLeftOne = new SeriesSubcircuit();
            SeriesSubcircuit seriesRightOne = new SeriesSubcircuit();

            ParallelSubcircuit parallelLeftOne = new ParallelSubcircuit();
            ParallelSubcircuit parallelLeftTwo = new ParallelSubcircuit();

            seriesRoot.Nodes.Add(parallelLeftOne);
            seriesRoot.Nodes.Add(seriesRightOne);

            parallelLeftOne.Nodes.Add(new Resistor("R", 20));
            parallelLeftOne.Nodes.Add(seriesLeftOne);

            seriesLeftOne.Nodes.Add(new Resistor("R", 10));
            seriesLeftOne.Nodes.Add(parallelLeftTwo);

            parallelLeftTwo.Nodes.Add(new Resistor("R", 20));
            parallelLeftTwo.Nodes.Add(new Resistor("R", 20));

            seriesRightOne.Nodes.Add(new Resistor("R", 20));
            seriesRightOne.Nodes.Add(new Resistor("R", 20));

            Assert.AreEqual(50, seriesRoot.CalculateZ(1).Real);
        }

        [Test(Description = "Тест на добавление элемента в цепь")]
        public void AddAfterTest()
        {
            Circuit circuit = new Circuit();
            Resistor resistorRoot = new Resistor("R-Root", 20);
            circuit.AddAfter(null, resistorRoot, ConnectionType.Serial);

            Resistor resistorQ = new Resistor("R-Q", 20);
            circuit.AddAfter(resistorRoot, resistorQ, ConnectionType.Serial);

            Resistor resistorW = new Resistor("R-W", 40);
            circuit.AddAfter(resistorQ, resistorW, ConnectionType.Parallel);

            Resistor resistorE = new Resistor("R-E", 20);
            circuit.AddAfter(resistorW, resistorE, ConnectionType.Parallel);

            Resistor resistorR = new Resistor("R-R", 20);
            circuit.AddAfter(resistorE, resistorR, ConnectionType.Serial);

            Assert.AreEqual(30, circuit.CalcualteZ(new double[] {1})[0].Real);
        }

        [Test(Description = "Тест на удаление элемента из цепи")]
        public void DeleteTest()
        {
            Circuit circuit = new Circuit();
            Resistor resistorRoot = new Resistor("R-Root", 20);
            circuit.AddAfter(null, resistorRoot, ConnectionType.Serial);

            Resistor resistorQ = new Resistor("R-Q", 20);
            circuit.AddAfter(resistorRoot, resistorQ, ConnectionType.Serial);

            Resistor resistorW = new Resistor("R-W", 40);
            circuit.AddAfter(resistorQ, resistorW, ConnectionType.Parallel);

            Resistor resistorE = new Resistor("R-E", 20);
            circuit.AddAfter(resistorW, resistorE, ConnectionType.Parallel);

            Resistor resistorR = new Resistor("R-R", 20);
            circuit.AddAfter(resistorE, resistorR, ConnectionType.Serial);

            circuit.Delete(resistorR);
            circuit.Delete(resistorE);
            circuit.Delete(resistorW);

            Assert.AreEqual(40, circuit.CalcualteZ(new double[] {1})[0].Real);
        }

        #endregion
    }
}