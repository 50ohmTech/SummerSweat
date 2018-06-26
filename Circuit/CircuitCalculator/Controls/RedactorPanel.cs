using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CircuitCalculator.Controls.ElementsOfCircuit;

namespace CircuitCalculator.Controls
{
	/// <summary>
	///     Панель редактора цепи
	/// </summary>
	public partial class RedactorPanel : UserControl
	{
		#region – – Свойства – – 

		/// <summary>
		///     Доступ к контролу по его позиции на панели редактора.
		/// </summary>
		/// <param name="i"> Столбец </param>
		/// <param name="j"> Строка </param>
		/// <returns></returns>
		public ElementControlBase this[int i, int j]
		{
			get
			{
				if (i < 0 || j < 0)
				{
					throw new ArgumentException(
						"Порядковые номера не могут быть отрицательными");
				}

				//вычисление координат по номерам позиции
				var position = new Point(LengthOfControl * i, WidthOfControl * j);
				foreach (var control in _controlList)
				{
					if (control.Location == position)
					{
						return control;
					}
				}

				return null;
			}
			set
			{
				if (i < 0 || j < 0)
				{
					throw new ArgumentException(
						"Порядковые номера не могут быть отрицательными");
				}

				//проверка свободна ли вычисленная позиция
				//если не свободна, добавления не произойдет
				if (IsPositionFree(new Point(LengthOfControl * i, WidthOfControl * j)))
				{
					value.Location = new Point(LengthOfControl * i, WidthOfControl * j);
				}

				{
					panel1.Controls.Add(value);
					_controlList.Add(value);
					_lastPosition = new Point(i * LengthOfControl, j * WidthOfControl);

					// Метод перемещения контрола на указанную позицию подписывается
					// на событие об изменении позиции каждого добавляемого контроля
					value.ElementPositionChanged += AddOnPoint;
				}
			}
		}

		#endregion – – Свойства – – 

		#region – – Константы – – 

		/// <summary>
		///     Длина хранимых контролов
		/// </summary>
		private const int LengthOfControl = 61;

		/// <summary>
		///     Высота хранимых контролов
		/// </summary>
		private const int WidthOfControl = 74;

		#endregion – – Константы – – 

		#region – – Поля – – 

		/// <summary>
		///     Список всех контролов
		/// </summary>
		private readonly List<ElementControlBase> _controlList;

		/// <summary>
		///     Координаты последнего добавленного элемента
		/// </summary>
		private Point _lastPosition;

		#endregion – – Поля – – 

		#region – – Приватные методы – – 

		/// <summary>
		///     Вычисляет ближайшую к указаной точке координат позицию на панели
		/// </summary>
		/// <param name="currentPosition"> Проверяемая точка </param>
		/// <returns></returns>
		private Point ClosestPositionSquare(Point currentPosition)
		{
			return new Point(currentPosition.X / LengthOfControl,
				currentPosition.Y / WidthOfControl);
		}

		/// <summary>
		///     Добавление элемента на конкретную позицию, если это возможно
		/// </summary>
		/// <param name="control"> Перемещаемый контрол </param>
		/// <param name="firstPosition"> Начальная позиция в координатах </param>
		/// <param name="lastPosition"> Конечная позиция в координатах </param>
		private void AddOnPoint(ElementControlBase control, Point firstPosition,
			Point lastPosition)
		{
			if (control == null || firstPosition == null || lastPosition == null)
			{
				throw new NullReferenceException();
			}

			if (IsPositionFree(ClosestPositionSquare(lastPosition)))
			{
				this[ClosestPositionSquare(lastPosition).X,
					ClosestPositionSquare(lastPosition).Y] = control;
			}
			else
			{
				control.SetOnPreviousPosition();
			}
		}

		/// <summary>
		///     Проверяет свободна ли передаваемая локицая координат
		/// </summary>
		/// <param name="position"> Проверяемые координаты </param>
		/// <returns></returns>
		private bool IsPositionFree(Point position)
		{
			if (position == null)
			{
				throw new NullReferenceException();
			}

			foreach (var control in _controlList)
			{
				if (control.Location == position)
				{
					return false;
				}
			}

			return true;
		}

		#endregion – – Приватные методы – –

		#region – – Публичные методы – – 

		/// <summary>
		///     Добавляет новый контрол на следующую свободную позицию в последней измененной строке
		/// </summary>
		/// <param name="controlBase"> Добавляемый контрол </param>
		/// <param name="distance"> Через сколько позиций от данной начинать попытки вставки </param>
		public void AddControl(ElementControlBase controlBase, int distance = 0)
		{
			if (IsPositionFree(
				new Point(_lastPosition.X + distance * LengthOfControl, _lastPosition.Y)))
			{
				//если позиция свободна, добавляем на нее новый контрол
				this[_lastPosition.X / LengthOfControl + distance,
					_lastPosition.Y / WidthOfControl] = controlBase;

				_lastPosition = new Point(_lastPosition.X + distance * LengthOfControl,
					_lastPosition.Y);
			}
			else
			{
				//проверяем следующую позицию
				AddControl(controlBase, distance + 1);
			}
		}

		/// <summary>
		///     Удаляет все контролы с панели
		/// </summary>
		public void CleanPanel()
		{
			_lastPosition = new Point(0 * LengthOfControl, 1 * WidthOfControl);
			foreach (var control in _controlList)
			{
				control.Dispose();
			}

			_controlList.Clear();
		}

		/// <summary>
		///     Контруктор класса RedactorPanel
		/// </summary>
		public RedactorPanel()
		{
			InitializeComponent();
			_controlList = new List<ElementControlBase>();
			_lastPosition = new Point(0 * LengthOfControl, 1 * WidthOfControl);
		}

		#endregion  – – Публичные методы – – 
	}
}