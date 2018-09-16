﻿using System.Numerics;

namespace CircuitElements
{
	public interface ICircuitElement
	{
		#region Events

		/// <summary>
		///     Событие, которое загорается при изменении элемента
		/// </summary>
		event ElementStateHandler ElementChanged;

		#endregion

		#region Public methods

		/// <summary>
		///     Расчитать импаденс по входной частоте
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		Complex CalculateZ(double frequence);

		#endregion
	}

	/// <summary>
	///     Делегат, хранящий сигнатуру методов, подписанных на событие ValueChanged
	/// </summary>
	/// <param name="value"> Изменившееся значение </param>
	/// <param name="valueOwner"> объект, который изменился </param>
	public delegate void ElementStateHandler(object newValue, ElementBase valueOwner);
}