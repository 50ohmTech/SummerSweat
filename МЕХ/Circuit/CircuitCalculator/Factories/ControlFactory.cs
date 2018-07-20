using CircuitCalculator.Controls;
using CircuitElements;

namespace CircuitCalculator.Factories
{
	internal static class ControlFactory
	{
		public static ElementControl CreateResistorControl(string name, double value)
		{
			return new ElementControl(new Resistor(name, value));
		}

		public static ElementControl CreateCapacitorControl(string name, double value)
		{
			return new ElementControl(new Capacitor(name, value));
		}

		public static ElementControl CreateInductorControl(string name, double value)
		{
			return new ElementControl(new Inductor(name, value));
		}

		public static ElementControl CreateStartingElementControl()
		{
			return new ElementControl(DrawingElements.StartingElement);
		}

		public static ElementControl CreateFiniteElementControl()
		{
			return new ElementControl(DrawingElements.FiniteElement);
		}
	}
}