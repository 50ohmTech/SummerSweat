using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements.Circuits
{
	/// <summary>
	///     Последовательное электрическое соединение
	/// </summary>
	public class SerialCircuit : CircuitBase
	{
		#region Constructor

		/// <summary>
		///     Конструктор с цепью
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public SerialCircuit(List<ICircuitElement> elements) : base(elements)
		{
		}

		/// <summary>
		///     Конструктор без цепи
		/// </summary>
		public SerialCircuit()
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
			var result = new Complex();

			foreach (var element in Elements)
			{
				result = Complex.Add(result, element.CalculateZ(frequence));
			}

			return result;
		}

		/// <summary>
		///     Получить количество элементов в длинну
		/// </summary>
		/// <returns>количество элементов в длинну</returns>
		public override int GetCircuitLength()
		{
			var count = 1;
			foreach (var element in Elements)
			{
				if (element is CircuitBase serialCircuit)
				{
					count += serialCircuit.GetCircuitLength();
				}
				else
				{
					count++;
				}
			}

			return count;
		}

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
			}

			return count;
		}

		#endregion
	}
}