using System.Collections.Generic;
using System.Numerics;
using CircuitElements.ParentClasses;

namespace CircuitElements.Elements
{
	/// <summary>
	///     Электрическая цепь
	/// </summary>
	public class SerialCircuit : CircuitBase
	{
		#region Constructor

		/// <summary>
		///     Конструктор
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public SerialCircuit(List<ICircuitElement> elements) : base(elements)
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

		#endregion
	}
}