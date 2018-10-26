
using ElementsLibrary;
using ElementsLibrary.Circuits;
using ElementsLibrary.Elements;
using MainForm.Properties;

namespace MainForm
{
    public static class TestCircuits
    {
        public static void TestCircuitsGenerator(int selectedCircuit, Circuit circuit)
        {
            const int FirstCircuit = 1;
            const int SecondCircuit = 2;
            const int ThirdCircuit = 3;
            const int FourthCircuit = 4;
            const int FifthCircuit = 5;
            if (selectedCircuit == FirstCircuit)
            {
                ElementBase resistor = new Resistor("R1", 13);
                ElementBase capacitor = new Capacitor("C1", 91);
                ElementBase inductor = new Inductor("L1", 32);

                SubCircuitBase parallelCircuit = new ParallelSubCircuit();

                parallelCircuit.Nodes.Add(resistor);
                parallelCircuit.Nodes.Add(capacitor);
                parallelCircuit.Nodes.Add(inductor);
                inductor.Parent = parallelCircuit;
                resistor.Parent = parallelCircuit;

                SubCircuitBase serialCircuit = new SerialSubCircuit();
                serialCircuit.Nodes.Add(parallelCircuit);
                serialCircuit.Nodes.Add(inductor);
                parallelCircuit.Parent = serialCircuit;
                inductor.Parent = serialCircuit;
                circuitPictureBox.Image = Resources.Цепь_1;
                circuit.Clean();
                circuit.AddNodes(null, parallelCircuit);
            }

            if (selectedCircuit == SecondCircuit)
            {
                var capacitor1 = new Capacitor("C1", 12);
                var inductor1 = new Inductor("L1", 21);
                var resistor1 = new Resistor("R1", 83);
                var inductor2 = new Inductor("L2", 73);

                var parallelCircuit1 = new ParallelSubCircuit();
                parallelCircuit1.Nodes.Add(inductor1);
                inductor1.Parent = parallelCircuit1;

                SubCircuitBase serialCircuit1 = new SerialSubCircuit();
                parallelCircuit1.Nodes.Add(serialCircuit1);
                serialCircuit1.Parent = parallelCircuit1;

                serialCircuit1.Nodes.Add(inductor2);
                inductor2.Parent = serialCircuit1;

                SubCircuitBase parallelCircuit2 = new ParallelSubCircuit();
                parallelCircuit2.Nodes.Add(resistor1);
                resistor1.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(capacitor1);
                capacitor1.Parent = parallelCircuit2;

                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
               
                circuit.Clean();
                circuit.AddNodes(null, parallelCircuit1);
            }

            if (selectedCircuit == ThirdCircuit)
            {
                var resistor1 = new Resistor("R1", 43);
                var resistor2 = new Resistor("R2", 10);
                var resistor3 = new Resistor("R3", 15);
                var inductor1 = new Inductor("L3", 25);
                var capacitor1 = new Capacitor("C1", 15);
                var capacitor2 = new Capacitor("C2", 19);

                SubCircuitBase serialCircuit = new SerialSubCircuit();
                SubCircuitBase serialCircuit1 = new SerialSubCircuit();
                SubCircuitBase parallelCircuit1 = new ParallelSubCircuit();
                SubCircuitBase parallelCircuit2 = new ParallelSubCircuit();

                serialCircuit.Nodes.Add(capacitor1);
                capacitor1.Parent = serialCircuit;
                serialCircuit.Nodes.Add(resistor1);
                resistor1.Parent = serialCircuit;
                serialCircuit.Nodes.Add(inductor1);
                inductor1.Parent = serialCircuit;
                serialCircuit.Nodes.Add(parallelCircuit1);
                parallelCircuit1.Parent = serialCircuit;
                parallelCircuit1.Nodes.Add(resistor2);
                resistor2.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(capacitor2);
                capacitor2.Parent = parallelCircuit1;
                serialCircuit.Nodes.Add(serialCircuit1);
                serialCircuit1.Parent = serialCircuit;
                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                parallelCircuit2.Nodes.Add(inductor1);
                inductor1.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(resistor3);
                resistor3.Parent = parallelCircuit2;

                
                circuit.Clean();
                circuit.AddNodes(null, serialCircuit);
            }

            if (selectedCircuit == FourthCircuit)
            {
                ElementBase resistor1 = new Resistor("R1", 13);
                ElementBase resistor2 = new Resistor("R2", 14);
                ElementBase resistor3 = new Resistor("R3", 6);
                ElementBase resistor4 = new Resistor("R4", 9);
                ElementBase capacitor1 = new Capacitor("C1", 12);
                ElementBase inductor1 = new Inductor("L1", 30);
                ElementBase inductor2 = new Inductor("L2", 10);

                SubCircuitBase serialCircuit1 = new SerialSubCircuit();
                SubCircuitBase parallelCircuit1 = new ParallelSubCircuit();
                SubCircuitBase parallelCircuit2 = new ParallelSubCircuit();

                serialCircuit1.Nodes.Add(inductor1);
                inductor1.Parent = serialCircuit1;
                serialCircuit1.Nodes.Add(resistor1);
                resistor1.Parent = serialCircuit1;
                serialCircuit1.Nodes.Add(parallelCircuit1);
                parallelCircuit1.Parent = serialCircuit1;
                parallelCircuit1.Nodes.Add(resistor2);
                resistor2.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(inductor2);
                inductor2.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(capacitor1);
                capacitor1.Parent = parallelCircuit1;
                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                parallelCircuit2.Nodes.Add(resistor3);
                resistor3.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(resistor4);
                resistor4.Parent = parallelCircuit2;
                
                circuit.Clean();
                circuit.AddNodes(null, serialCircuit1);
            }

            if (selectedCircuit == FifthCircuit)
            {
                ElementBase resistor = new Resistor("R1", 10);
                ElementBase resistor1 = new Resistor("R2", 10);
                ElementBase resistor2 = new Resistor("R3", 10);
                ElementBase capacitor = new Capacitor("C1", 12);
                ElementBase inductor = new Inductor("L1", 30);
                ElementBase inductor2 = new Inductor("L1", 23);

                SubCircuitBase serialCircuit1 = new SerialSubCircuit();
                SubCircuitBase serialCircuit2 = new SerialSubCircuit();
                SubCircuitBase parallelCircuit1 = new ParallelSubCircuit();
                SubCircuitBase parallelCircuit2 = new ParallelSubCircuit();
                SubCircuitBase parallelCircuit3 = new ParallelSubCircuit();

                serialCircuit1.Nodes.Add(parallelCircuit1);
                parallelCircuit1.Parent = serialCircuit1;
                parallelCircuit1.Nodes.Add(resistor1);
                resistor1.Parent = parallelCircuit1;
                parallelCircuit1.Nodes.Add(inductor);
                inductor.Parent = parallelCircuit1;

                serialCircuit1.Nodes.Add(parallelCircuit2);
                parallelCircuit2.Parent = serialCircuit1;
                parallelCircuit2.Nodes.Add(capacitor);
                capacitor.Parent = parallelCircuit2;
                parallelCircuit2.Nodes.Add(serialCircuit2);
                serialCircuit2.Parent = parallelCircuit2;
                serialCircuit2.Nodes.Add(parallelCircuit3);
                parallelCircuit3.Parent = serialCircuit2;
                serialCircuit2.Nodes.Add(resistor2);
                resistor.Parent = serialCircuit2;
                parallelCircuit3.Nodes.Add(resistor);
                resistor.Parent = parallelCircuit3;
                parallelCircuit3.Nodes.Add(inductor);
                inductor.Parent = parallelCircuit3;
                parallelCircuit2.Nodes.Add(inductor2);
                inductor2.Parent = parallelCircuit2;
                serialCircuit1.Nodes.Add(resistor);
                resistor.Parent = serialCircuit1;
                
                circuit.Clean();
                circuit.AddNodes(null, serialCircuit1);
            }
        }
    }
}
