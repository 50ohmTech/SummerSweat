using System;
using System.Linq;
using System.Numerics;

namespace CircuitElements

{
	/// <summary>
	///     Резистор, элемент эл. цепи
	/// </summary>
	public class Resistor : IElement
	{
		#region – – События – – 

		/// <summary>
		///     Событие, которое загорается при смене значения элемента
		/// </summary>
		public event ValueStateHandler ValueChanged;

		#endregion – – События – –

		#region – – Поля – – 

		/// <summary>
		///     Имя элемента
		/// </summary>
		private string _name;

		/// <summary>
		///     Значение элемента
		/// </summary>
		private double _value;

		#endregion – – Поля – –

		#region – – Свойства – – 

		/// <summary>
		///     Возвращает и задает имя элемента
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new NullReferenceException("Name can't be null or empty.");
				}

				if (value.Contains(' '))
				{
					throw new ArgumentException("Name can't have spaces.");
				}

				_name = value;
			}
		}

		/// <summary>
		///     Возвращает и задает значение элемента
		/// </summary>
		public double Value
		{
			get => _value;
			set
			{
				if (double.IsNaN(value) || double.IsInfinity(value))
				{
					throw new ArgumentException("Значение" + value +
					                            " не является вещесвенным числом.");
				}

				if (value <= 0)
				{
					throw new ArgumentException(
						"Значение" + value + " не может быть меньше или равно 0.");
				}

				_value = value;
				ValueChanged?.Invoke(_value, this);
			}
		}

		#endregion – – Свойства – –

		#region – – Публичные методы – – 

		/// <summary>
		///     Расчитать импеданс
		/// </summary>
		/// <param name="f"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public Complex CalculateZ(double f)
		{
			return new Complex(Value, 0);
		}

		/// <summary>
		///     Конструктор класса Resistor
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		public Resistor(string name, double value)
		{
			Name = name;
			Value = value;
		}

		#endregion – – Публичные методы – –
	}
}