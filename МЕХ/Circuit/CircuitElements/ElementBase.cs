using System;
using System.Linq;
using System.Numerics;

namespace CircuitElements
{
	/// <summary>
	///     Интерфейс элементов
	/// </summary>
	public abstract class ElementBase : ICircuitElement
	{
		#region Private fields

		/// <summary>
		///     Уникальный идентификатор.
		/// </summary>
		private static int _elementId;

		/// <summary>
		///     Имя элемента
		/// </summary>
		private string _name;

		/// <summary>
		///     Значение элемента
		/// </summary>
		private double _value;
		
		#endregion

		#region Properties

		/// <summary>
		/// ID элемента
		/// </summary>
		public int ElementId { get; } = _elementId;

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
					throw new NullReferenceException(
						nameof(Name) + " не может быть null или Empty.");
				}

				if (value.Contains(' '))
				{
					throw new ArgumentException(nameof(Name) + " не должно содержать пробелы.");
				}

				_name = value;

				ElementChanged?.Invoke(_name, this);
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
					throw new ArgumentException(
						value + " не является вещесвенным числом.");
				}

				if (value <= 0)
				{
					throw new ArgumentException(
						"Значение " + nameof(Value) + " не может быть меньше или равно 0.");
				}

				_value = value;
				ElementChanged?.Invoke(_value, this);
			}
		}

		#endregion

		#region Events

		/// <summary>
		///     Событие, которое загорается при изменении элемента
		/// </summary>
		public event ElementStateHandler ElementChanged;

		#endregion

		#region Constructor

		/// <summary>
		///     Конструктор элемента
		/// </summary>
		/// <param name="name"> Имя элемента </param>
		/// <param name="value"> Значение элемента </param>
		protected ElementBase(string name, double value)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(
					"An attempt to commit a null or empty name to the element\'s constructor");
			}

			if (value < 0.000000001)
			{
				throw new ArgumentOutOfRangeException(
					"An attempt to commit an invalid value to the element\'s constructor. Value must be bigger than 0");
			}

			Name = name;
			Value = value;
			_elementId++;
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequence"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		public abstract Complex CalculateZ(double frequence);

		#endregion
	}
}