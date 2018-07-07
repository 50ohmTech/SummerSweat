using System;
using System.Numerics;

namespace CircuitElements
{
	/// <summary>
	///     Катушка индуктивности, элемент эл. цепи
	/// </summary>
	public class Inductor : ElementBase
	{
		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор класса Inductor
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		public Inductor(string name, double value) : base(name, value)
		{
		}

		/// <summary>
		///     Расчитать импеданс
		/// </summary>
		/// <param name="f"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public override Complex CalculateZ(double f)
		{
			return new Complex(0, 2 * Math.PI * f * Value);
		}

		#endregion – – Публичные методы – –
	}
}