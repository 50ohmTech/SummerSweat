using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CircuitCalculator.Properties;
using CircuitElements;

namespace CircuitCalculator.Controls
{
	public partial class ElementControl : UserControl
	{
		#region – – Поля – – 

		/// <summary>
		///     Элемент цепи, представляемый контролом
		/// </summary>
		private IElement _element;

		/// <summary>
		///     Координаты последнего местоположения элемента
		/// </summary>
		private Point _previousLocation;

		#endregion – – Поля – – 

		#region – – Свойства – – 

		/// <summary>
		///     Получиние и изменение элемента цепи, представляемого контролом
		/// </summary>
		public IElement Element
		{
			get => _element;
			set
			{
				if (value != null)
				{
					_element = value;
					NameLabel.Text = _element.Name;
					ValueTextBox.Text =
						_element.Value.ToString(CultureInfo.InvariantCulture);
					switch (value)
					{
						case Resistor _:
							ElementPictureBox.Image = Resources.resistor;
							break;
						case Inductor _:
							ElementPictureBox.Image = Resources.inductor;
							break;
						case Capacitor _:
							ElementPictureBox.Image = Resources.condensator1;
							break;
						default:
							throw new InvalidOperationException();
					}
				}
				else
				{
					throw new ArgumentNullException(
						"Попытка присвоить null значение в ElementControl");
				}
			}
		}

		#endregion – – Свойства – – 

		#region – – События – – 

		/// <summary>
		///     Событие, загорающееся каждый раз когда элемент заканчивает перемещение
		/// </summary>
		public event ElementPositionStateHandler ElementPositionChanged;

		#endregion – – События – – 

		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор класса ElementControlBase для создания элементов цепи, имеющих номинал
		/// </summary>
		public ElementControl(IElement element)
		{
			InitializeComponent();
			if (element != null)
			{
				Element = element;
			}
		}

		/// <summary>
		///		Конструктор класса ElementControlBase для создания элементов цепи, начального или конечного
		/// </summary>
		/// <param name="element"></param>
		public ElementControl(DrawingElements element)
		{
			InitializeComponent();

			ValueTextBox.Visible = false;
			switch (element)
			{
				case DrawingElements.StartingElement:
					ElementPictureBox.Image = Resources.Starting_Part;
					ValueTextBox.Visible = false;
					NameLabel.Text = "A";
					break;
				case DrawingElements.FiniteElement:
					ElementPictureBox.Image = Resources.Ending_Part;
					ValueTextBox.Visible = false;
					NameLabel.Text = "B";
					break;
				default:
					throw new InvalidEnumArgumentException();
			}
		}

		/// <summary>
		///     Переместить элемент на предыдущую позицию
		/// </summary>
		public void SetOnPreviousPosition()
		{
			// проверка _previousLocation на null не нужна, потому что данный метод
			// не запускается пока не произойдет событие, при котором _previousLocation инициализируется
			Location = _previousLocation;
		}

		#endregion  – – Публичные методы – – 

		#region – – Приватные методы – – 

		/// <summary>
		///     Инициализирует начальную позицию контрола
		/// </summary>
		private void ElementControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_previousLocation = e.Location;
			}
		}

		/// <summary>
		///     Пока ЛКМ нажата, перемещает контрол вслед за мышью
		/// </summary>
		private void ElementControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Left = e.X + Left - _previousLocation.X;
				Top = e.Y + Top - _previousLocation.Y;
			}
		}

		private void ValueTextBox_TextChanged(object sender, EventArgs e)
		{
			ValueTextBox.Text = ValueTextBox.Text.Replace('.', ',');

			if (Math.Abs(Convert.ToDouble(ValueTextBox.Text)) < 0.000000001)
			{
				MessageBox.Show("Значение элемента не может быть равным 0", "Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		/// <summary>
		///     Зажигает событие ElementPositionChanged, которое означает что перемещение элемента окончено
		/// </summary>
		private void ElementControl_MouseUp(object sender, MouseEventArgs e)
		{
			ElementPositionChanged?.Invoke(this, _previousLocation, Location);
		}

		#endregion – – Приватные методы – –
	}

	/// <summary>
	///     Делегат, хранящий сигнатуру методов, подписанных на событие ElementPositionChanged.
	///     Нужен для того чтобы когда элемент перетаскивался на новую позицию, панелью выбиралось
	///     ближайшее доступное место и элемент программно переносился туда
	/// </summary>
	/// <param name="element"> Перетаскиваемый элемент </param>
	/// <param name="lastPosition"> Позиция, на которую его перетащили </param>
	public delegate void ElementPositionStateHandler(ElementControl element,
		Point startPosition,
		Point lastPosition);
}