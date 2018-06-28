using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CircuitCalculator.Controls.ElementsOfCircuit
{
	/// <summary>
	///     Базовый контрол для всех элементов цепи
	/// </summary>
	public partial class ElementControlBase : UserControl
	{
		#region – – Поля – – 

		/// <summary>
		///     Координаты последнего местоположения элемента
		/// </summary>
		private Point _firstLocation;

		#endregion – – Поля – – 

		#region – – События – – 

		/// <summary>
		///     Событие, загорающееся каждый раз когда элемент заканчивает перемещение
		/// </summary>
		public event ElementPositionStateHandler ElementPositionChanged;

		#endregion – – События – – 

		private void valueTextBox_TextChanged(object sender, EventArgs e)
		{
			if (Convert.ToDouble(valueTextBox.Text) == 0)
			{
				MessageBox.Show("Значение элемента не может быть равным 0", "Ошибка",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				valueTextBox.Text = "1";
			}
		}

		#region – – Приватные методы – – 

		/// <summary>
		///     Инициализирует начальную позицию контрола
		/// </summary>
		private void ElementControl_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_firstLocation = e.Location;
			}
		}

		/// <summary>
		///     Пока ЛКМ нажата, перемещает контрол вслед за мышью
		/// </summary>
		private void ElementControl_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Left = e.X + Left - _firstLocation.X;
				Top = e.Y + Top - _firstLocation.Y;
			}
		}

		/// <summary>
		///     Зажигает событие ElementPositionChanged, которое означает что перемещение элемента окончено
		/// </summary>
		private void ElementControl_MouseUp(object sender, MouseEventArgs e)
		{
			ElementPositionChanged?.Invoke(this, _firstLocation, Location);
		}

		/// <summary>
		///     Валидация ввода double значений в valueTextBox
		/// </summary>
		private void valueTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			//e.KeyChar != (Char)Keys.Back - нужно для того чтобы не блокировалось нажатие клавиши backspace
			//new Regex... - Запятую можно добавить только если их еще нет в строке
			if (char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back ||
			    e.KeyChar == ',' && new Regex(",").Matches(valueTextBox.Text).Count == 0)
			{
				if (e.KeyChar == ' ')
				{
					e.Handled = true;
				}
			}
			else
			{
				e.Handled = true;
			}
		}

		#endregion – – Приватные методы – –

		#region – – Публичные методы – – 

		/// <summary>
		///     Переместить элемент на предыдущую позицию
		/// </summary>
		public void SetOnPreviousPosition()
		{
			// проверка _firstLocation на null не нужна, потому что данный метод
			// не запускается пока не произойдет событие, при котором _firstLocation инициализируется
			Location = _firstLocation;
		}

		/// <summary>
		///     Конструктор класса ElementControlBase
		/// </summary>
		protected ElementControlBase()
		{
			InitializeComponent();
		}

		#endregion  – – Публичные методы – – 
	}

	/// <summary>
	///     Делегат, хранящий сигнатуру методов, подписанных на событие ElementPositionChanged.
	///     Нужен для того чтобы когда элемент перетаскивался на новую позицию, панелью выбиралось
	///     ближайшее доступное место и элемент программно переносился туда
	/// </summary>
	/// <param name="element"> Перетаскиваемый элемент </param>
	/// <param name="lastPosition"> Позиция, на которую его перетащили </param>
	public delegate void ElementPositionStateHandler(ElementControlBase element,
		Point startPosition,
		Point lastPosition);
}