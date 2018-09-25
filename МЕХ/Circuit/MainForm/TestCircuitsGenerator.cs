using System.Collections.Generic;
using CircuitElements;
using CircuitElements.Circuits;
using CircuitElements.Elements;

namespace MainForm
{
	public static class TestCircuitsGenerator
	{
		#region Public methods

		/// <summary>
		///     Сгенерировать цепь по ее порядковому номеру
		/// </summary>
		/// <param name="circuitNumber">порядковый номер цепи</param>
		/// <returns></returns>
		public static CircuitBase GenerateCircuit(int circuitNumber)
		{
			switch (circuitNumber)
			{
				case 1:
					var circuitElements1 = new List<ICircuitElement>
					{
						new Capacitor("C1", 10),
						new Inductor("L1", 5),
						new Resistor("R1", 20)
					};

					return new SerialCircuit(circuitElements1);

				case 2:
					var circuitElements2 = new List<ICircuitElement>
					{
						new Capacitor("C1", 10),
						new Inductor("L1", 5),
						new Resistor("R1", 20)
					};

					return new ParallelCircuit(circuitElements2);

				case 3:
					var circuitElements3 = new List<ICircuitElement>
					{
						new Capacitor("C4", 10),
						new ParallelCircuit(new List<ICircuitElement>
						{
							new ParallelCircuit(new List<ICircuitElement>
							{
								new Capacitor("C2", 10),
								new Inductor("L3", 5)
							}),
							new Capacitor("C1", 10),
							new Resistor("R1", 20)
						}),
						new Inductor("L4", 5),
						new Resistor("R2", 20)
					};

					return new SerialCircuit(circuitElements3);

				case 4:
					var circuitElements4 = new List<ICircuitElement>
					{
						new Capacitor("C2", 10),
						new Inductor("L2", 5),
						new ParallelCircuit(new List<ICircuitElement>
						{
							new Capacitor("C3", 10),
							new Inductor("L3", 5)
						}),
						new Resistor("R2", 20)
					};

					return new SerialCircuit(circuitElements4);

				case 5:
					var circuitElements5 = new List<ICircuitElement>
					{
						new ParallelCircuit(new List<ICircuitElement>
						{
							new Capacitor("C1", 10),
							new Inductor("L1", 5),
							new ParallelCircuit(new List<ICircuitElement>
							{
								new Inductor("L3", 5),

								new SerialCircuit(new List<ICircuitElement>
								{
									new Capacitor("C2", 10),
									new Inductor("L2", 5)
								})
							}),
							new Resistor("R1", 20)
						}),
						new Capacitor("C4", 10),
						new Inductor("L4", 5),
						new Resistor("R2", 20)
					};

					return new SerialCircuit(circuitElements5);

				default:

					//пустая цепь
					return new SerialCircuit(new List<ICircuitElement>());
			}
		}

		#endregion
	}
}