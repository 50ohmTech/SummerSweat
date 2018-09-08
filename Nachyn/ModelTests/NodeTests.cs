using Model.Elements;
using NUnit.Framework;

namespace ModelTests
{
    [Description("Класс проверки цепей")]
    internal class NodeTests
    {
        [Test(Description = "Тест правильности расчета сложной цепи")]
        public void CircuitTest()
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
    }
}