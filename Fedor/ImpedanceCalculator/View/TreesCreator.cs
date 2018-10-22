using Model.Elements;
using Model.Enums;
using Model.Tree;
using System.Collections.Generic;

namespace View
{
    /// <summary>
    /// Создатель деревьев элементов.
    /// </summary>
    public class TreesCreator
    {
        #region - - Свойства - -

        /// <summary>
        /// Возвращаеет и задает список деревьев.
        /// </summary>
        public List<ElementsTree> Trees { get; }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CircuitCreator.
        /// </summary>
        public TreesCreator()
        {
            Trees = new List<ElementsTree>();

            for (var i = 0; i < 6; i++)
            {
                Trees.Add(new ElementsTree());
            }

            Trees[1].Add(new Resistor("R1", 5));
            Trees[1].Add(new Resistor("R2", 10), "R1",
                ConnectionType.Parallel);

            Trees[1].Add(new Resistor("R3", 20), "R1",
                ConnectionType.Serial);

            Trees[1].Add(new Resistor("R4", 5), "R1",
                ConnectionType.Serial);

            Trees[1].Add(new Resistor("R5", 5), "R1",
                ConnectionType.Parallel);

            Trees[1].Add(new Resistor("R6", 20), "R5",
                ConnectionType.Serial);

            Trees[1].Add(new Resistor("R7", 5), "R4",
                ConnectionType.Parallel);

            Trees[1].Add(new Resistor("R8", 10), "R4",
                ConnectionType.Parallel);

            Trees[1].Add(new Resistor("R9", 15), "R7",
                ConnectionType.Parallel);

            Trees[1].Add(new Resistor("R10", 10), "R7",
                ConnectionType.Serial);

            Trees[2].Add(new Capacitor("C1", 66.666));
            Trees[2].Add(new Inductor("I1", 0.02), "C1",
                ConnectionType.Parallel);

            Trees[2].Add(new Resistor("R1", 20.56), "I1",
                ConnectionType.Serial);

            Trees[2].Add(new Inductor("I2", 0.7), "C1",
                ConnectionType.Parallel);

            Trees[3].Add(new Resistor("R1", 95));
            Trees[3].Add(new Capacitor("C1", 38), "R1",
                ConnectionType.Parallel);

            Trees[3].Add(new Inductor("I1", 0.5), "C1",
                ConnectionType.Serial);

            Trees[3].Add(new Capacitor("C2", 32.8), "R1",
                ConnectionType.Serial);

            Trees[3].Add(new Resistor("R2", 20), "I1",
                ConnectionType.Parallel);

            Trees[3].Add(new Capacitor("C3", 66.666), "C2",
                ConnectionType.Parallel);

            Trees[3].Add(new Resistor("R3", 222), "C2",
                ConnectionType.Parallel);

            Trees[4].Add(new Inductor("I1", 0.02));
            Trees[4].Add(new Resistor("R1", 38), "I1",
                ConnectionType.Serial);

            Trees[4].Add(new Capacitor("C1", 59.9), "I1",
                ConnectionType.Parallel);

            Trees[4].Add(new Inductor("I2", 0.28), "C1",
                ConnectionType.Serial);

            Trees[4].Add(new Resistor("R2", 80.98), "I2",
                ConnectionType.Parallel);

            Trees[4].Add(new Capacitor("C2", 25), "R2",
                ConnectionType.Serial);

            Trees[5].Add(new Resistor("R1", 33.5));
            Trees[5].Add(new Capacitor("C1", 10), "R1",
                ConnectionType.Parallel);

            Trees[5].Add(new Inductor("I1", 0.003), "C1",
                ConnectionType.Serial);

            Trees[5].Add(new Resistor("R2", 20), "I1",
                ConnectionType.Serial);

            Trees[5].Add(new Resistor("R3", 43.21), "R2",
                ConnectionType.Parallel);
        }

        #endregion
    }
}
