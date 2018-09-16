using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements.Elements
{
	/// <summary>
	///     Элемент паралельной цепи
	/// </summary>
	public class ParallelCircuit : CircuitBase
	{
		#region Constructor

		/// <summary>
		///     Конструктор
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public ParallelCircuit(List<ICircuitElement> elements) : base(elements)
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequence">Частоты сигнала</param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequence)
		{
			// числитель
			var numerator = new Complex();

			// знаменатель
			var denominator = new Complex();

			foreach (var element in Elements)
			{
				denominator = Complex.Add(denominator, element.CalculateZ(frequence));
				numerator = Complex.Multiply(numerator, element.CalculateZ(frequence));
			}

			return Complex.Divide(numerator, denominator);
		}

		#endregion
	}
}