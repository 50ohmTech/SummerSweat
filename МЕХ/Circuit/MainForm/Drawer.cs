using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CircuitElements;
using CircuitElements.Circuits;
using CircuitElements.Elements;

namespace MainForm
{
	/// <summary>
	///     Отрисовщик цепи.
	/// </summary>
	public static class Drawer
	{
		#region Constants

		/// <summary>
		///     Высота нижней части конденсатора.
		/// </summary>
		private const int _bottomHeightCapacitor = 35;

		/// <summary>
		///     Позиция конденсатора от линии.
		/// </summary>
		private const int _capacitorPositionY = 15;

		/// <summary>
		///     Размеры элементов по X.
		/// </summary>
		private const int _sizeElementX = 30;

		/// <summary>
		///     Размеры элементов по Y.
		/// </summary>
		private const int _sizeElementY = 20;

		/// <summary>
		///     Позиция элемента по Y от линии.
		/// </summary>
		private const int _elementPositionY = 25;

		/// <summary>
		///     Часть круга катушки в градусах.
		/// </summary>
		private const int _inductorPartСircleDegrees = 180;

		/// <summary>
		///     Отступ после элемента.
		/// </summary>
		private const int _lineSpacingAfterElement = 50;

		/// <summary>
		///     Ширина элемента.
		/// </summary>
		private const int _lineSpacingElementWidth = 40;

		/// <summary>
		///     Радиус катушки.
		/// </summary>
		private const int _radiusInductor = 10;

		#endregion

		#region Static fields

		/// <summary>
		///     Формат текста.
		/// </summary>
		private static Font _font =
			new Font(new FontFamily("Calibri"), 10, FontStyle.Regular);

		/// <summary>
		///     Поверхность рисования.
		/// </summary>
		private static Graphics _graphics;

		/// <summary>
		///     Ручка.
		/// </summary>
		private static Pen _pen = new Pen(Color.Black);

		#endregion

		#region Properties

		/// <summary>
		///     Отступ.
		/// </summary>
		private static Point Margin { get; } = new Point(0, 0);


		/// <summary>
		///     Формат текста.
		/// </summary>
		public static Font Font
		{
			get => _font;
			set => _font = value ?? throw new ArgumentNullException(nameof(value));
		}

		/// <summary>
		///     Ручка.
		/// </summary>
		public static Pen Pen
		{
			get => _pen;
			set => _pen = value ?? throw new ArgumentNullException(nameof(value));
		}

		#endregion

		#region Private methods

		/// <summary>
		///     Рисовать схему электрической цепи.
		/// </summary>
		/// <param name="root">рисуемая цепь</param>
		/// <param name="margin">смещение</param>
		/// <returns>Размер подцепи</returns>
		private static Size DrawCircuit(ICircuitElement root, Point margin)
		{
			if (root is ElementBase element)
			{
				DrawElement(_graphics, Pen, element, margin);
				return new Size(1, 1);
			}

			if (root is ParallelCircuit parallelCircuit)
			{
				return DrawParallelCircuit(parallelCircuit, margin);
			}

			return DrawSerialCircuit(root as SerialCircuit, margin);
		}

		/// <summary>
		///     Отрисовка последовательного соединения
		/// </summary>
		/// <param name="serialCircuit">рисуемая цепь</param>
		/// <param name="margin">смещение</param>
		/// <returns>Размер подцепи</returns>
		private static Size DrawSerialCircuit(SerialCircuit serialCircuit,
			Point margin)
		{
			var maxCount = 0;
			var steps = new List<int>();

			foreach (var child in serialCircuit.Elements)
			{
				var count = DrawCircuit(child,
					new Point(steps.Sum() * _lineSpacingAfterElement + margin.X,
						margin.Y));

				steps.Add(count.Width);

				if (maxCount < count.Height)
				{
					maxCount = count.Height;
				}
			}

			return new Size(steps.Sum(), maxCount);
		}

