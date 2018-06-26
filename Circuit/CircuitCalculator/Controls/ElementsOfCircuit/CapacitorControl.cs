using System;
using CircuitElements;

namespace CircuitCalculator.Controls.ElementsOfCircuit
{
	/// <summary>
	///     userControl, представляющий графическое отображение конденсатора.
	/// </summary>
	public partial class CapacitorControl : ElementControlBase
	{
		#region – – Поля – – 

		/// <summary>
		///     Элемент цепи, представляемый контролом
		/// </summary>
		private Capacitor _element;

		#endregion – – Поля – – 

		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор класса CapacitorControl
		/// </summary>
		/// <param name="element"> Конденсатор </param>
		public CapacitorControl(Capacitor element)
		{
			InitializeComponent();
			if (element != null)
			{
				Element = element;
			}
		}

		#endregion  – – Публичные методы – – 

		#region – – Свойства – – 

		/// <summary>
		///     Получиние и изменение элемента цепи, представляемого контролом
		/// </summary>
		public Capacitor Element
		{
			get => _element;
			set
			{
				if (value != null)
				{
					_element = value;
					valueTextBox.Text = _element.Value.ToString();
					elementName.Text = _element.Name;
				}
				else
				{
					throw new NullReferenceException(
						"Попытка присвоить null значение в CapacitorControl");
				}
			}
		}

		#endregion – – Свойства – – 
	}
}