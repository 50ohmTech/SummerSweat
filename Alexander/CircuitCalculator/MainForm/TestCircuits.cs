using System.Collections.Generic;
using Model.Circuit;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Класс для создания тестовых цепей.
    /// </summary>
    public class TestCircuits
    {
        #region Private fields

        /// <summary>
        ///     Выбранная нода.
        /// </summary>
        private INode _currentNode;

        #endregion

        #region Ordinary fields

        /// <summary>
        ///     Индекс конденсатора.
        /// </summary>
        public uint CapacitorIterator;

        /// <summary>
        ///     Индекс индуктора.
        /// </summary>
        public uint InductorIterator;

        /// <summary>
        ///     Индекс резистора.
        /// </summary>
        public uint ResistorIterator;

        #endregion

        #region Properties

        /// <summary>
        ///     Возвращает и задает список цепей.
        /// </summary>
        public List<Circuit> Circuits { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        public TestCircuits()
        {
            SubcircuitBase parallelSubcircuit1 = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit1 = new SeriesSubcircuit();
            SubcircuitBase parallelSubcircuit2 = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit2 = new SeriesSubcircuit();
            SubcircuitBase parallelSubcircuit3 = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit4 = new SeriesSubcircuit();
            SubcircuitBase parallelSubcircuit5 = new ParallelSubcircuit();
            SubcircuitBase seriesSubcircuit5 = new SeriesSubcircuit();

            Circuits = new List<Circuit>();

            for (var i = 0; i < 6; i++)
            {
                Circuits.Add(new Circuit());
            }

            Circuits[1].AddAfter(_currentNode, seriesSubcircuit1);
            Circuits[1].AddAfter(seriesSubcircuit1,
                new Capacitor("C0", 2.2));

            Circuits[1].AddAfter(seriesSubcircuit1,
                new Resistor("R0", 15));

            Circuits[1].AddAfter(seriesSubcircuit1, parallelSubcircuit1);
            Circuits[1].AddAfter(parallelSubcircuit1,
                new Inductor("L0", 20));

            Circuits[1].AddAfter(parallelSubcircuit1,
                new Resistor("R1", 1.1));


            Circuits[2].AddAfter(_currentNode, parallelSubcircuit2);
            Circuits[2].AddAfter(parallelSubcircuit2,
                new Resistor("R0", 22.1));

            Circuits[2].AddAfter(parallelSubcircuit2,
                new Inductor("L0", 1.1));

            Circuits[2].AddAfter(parallelSubcircuit2,
                new Inductor("L1", 6));

            Circuits[2].AddAfter(parallelSubcircuit2, seriesSubcircuit2);
            Circuits[2].AddAfter(seriesSubcircuit2,
                new Resistor("R1", 9.9));

            Circuits[2].AddAfter(seriesSubcircuit2,
                new Inductor("L2", 5.12));

            Circuits[2].AddAfter(seriesSubcircuit2,
                new Capacitor("C0", 11));


            Circuits[3].AddAfter(_currentNode, parallelSubcircuit3);
            Circuits[3].AddAfter(parallelSubcircuit3,
                new Capacitor("C0", 8.8));

            Circuits[3].AddAfter(parallelSubcircuit3,
                new Capacitor("C1", 7.7));

            Circuits[3].AddAfter(parallelSubcircuit3,
                new Capacitor("C2", 6.66));


            Circuits[4].AddAfter(_currentNode, seriesSubcircuit4);
            Circuits[4].AddAfter(seriesSubcircuit4,
                new Inductor("L0", 5));

            Circuits[4].AddAfter(seriesSubcircuit4,
                new Resistor("R0", 27.9));

            Circuits[4].AddAfter(seriesSubcircuit4,
                new Capacitor("C0", 40));

            Circuits[4].AddAfter(seriesSubcircuit4,
                new Resistor("R1", 14));


            Circuits[5].AddAfter(_currentNode, parallelSubcircuit5);
            Circuits[5].AddAfter(parallelSubcircuit5,
                new Capacitor("C0", 44));

            Circuits[5].AddAfter(parallelSubcircuit5, seriesSubcircuit5);
            Circuits[5].AddAfter(seriesSubcircuit5,
                new Resistor("R0", 99.2));

            Circuits[5].AddAfter(seriesSubcircuit5,
                new Capacitor("C1", 88.8));

            Circuits[5].AddAfter(seriesSubcircuit5,
                new Resistor("R1", 2));
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Подсчет элементов в цепях.
        /// </summary>
        /// <param name="CurrentCircuit"></param>
        public void GetIterator(int CurrentCircuit)
        {
            ResistorIterator = 0;
            CapacitorIterator = 0;
            InductorIterator = 0;

            if (CurrentCircuit == 1)
            {
                ResistorIterator = 2;
                CapacitorIterator = 1;
                InductorIterator = 1;
            }
            else if (CurrentCircuit == 2)
            {
                ResistorIterator = 2;
                CapacitorIterator = 1;
                InductorIterator = 3;
            }
            else if (CurrentCircuit == 3)
            {
                CapacitorIterator = 3;
            }
            else if (CurrentCircuit == 4)
            {
                ResistorIterator = 2;
                CapacitorIterator = 1;
                InductorIterator = 1;
            }
            else if (CurrentCircuit == 5)
            {
                ResistorIterator = 2;
                CapacitorIterator = 2;
            }
        }

        #endregion
    }
}