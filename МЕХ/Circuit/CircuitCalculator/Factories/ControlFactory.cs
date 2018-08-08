using CircuitCalculator.Controls;
using CircuitElements;

namespace CircuitCalculator.Factories
{
	internal static class ControlFactory
	{
		/// <summary>
		/// Создает блок резистора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ElementControl CreateResistorControl(string name, double value)
		{
			return new ElementControl(new Resistor(name, value));
		}

		/// <summary>
		/// Создает блок катушки индуктивности
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ElementControl CreateCapacitorControl(string name, double value)
		{
			return new ElementControl(new Capacitor(name, value));
		}

		/// <summary>
		/// Создает блок индуктора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public static ElementControl CreateInductorControl(string name, double value)
		{
			return new ElementControl(new Inductor(name, value));
		}

		/// <summary>
		/// Создает блок стартового элемента
		/// </summary>
		/// <returns></returns>
		public static ElementControl CreateStartingElementControl()
		{
			return new ElementControl(DrawingElements.StartingElement);
		}

		/// <summary>
		/// Создает блок завершающего элемента
		/// </summary>
		/// <returns></returns>
		public static ElementControl CreateFiniteElementControl()
		{
			return new ElementControl(DrawingElements.FiniteElement);
		}
	}
}