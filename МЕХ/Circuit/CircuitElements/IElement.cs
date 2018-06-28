using System.Numerics;

namespace CircuitElements
{
	/// <summary>
	///     Интерфейс элементов
	/// </summary>
	public interface IElement
	{
		#region – – События – – 

		/// <summary>
		///     Событие, которое загорается при смене значения элемента
		/// </summary>
		event ValueStateHandler ValueChanged;

		#endregion – – События – –

		#region – – Публичные методы – – 

		/// <summary>
		///     Расчитать импеданс
		/// </summary>
		/// <param name="f"> Частота сигнала </param>
		/// <returns>Импеданс элемента в комплексной форме</returns>
		Complex CalculateZ(double f);

		#endregion – – Публичные методы – –

		#region – – Свойства – – 

		/// <summary>
		///     Значение элемента
		/// </summary>
		double Value
		{
			get;
			set;
		}

		/// <summary>
		///     Имя элемента
		/// </summary>
		string Name
		{
			get;
			set;
		}

		#endregion – – Свойства – –
	}

	/// <summary>
	///     Делегат, хранящий сигнатуру методов, подписанных на событие ValueChanged
	/// </summary>
	/// <param name="value"> Изменившееся значение </param>
	/// <param name="valueOwner"> объект, который изменился </param>
	public delegate void ValueStateHandler(object value, object valueOwner);
}