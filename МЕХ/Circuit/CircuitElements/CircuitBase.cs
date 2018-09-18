using System;
using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements
{
	public abstract class CircuitBase : ICircuitElement
	{
		#region Static fields

		/// <summary>
		///     Уникальный идентификатор.
		/// </summary>
		private static int _circuitId;

		#endregion

		#region Private fields

		/// <summary>
		///     Список элементов цепи
		/// </summary>
		private List<ICircuitElement> _elements;

		#endregion

		#region Properties

		/// <summary>
		///     Список элементов электрической цепи
		/// </summary>
		public List<ICircuitElement> Elements
		{
			get => new List<ICircuitElement>(_elements);
			set
			{
				_elements = value ?? throw new NullReferenceException(
					            "An attempt to assign a null value to the " +
					            nameof(Elements));

				foreach (var element in _elements)
				{
					element.ElementChanged += ElementChanged;
				}
			}
		}

		/// <summary>
		///     ID элемента
		/// </summary>
		public int ElementId { get; } = _circuitId;

		#endregion

		#region Events

		/// <summary>
		///     Событие, которое загорается при изменении элемента
		/// </summary>
		public event ElementStateHandler ElementChanged;

		#endregion

		#region Constructor

		/// <summary>
		///     Конструктор
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public CircuitBase(List<ICircuitElement> elements)
		{
			Elements = elements;
			_circuitId++;
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequence">Частоты сигнала</param>
		/// <returns></returns>
		public abstract Complex CalculateZ(double frequence);

		#endregion
	}
}