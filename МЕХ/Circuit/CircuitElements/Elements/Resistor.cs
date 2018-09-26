using System.Numerics;

namespace CircuitElements.Elements
{
	/// <summary>
	///     Резистор, элемент эл. цепи
	/// </summary>
	public class Resistor : ElementBase
	{
		#region Constructor

		/// <summary>
		///     Конструктор класса Resistor
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		public Resistor(string name, double value) : base(name, value)
		{
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequence"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public override Complex CalculateZ(double frequence)
		{
			return new Complex(Value, 0);
		}

		#endregion
	}
}