		/// <summary>
		///     Отрисовка параллельного соединения
		/// </summary>
		/// <param name="parallelCircuit">рисуемая цепь</param>
		/// <param name="margin">смещение</param>
		/// <returns>Размер подцепи</returns>
		private static Size DrawParallelCircuit(ParallelCircuit parallelCircuit,
			Point margin)
		{
			var maxCount = 0;
			var steps = new List<int>();

			//Линия перед параллельным соединением
			_graphics.DrawLine(Pen,
				new Point(margin.X, _elementPositionY + margin.Y),
				new Point(_elementPositionY + margin.X,
					_elementPositionY + margin.Y));

			for (var i = 0; i < parallelCircuit.Elements.Count; i++)
			{
				var count = DrawCircuit(parallelCircuit.Elements[i],
					new Point(_elementPositionY + margin.X,
						steps.Sum() * _lineSpacingElementWidth + margin.Y));

				steps.Add(count.Height);

				//Дорисовка линий в параллельном соединении, где над или под линией есть элементы а само соединение между другими
				if (maxCount < count.Width)
				{
					var step = 0;

					for (var j = 0; j < i; j++)
					{
						_graphics.DrawLine(Pen,
							new Point(
								_elementPositionY +
								maxCount * _lineSpacingAfterElement + margin.X,
								_elementPositionY + step * _lineSpacingElementWidth +
								margin.Y),
							new Point(
								_elementPositionY +
								count.Width * _lineSpacingAfterElement + margin.X,
								_elementPositionY + step * _lineSpacingElementWidth +
								margin.Y));

						step += steps[j];
					}

					maxCount = count.Width;
				}

				//Дорисовка линий в параллельном соединении, где над или под линией есть элементы а само соединение скраю
				else
				{
					var step = 0;
					for (var j = 0; j < i; j++)
					{
						step += steps[j];
					}

					_graphics.DrawLine(Pen,
						new Point(
							_elementPositionY + count.Width * _lineSpacingAfterElement +
							margin.X,
							_elementPositionY + step * _lineSpacingElementWidth +
							margin.Y),
						new Point(
							_elementPositionY + maxCount * _lineSpacingAfterElement +
							margin.X,
							_elementPositionY + step * _lineSpacingElementWidth +
							margin.Y));
				}
			}

			//Линия после параллельного соединения
			_graphics.DrawLine(Pen,
				new Point(
					_elementPositionY + maxCount * _lineSpacingAfterElement +
					margin.X, _elementPositionY + margin.Y),
				new Point(
					_lineSpacingAfterElement + maxCount * _lineSpacingAfterElement +
					margin.X, _elementPositionY + margin.Y));

			//Левая крайняя линия параллельного соединения
			_graphics.DrawLine(Pen,
				new Point(_elementPositionY + margin.X,
					_elementPositionY + margin.Y),
				new Point(_elementPositionY + margin.X,
					_elementPositionY + (steps.Sum() - steps[steps.Count - 1]) *
					_lineSpacingElementWidth +
					margin.Y));

			//Правая крайняя линия параллельного соединения
			_graphics.DrawLine(Pen,
				new Point(
					_elementPositionY + maxCount * _lineSpacingAfterElement +
					margin.X, _elementPositionY + margin.Y),
				new Point(
					_elementPositionY + maxCount * _lineSpacingAfterElement +
					margin.X,
					_elementPositionY + (steps.Sum() - steps[steps.Count - 1]) *
					_lineSpacingElementWidth +
					margin.Y));

			return new Size(maxCount + 1, steps.Sum());
		}

