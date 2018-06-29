using System;
using System.Numerics;

namespace CircuitElements
{
	/// <summary>
	///     Конденсатор, элемент эл. цепи
	/// </summary>
	public class Capacitor : ElementBase
	{
		#region – – Публичные методы – – 

		/// <summary>
		///     Расчитать импеданс
		/// </summary>
		/// <param name="f"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public override Complex CalculateZ(double f)
		{
			return new Complex(0, -1 / (2 * Math.PI * f * Value));
		}

		/// <summary>
		///     Конструктор класса Capacitor
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		public Capacitor(string name, double value) : base(name, value)
		{
		}

		#endregion – – Публичные методы – –
	}
}