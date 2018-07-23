using System;
using System.Linq;
using System.Numerics;

namespace CircuitElements
{
	/// <summary>
	///     Интерфейс элементов
	/// </summary>
	public abstract class ElementBase
	{
		#region – – События – – 

		/// <summary>
		///     Событие, которое загорается при смене значения элемента
		/// </summary>
		public event ValueStateHandler ValueChanged;

		#endregion – – События – –

		#region – – Поля – – 

		/// <summary>
		///     Значение элемента
		/// </summary>
		private double _value;

		/// <summary>
		///     Имя элемента
		/// </summary>
		private string _name;

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
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new NullReferenceException("Имя не может быть null или Empty.");
				}

				if (value.Contains(' '))
				{
					throw new ArgumentException("Имя не должно содержать пробелы.");
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
		/// <param name="frequency"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public abstract Complex CalculateZ(double frequency);

		/// <summary>
		///     Конструктор элемента
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		protected ElementBase(string name, double value)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("An attempt to commit a null or empty name to the element\'s constructor");
			}

			if (value < 0.000000001)
			{
				throw new ArgumentOutOfRangeException("An attempt to commit an invalid value to the element\'s constructor. Value must be bigger than 0");
			}
			Name = name;
			Value = value;
		}

		#endregion – – Публичные методы – – 
	}

	/// <summary>
	///     Делегат, хранящий сигнатуру методов, подписанных на событие ValueChanged
	/// </summary>
	/// <param name="value"> Изменившееся значение </param>
	/// <param name="valueOwner"> объект, который изменился </param>
	public delegate void ValueStateHandler(double value, ElementBase valueOwner);
}