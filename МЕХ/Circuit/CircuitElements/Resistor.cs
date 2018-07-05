using System.Numerics;

namespace CircuitElements

{
	/// <summary>
	///     Резистор, элемент эл. цепи
	/// </summary>
	public class Resistor : ElementBase
	{
		#region – – Публичные методы – – 

		/// <summary>
		///     Расчитать импеданс
		/// </summary>
		/// <param name="f"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public override Complex CalculateZ(double f)
		{
			return new Complex(Value, 0);
		}

		/// <summary>
		///     Конструктор класса Resistor
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		public Resistor(string name, double value) : base(name, value)
		{
		}

		#endregion – – Публичные методы – –
	}
}