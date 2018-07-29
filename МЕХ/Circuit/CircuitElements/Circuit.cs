using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements
{
	/// <summary>
	///     Электрическая цепь
	/// </summary>
	public class Circuit
	{
		#region – – Свойства – – 

		/// <summary>
		///     Список элементов электрической цепи
		/// </summary>
		public List<ElementBase> Elements
		{
			get;
			set;
		}

		#endregion – – Свойства – –

		#region – – События – – 

		/// <summary>
		///     Событие, которое загорается при смене значения одного из элементов
		/// </summary>
		public event ValueStateHandler CircuitChanged;

		#endregion – – События – –

		#region – – Публичные методы – – 

		/// <summary>
		///     Расчитать импаденсы по входному списку частот сигнала
		/// </summary>
		/// <param name="frequencies">Частоты сигнала</param>
		/// <returns></returns>
		public Complex[] CalculateZ(double[] frequencies)
		{
			var result = new Complex[frequencies.Length];

			for (var i = 0; i < frequencies.Length; i++)
			{
				foreach (var element in Elements)
				{
					result[i] = Complex.Add(result[i],
						element.CalculateZ(frequencies[i]));
				}
			}

			return result;
		}

		/// <summary>
		///     Конструктор
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public Circuit(List<ElementBase> elements)
		{
			if (elements != null && elements.Count != 0)
			{
				Elements = elements;
			}

			foreach (var element in Elements)
			{
				element.ValueChanged += CircuitChanged;
			}
		}

		#endregion – – Публичные методы – –
	}
}