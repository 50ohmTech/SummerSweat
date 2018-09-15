using Model.Elements;
using Model.Elements.Enums;
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

                    circuit.AddAfter(null, inductor1, ConnectionType.Serial);
                    circuit.AddAfter(inductor1, resistor2, ConnectionType.Serial);
                    circuit.AddAfter(resistor2, resistor3, ConnectionType.Serial);
                    circuit.AddAfter(resistor3, inductor4, ConnectionType.Parallel);
                    break;
                }

                case InitialCircuitType.B:
                {
                    Capacitor capacitor1 = new Capacitor("C1", 20);
                    Inductor inductor2 = new Inductor("L2", 20);
                    Resistor resistor3 = new Resistor("R3", 20);
                    Inductor inductor4 = new Inductor("L4", 20);

                    circuit.AddAfter(null, capacitor1, ConnectionType.Serial);
                    circuit.AddAfter(capacitor1, inductor2, ConnectionType.Parallel);
                    circuit.AddAfter(inductor2, resistor3, ConnectionType.Serial);
                    circuit.AddAfter(resistor3, inductor4, ConnectionType.Parallel);

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

                    circuit.AddAfter(null, resistor1, ConnectionType.Serial);
                    circuit.AddAfter(resistor1, inductor2, ConnectionType.Parallel);
                    circuit.AddAfter(resistor1, inductor3, ConnectionType.Serial);
                    circuit.AddAfter(resistor1, inductor4, ConnectionType.Parallel);

                    circuit.AddAfter(inductor2, resistor5, ConnectionType.Serial);
                    circuit.AddAfter(resistor5, resistor6, ConnectionType.Serial);
                    circuit.AddAfter(resistor6, inductor7, ConnectionType.Parallel);
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

                    circuit.AddAfter(null, resistor1, ConnectionType.Serial);
                    circuit.AddAfter(resistor1, capacitor2, ConnectionType.Serial);
                    circuit.AddAfter(capacitor2, resistor3, ConnectionType.Serial);
                    circuit.AddAfter(resistor1, inductor4, ConnectionType.Parallel);
                    circuit.AddAfter(capacitor2, resistor5, ConnectionType.Parallel);
                    circuit.AddAfter(resistor5, inductor6, ConnectionType.Parallel);

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

                    circuit.AddAfter(null, resistor1, ConnectionType.Serial);
                    circuit.AddAfter(resistor1, capacitor2, ConnectionType.Serial);
                    circuit.AddAfter(capacitor2, resistor3, ConnectionType.Serial);
                    circuit.AddAfter(resistor1, inductor4, ConnectionType.Parallel);
                    circuit.AddAfter(capacitor2, resistor5, ConnectionType.Parallel);
                    circuit.AddAfter(resistor5, inductor6, ConnectionType.Parallel);
                    circuit.AddAfter(resistor5, resistor7, ConnectionType.Serial);
                    circuit.AddAfter(resistor5, inductor8, ConnectionType.Parallel);

                    break;
                }
            }
        }

        #endregion
    }
}