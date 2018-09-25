using System;
using System.Collections.Generic;
using System.Numerics;

namespace CircuitElements
{
	public abstract class CircuitBase : ICircuitElement
	{
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
				if (value == null)
				{
					throw new NullReferenceException(
						"An attempt to assign a null value to the " + nameof(Elements));
				}

				if (value.Count == 0)
				{
					throw new ArgumentException(
						"An attempt to assign an empty List to the " + nameof(Elements));
				}

				_elements = value;

				foreach (var element in _elements)
				{
					element.ElementChanged += ElementChanged;
				}
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
		///     Конструктор
		/// </summary>
		/// <param name="elements"> Список элементов электрической цепи </param>
		public CircuitBase(List<ICircuitElement> elements)
		{
			Elements = elements;
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