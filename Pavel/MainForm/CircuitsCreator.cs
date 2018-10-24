using System.Collections.Generic;
using Model;
using Model.Elements;

namespace MainForm
{
    public class CircuitsCreator
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Текущая нода
        /// </summary>
        private INode _currentNode;

        #endregion

        #region Ordinary fields

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Список цепей
        /// </summary>
        public List<Circuit> Circuits { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор класса CircuitsCreator
        /// </summary>
        public CircuitsCreator()
        {
            Circuits = new List<Circuit>();

            for (var i = 0; i < 6; i++)
            {
                Circuits.Add(new Circuit());
            }

            var seriesSubcircuit1 = new SeriesSubcircuit();
            var parallelSubcircuit1 = new ParallelSubcircuit();

            var seriesSubcircuit2 = new SeriesSubcircuit();

            var seriesSubcircuit3 = new SeriesSubcircuit();
            var parallelSubcircuit3 = new ParallelSubcircuit();

            var seriesSubcircuit4 = new SeriesSubcircuit();

            var seriesSubcircuit5 = new SeriesSubcircuit();
            var parallelSubcircuit5 = new ParallelSubcircuit();
           
            Circuits[1].AddAfter(_currentNode, seriesSubcircuit1);
            Circuits[1].AddAfter(seriesSubcircuit1,
                new Resistor("R0", 1));

            Circuits[1].AddAfter(seriesSubcircuit1,
                new Resistor("R1", 5));

            Circuits[1].AddAfter(seriesSubcircuit1, parallelSubcircuit1);
            Circuits[1].AddAfter(parallelSubcircuit1,
                new Resistor("R2", 6));

            Circuits[1].AddAfter(parallelSubcircuit1,
                new Capacitor("C0", 44));

            Circuits[2].AddAfter(_currentNode, seriesSubcircuit2);
            Circuits[2].AddAfter(seriesSubcircuit2,
                new Capacitor("C0", 55));

            Circuits[2].AddAfter(seriesSubcircuit2,
                new Resistor("R0", 34));

            Circuits[2].AddAfter(seriesSubcircuit2,
                new Inductor("L0", 68));


            Circuits[3].AddAfter(_currentNode, seriesSubcircuit3);
            Circuits[3].AddAfter(seriesSubcircuit3, parallelSubcircuit3);
            Circuits[3].AddAfter(parallelSubcircuit3,
                new Resistor("R0", 56));

            Circuits[3].AddAfter(parallelSubcircuit3,
                new Capacitor("C0", 59));

            Circuits[3].AddAfter(parallelSubcircuit3,
                new Resistor("R1", 33));


            Circuits[4].AddAfter(_currentNode, seriesSubcircuit4);
            Circuits[4].AddAfter(seriesSubcircuit4,
                new Resistor("R0", 22));

            Circuits[4].AddAfter(seriesSubcircuit4,
                new Capacitor("C0", 59));

            Circuits[4].AddAfter(seriesSubcircuit4,
                new Capacitor("C1", 33));

            Circuits[4].AddAfter(seriesSubcircuit4,
                new Resistor("R1", 11));


            Circuits[5].AddAfter(_currentNode, seriesSubcircuit5);
            Circuits[5].AddAfter(seriesSubcircuit5,
                new Resistor("R0", 22));

            Circuits[5].AddAfter(seriesSubcircuit5,
                new Capacitor("C0", 52));

            Circuits[5].AddAfter(seriesSubcircuit5, parallelSubcircuit5);
            Circuits[5].AddAfter(parallelSubcircuit5,
                new Inductor("L0", 99));

            Circuits[5].AddAfter(parallelSubcircuit5,
                new Capacitor("C1", 38));
        }

        #endregion

        #region Public methods

        

        #endregion
    }
}