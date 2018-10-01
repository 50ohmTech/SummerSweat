using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements.Circuits
{
	/// <summary>
	///     Элемент паралельной цепи
	/// </summary>
	public class ParallelCircuit : CircuitBase
	{
		#region Constructor

		/// <summary>
		///     Конструктор с цепью
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public ParallelCircuit(List<ICircuitElement> elements) : base(elements)
		{
		}

		/// <summary>
		///     Конструктор без цепи
		/// </summary>
		public ParallelCircuit()
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequency">Частоты сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			//// числитель
			//var numerator = new Complex();

			//// знаменатель
			//var denominator = new Complex();

			//foreach (var element in Elements)
			//{
			//	denominator = Complex.Add(denominator, element.CalculateZ(frequency));
			//	numerator = Complex.Multiply(numerator, element.CalculateZ(frequency));
			//}

			//return Complex.Divide(numerator, denominator);
			var resistance = Complex.Zero;

			foreach (var element in Elements)
			{
				resistance += 1 / element.CalculateZ(frequency);
			}

			return 1 / resistance;
		}

		/// <inheritdoc />
		/// <summary>
		///     Получить количество элементов в длинну
		/// </summary>
		/// <returns>количество элементов в длинну</returns>
		public override int GetCircuitLength()
		{
			var count = 1;
			foreach (var element in Elements)
			{
				if (element is CircuitBase circuitBase)
				{
					count += circuitBase.GetCircuitLength();
				}
			}

			return count;
		}

		/// <inheritdoc />
		/// <summary>
		///     Получить количество элементов в ширину
		/// </summary>
		/// <returns>количество элементов в длинну</returns>
		public override int GetCircuitWidth()
		{
			var count = 1;
			foreach (var element in Elements)
			{
				if (element is ParallelCircuit parallelCircuit)
				{
					count += parallelCircuit.GetCircuitWidth();
				}
				else
				{
					count++;
				}
			}

			return count;
		}

		#endregion
	}
}