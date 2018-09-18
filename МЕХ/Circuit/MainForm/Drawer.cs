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
	///     Рисовальщик цепи.
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
		///     Сжатие элементов по X.
		/// </summary>
		private const int _compressionElementX = 30;

		/// <summary>
		///     Сжатие элементов по Y.
		/// </summary>
		private const int _compressionElementY = 20;

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
		/// <param name="root">Корень поддерева.</param>
		/// <param name="displacement">Смещение.</param>
		/// <returns>Размер поддерева.</returns>
		private static Point DrawCircuit(ICircuitElement root, Point displacement)
		{
			if (root is ElementBase element)
			{
				DrawElement(_graphics, Pen, element, displacement);
				return new Point(1, 1);
			}

			var maxCount = 0;
			var steps = new List<int>();

			if (root is ParallelCircuit parallelCircuit)
			{
				_graphics.DrawLine(Pen,
					new Point(displacement.X, _elementPositionY + displacement.Y),
					new Point(_elementPositionY + displacement.X,
						_elementPositionY + displacement.Y));

				for (var i = 0; i < parallelCircuit.Elements.Count; i++)
				{
					var count = DrawCircuit(parallelCircuit.Elements[i],
						new Point(_elementPositionY + displacement.X,
							steps.Sum() * _lineSpacingElementWidth + displacement.Y));

					steps.Add(count.Y);

					if (maxCount < count.X)
					{
						var step = 0;
						for (var j = 0; j < i; j++)
						{
							_graphics.DrawLine(Pen,
								new Point(
									_elementPositionY +
									maxCount * _lineSpacingAfterElement + displacement.X,
									_elementPositionY + step * _lineSpacingElementWidth +
									displacement.Y),
								new Point(
									_elementPositionY +
									count.X * _lineSpacingAfterElement + displacement.X,
									_elementPositionY + step * _lineSpacingElementWidth +
									displacement.Y));

							step += steps[j];
						}

						maxCount = count.X;
					}
					else
					{
						var step = 0;
						for (var j = 0; j < i; j++)
						{
							step += steps[j];
						}

						_graphics.DrawLine(Pen,
							new Point(
								_elementPositionY + count.X * _lineSpacingAfterElement +
								displacement.X,
								_elementPositionY + step * _lineSpacingElementWidth +
								displacement.Y),
							new Point(
								_elementPositionY + maxCount * _lineSpacingAfterElement +
								displacement.X,
								_elementPositionY + step * _lineSpacingElementWidth +
								displacement.Y));
					}
				}

				_graphics.DrawLine(Pen,
					new Point(
						_elementPositionY + maxCount * _lineSpacingAfterElement +
						displacement.X, _elementPositionY + displacement.Y),
					new Point(
						_lineSpacingAfterElement + maxCount * _lineSpacingAfterElement +
						displacement.X, _elementPositionY + displacement.Y));


				_graphics.DrawLine(Pen,
					new Point(_elementPositionY + displacement.X,
						_elementPositionY + displacement.Y),
					new Point(_elementPositionY + displacement.X,
						_elementPositionY + (steps.Sum() - steps[steps.Count - 1]) *
						_lineSpacingElementWidth +
						displacement.Y));

				_graphics.DrawLine(Pen,
					new Point(
						_elementPositionY + maxCount * _lineSpacingAfterElement +
						displacement.X, _elementPositionY + displacement.Y),
					new Point(
						_elementPositionY + maxCount * _lineSpacingAfterElement +
						displacement.X,
						_elementPositionY + (steps.Sum() - steps[steps.Count - 1]) *
						_lineSpacingElementWidth +
						displacement.Y));

				return new Point(maxCount + 1, steps.Sum());
			}

			if (root is SerialCircuit serialCircuit)
			{
				foreach (var child in serialCircuit.Elements)
				{
					var count = DrawCircuit(child,
						new Point(steps.Sum() * _lineSpacingAfterElement + displacement.X,
							displacement.Y));

					steps.Add(count.X);

					if (maxCount < count.Y)
					{
						maxCount = count.Y;
					}
				}
			}

			return new Point(steps.Sum(), maxCount);
		}


		/// <summary>
		///     Рисовать элемент электрической цепи.
		/// </summary>
		/// <param name="graphics">Поверхность рисования.</param>
		/// <param name="pen">Ручка.</param>
		/// <param name="element">Элемент электрической цепи.</param>
		/// <param name="displacement">Смещение.</param>
		private static void DrawElement(Graphics graphics, Pen pen, ElementBase element,
			Point displacement)
		{
			var brush = new SolidBrush(Color.Black);
			switch (element)
			{
				case Resistor _:
					graphics.DrawLine(pen,
						new Point(_radiusInductor + displacement.X,
							_compressionElementY + displacement.Y),
						new Point(_radiusInductor + displacement.X,
							_compressionElementX + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_radiusInductor + displacement.X,
							_compressionElementX + displacement.Y),
						new Point(_lineSpacingElementWidth + displacement.X,
							_compressionElementX + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + displacement.X,
							_compressionElementY + displacement.Y),
						new Point(_lineSpacingElementWidth + displacement.X,
							_compressionElementX + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + displacement.X,
							_compressionElementY + displacement.Y),
						new Point(_radiusInductor + displacement.X,
							_compressionElementY + displacement.Y));

					graphics.DrawLine(pen,
						new Point(0 + displacement.X, _elementPositionY + displacement.Y),
						new Point(_radiusInductor + displacement.X,
							_elementPositionY + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + displacement.X,
							_elementPositionY + displacement.Y),
						new Point(_lineSpacingAfterElement + displacement.X,
							_elementPositionY + displacement.Y));

					graphics.DrawString(element.Name, Font, brush,
						_capacitorPositionY + displacement.X,
						_lineSpacingElementWidth + displacement.Y);

					break;
				case Capacitor _:
					graphics.DrawLine(pen,
						new Point(_compressionElementY + displacement.X,
							_capacitorPositionY + displacement.Y),
						new Point(_compressionElementY + displacement.X,
							_bottomHeightCapacitor + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_compressionElementX + displacement.X,
							_capacitorPositionY + displacement.Y),
						new Point(_compressionElementX + displacement.X,
							_bottomHeightCapacitor + displacement.Y));

					graphics.DrawLine(pen,
						new Point(0 + displacement.X, _elementPositionY + displacement.Y),
						new Point(_compressionElementY + displacement.X,
							_elementPositionY + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_compressionElementX + displacement.X,
							_elementPositionY + displacement.Y),
						new Point(_lineSpacingAfterElement + displacement.X,
							_elementPositionY + displacement.Y));

					graphics.DrawString(element.Name, Font, brush,
						_capacitorPositionY + displacement.X,
						_lineSpacingElementWidth + displacement.Y);

					break;
				case Inductor _:
					graphics.DrawArc(pen, _radiusInductor + displacement.X,
						_compressionElementY + displacement.Y,
						_radiusInductor, _radiusInductor, _inductorPartСircleDegrees,
						_inductorPartСircleDegrees);

					graphics.DrawArc(pen, _compressionElementY + displacement.X,
						_compressionElementY + displacement.Y,
						_radiusInductor, _radiusInductor, _inductorPartСircleDegrees,
						_inductorPartСircleDegrees);

					graphics.DrawArc(pen, _compressionElementX + displacement.X,
						_compressionElementY + displacement.Y,
						_radiusInductor, _radiusInductor, _inductorPartСircleDegrees,
						_inductorPartСircleDegrees);

					graphics.DrawLine(pen,
						new Point(0 + displacement.X, _elementPositionY + displacement.Y),
						new Point(_radiusInductor + displacement.X,
							_elementPositionY + displacement.Y));

					graphics.DrawLine(pen,
						new Point(_lineSpacingElementWidth + displacement.X,
							_elementPositionY + displacement.Y),
						new Point(_lineSpacingAfterElement + displacement.X,
							_elementPositionY + displacement.Y));

					graphics.DrawString(element.Name, Font, brush,
						_capacitorPositionY + displacement.X,
						_lineSpacingElementWidth + displacement.Y);

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
			var bitmap = new Bitmap(1000, 1000);
			_graphics = Graphics.FromImage(bitmap);
			DrawCircuit(circuit, Margin);
			return bitmap;
		}

		#endregion
	}
}