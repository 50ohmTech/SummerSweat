using System;
using Model;
using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    //TODO: Для разных классов логики разные классы тестов!
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

            Assert.AreEqual(50, seriesRoot.CalculateZ(1).Real, 0.01);
        }

        [Test(Description = "Тест на добавление элемента в цепь")]
        public void AddAfterTest()
        {
            Circuit circuit = new Circuit();
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            ParallelSubcircuit parallelSubcircuit = new ParallelSubcircuit();
            circuit.AddAfter(null, seriesSubcircuit);
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
            Assert.AreEqual(50, circuit.CalculateZ(new double[] {1})[0].Real, 0.01);
        }

        [Test(Description = "Тест на удаление элемента из цепи")]
        public void RemoveTest()
        {
            Circuit circuit = new Circuit();
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();
            ParallelSubcircuit parallelSubcircuit = new ParallelSubcircuit();
            circuit.AddAfter(null, seriesSubcircuit);
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(parallelSubcircuit, new Resistor("R", 20));
            circuit.AddAfter(seriesSubcircuit, parallelSubcircuit);
            circuit.Remove(parallelSubcircuit);
            Assert.AreEqual(40, circuit.CalculateZ(new double[] {1})[0].Real, 0.01);
        }

        [Test(Description = "Тест 2 на удаление элемента из цепи")]
        public void TryRemoveTestTwo()
        {
            Circuit circuit = new Circuit();
            SeriesSubcircuit seriesSubcircuit = new SeriesSubcircuit();

            circuit.AddAfter(null, seriesSubcircuit);
            circuit.Remove(seriesSubcircuit);
            if (circuit.Root != null)
            {
                throw new Exception("Корень был null");
            }
        }

        [Test(Description = "Тест на пустой корень при вычислении")]
        public void CircuitCalculateEmptyRootTest()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Circuit circuit = new Circuit();
                circuit.CalculateZ(new double[] {1});
            });
        }

        [Test(Description = "Тест на пустой корень при удалении")]
        public void CircuitDeleteEmptyRootTest()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Circuit circuit = new Circuit();
                circuit.Remove(new Resistor("R", 20));
            });
        }

        #endregion
    }
}