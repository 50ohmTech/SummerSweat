using Model.Elements;
using Model.ViewHelpers.Enums;

namespace Model.ViewHelpers
{
    /// <summary>
    ///     Инициализирует цепь изначально заданными элементами.
    /// </summary>
    public static class InitialCircuitInitializer
    {
        #region Public methods

        /// <summary>
        ///     Инициализировать цепь.
        /// </summary>
        /// <param name="circuit">Цепь.</param>
        /// <param name="initialCircuitType">Тип изначально заданной цепи.</param>
        public static void Initialize(Circuit circuit, InitialCircuitType initialCircuitType)
        {
            if (circuit == null)
            {
                circuit = new Circuit();
            }

            circuit.Clear();

            switch (initialCircuitType)
            {
                case InitialCircuitType.A:
                {
                    Inductor inductor1 = new Inductor("L1", 20);
                    Resistor resistor2 = new Resistor("R2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    seriesSubcircuit1.Nodes.Add(inductor1);
                    seriesSubcircuit1.Nodes.Add(resistor2);

                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Nodes.Add(resistor3);
                    parallelSubcircuit1.Nodes.Add(inductor4);

                    circuit.AddAfter(null, seriesSubcircuit1);
                    break;
                }

                case InitialCircuitType.B:
                {
                    Capacitor capacitor1 = new Capacitor("C1", 20);
                    Inductor inductor2 = new Inductor("L2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);

                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    parallelSubcircuit1.Nodes.Add(capacitor1);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit1);

                    seriesSubcircuit1.Nodes.Add(inductor2);

                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();
                    parallelSubcircuit2.Nodes.Add(resistor3);
                    parallelSubcircuit2.Nodes.Add(inductor4);

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    circuit.AddAfter(null, parallelSubcircuit1);

                    break;
                }


                case InitialCircuitType.C:
                {
                    Resistor resistor1 = new Resistor("R1", 20);
                    Inductor inductor2 = new Inductor("L2", 20);
                    Inductor inductor3 = new Inductor("L3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);
                    Resistor resistor5 = new Resistor("R5", 20);
                    Resistor resistor6 = new Resistor("R6", 20);
                    Inductor inductor7 = new Inductor("L7", 20);

                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    SeriesSubcircuit seriesSubcircuit2 = new SeriesSubcircuit();

                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit1);
                    parallelSubcircuit1.Nodes.Add(seriesSubcircuit2);

                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit3 = new ParallelSubcircuit();

                    seriesSubcircuit1.Nodes.Add(inductor3);
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Nodes.Add(resistor1);
                    parallelSubcircuit2.Nodes.Add(inductor4);

                    seriesSubcircuit2.Nodes.Add(inductor2);
                    seriesSubcircuit2.Nodes.Add(resistor5);
                    seriesSubcircuit2.Nodes.Add(parallelSubcircuit3);
                    parallelSubcircuit3.Nodes.Add(resistor6);
                    parallelSubcircuit3.Nodes.Add(inductor7);
                    circuit.AddAfter(null, parallelSubcircuit1);
                    break;
                }


                case InitialCircuitType.D:
                {
                    Resistor resistor1 = new Resistor("R1", 1);
                    Capacitor capacitor2 = new Capacitor("C2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);
                    Resistor resistor5 = new Resistor("R5", 20);
                    Inductor inductor6 = new Inductor("L6", 20);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    seriesSubcircuit1.Nodes.Add(resistor3);
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    parallelSubcircuit1.Nodes.Add(inductor4);
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    parallelSubcircuit2.Nodes.Add(resistor5);
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    circuit.AddAfter(null, seriesSubcircuit1);

                    break;
                }


                case InitialCircuitType.E:
                {
                    Resistor resistor1 = new Resistor("R1", 20);
                    Capacitor capacitor2 = new Capacitor("C2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);
                    Resistor resistor5 = new Resistor("R5", 20);
                    Inductor inductor6 = new Inductor("L6", 20);
                    Resistor resistor7 = new Resistor("R7", 20);
                    Inductor inductor8 = new Inductor("L8", 20);

                    SeriesSubcircuit seriesSubcircuit1 = new SeriesSubcircuit();
                    SeriesSubcircuit seriesSubcircuit2 = new SeriesSubcircuit();
                    ParallelSubcircuit parallelSubcircuit1 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit2 = new ParallelSubcircuit();
                    ParallelSubcircuit parallelSubcircuit3 = new ParallelSubcircuit();
                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit1);
                    parallelSubcircuit1.Nodes.Add(resistor1);
                    parallelSubcircuit1.Nodes.Add(inductor4);

                    seriesSubcircuit1.Nodes.Add(parallelSubcircuit2);
                    parallelSubcircuit2.Nodes.Add(capacitor2);
                    parallelSubcircuit2.Nodes.Add(seriesSubcircuit2);
                    seriesSubcircuit2.Nodes.Add(parallelSubcircuit3);
                    seriesSubcircuit2.Nodes.Add(resistor7);
                    parallelSubcircuit3.Nodes.Add(resistor5);
                    parallelSubcircuit3.Nodes.Add(inductor8);
                    parallelSubcircuit2.Nodes.Add(inductor6);
                    seriesSubcircuit1.Nodes.Add(resistor3);

                    circuit.AddAfter(null, seriesSubcircuit1);
                    break;
                }
            }
        }

        #endregion
    }
}