		/// <summary>
		///     Рисовать элемент электрической цепи.
		/// </summary>
		/// <param name="graphics">Поверхность рисования.</param>
		/// <param name="pen">Ручка.</param>
		/// <param name="element">Элемент электрической цепи.</param>
		/// <param name="margin">Смещение.</param>
		private static void DrawElement(Graphics graphics, Pen pen, ElementBase element,
			Point margin)
		{
			var brush = new SolidBrush(Color.Black);
			switch (element)
			{
				case Resistor _:
					graphics.DrawLine(pen,
						new Point(_radiusInductor + margin.X,
							_sizeElementY + margin.Y),
						new Point(_radiusInductor + margin.X,
							_sizeElementX + margin.Y));

					graphics.DrawLine(pen,
						new Point(_radiusInductor + margin.X,
							_sizeElementX + margin.Y),
						new Point(_lineSpacingElementWidth + margin.X,
							_sizeElementX + margin.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + margin.X,
							_sizeElementY + margin.Y),
						new Point(_lineSpacingElementWidth + margin.X,
							_sizeElementX + margin.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + margin.X,
							_sizeElementY + margin.Y),
						new Point(_radiusInductor + margin.X,
							_sizeElementY + margin.Y));

					graphics.DrawLine(pen,
						new Point(0 + margin.X, _elementPositionY + margin.Y),
						new Point(_radiusInductor + margin.X,
							_elementPositionY + margin.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + margin.X,
							_elementPositionY + margin.Y),
						new Point(_lineSpacingAfterElement + margin.X,
							_elementPositionY + margin.Y));

					graphics.DrawString(element.Name, Font, brush,
						_capacitorPositionY + margin.X,
						_lineSpacingElementWidth + margin.Y);

					break;
				case Capacitor _:
					graphics.DrawLine(pen,
						new Point(_sizeElementY + margin.X,
							_capacitorPositionY + margin.Y),
						new Point(_sizeElementY + margin.X,
							_bottomHeightCapacitor + margin.Y));

					graphics.DrawLine(pen,
						new Point(_sizeElementX + margin.X,
							_capacitorPositionY + margin.Y),
						new Point(_sizeElementX + margin.X,
							_bottomHeightCapacitor + margin.Y));

					graphics.DrawLine(pen,
						new Point(0 + margin.X, _elementPositionY + margin.Y),
						new Point(_sizeElementY + margin.X,
							_elementPositionY + margin.Y));

					graphics.DrawLine(pen,
						new Point(_sizeElementX + margin.X,
							_elementPositionY + margin.Y),
						new Point(_lineSpacingAfterElement + margin.X,
							_elementPositionY + margin.Y));

					graphics.DrawString(element.Name, Font, brush,
						_capacitorPositionY + margin.X,
						_lineSpacingElementWidth + margin.Y);

					break;
				case Inductor _:
					graphics.DrawArc(pen, _radiusInductor + margin.X,
						_sizeElementY + margin.Y,
						_radiusInductor, _radiusInductor, _inductorPartСircleDegrees,
						_inductorPartСircleDegrees);

					graphics.DrawArc(pen, _sizeElementY + margin.X,
						_sizeElementY + margin.Y,
						_radiusInductor, _radiusInductor, _inductorPartСircleDegrees,
						_inductorPartСircleDegrees);

					graphics.DrawArc(pen, _sizeElementX + margin.X,
						_sizeElementY + margin.Y,
						_radiusInductor, _radiusInductor, _inductorPartСircleDegrees,
						_inductorPartСircleDegrees);

					graphics.DrawLine(pen,
						new Point(0 + margin.X, _elementPositionY + margin.Y),
						new Point(_radiusInductor + margin.X,
							_elementPositionY + margin.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + margin.X,
							_elementPositionY + margin.Y),
						new Point(_lineSpacingAfterElement + margin.X,
							_elementPositionY + margin.Y));

					graphics.DrawString(element.Name, Font, brush,
						_capacitorPositionY + margin.X,
						_lineSpacingElementWidth + margin.Y);

					break;
			}
		}

		#endregion

		#region Public methods

		/// <summary>
		///     Нарисовать цепь.
		/// </summary>
		public static Bitmap DrawCircuit(CircuitBase circuit)
		{
			var bitmap = new Bitmap((circuit.GetCircuitLength() + 1) * _sizeElementX * 2,
				(circuit.GetCircuitWidth() + 1) * _sizeElementY * 2);

			_graphics = Graphics.FromImage(bitmap);
			DrawCircuit(circuit, Margin);
			return bitmap;
		}

		#endregion
	}
}