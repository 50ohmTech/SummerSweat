using System;
using System.Numerics;

namespace CircuitElements.Elements
{
	/// <summary>
	///     Катушка индуктивности, элемент эл. цепи
	/// </summary>
	public class Inductor : ElementBase
	{
		#region Constructor

		/// <summary>
		///     Конструктор класса Inductor
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		public Inductor(string name, double value) : base(name, value)
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequency"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public override Complex CalculateZ(double frequency)
		{
			return new Complex(0, 2 * Math.PI * frequency * Value);
		}

		#endregion
	}
}