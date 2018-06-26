using System.Windows.Forms;
using CircuitElements;

namespace CircuitCalculator.Controls.ElementsOfCircuit
{
	/// <summary>
	///     userControl, представляющий графическое отображение резистора.
	/// </summary>
	public partial class ResistorControl : ElementControlBase
	{
		#region – – Поля – – 

		/// <summary>
		///     Элемент цепи, представляемый контролом
		/// </summary>
		private Resistor _element;

		#endregion – – Поля – – 

		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор класса ResistorControl
		/// </summary>
		/// <param name="element"> Резистор </param>
		public ResistorControl(Resistor element)
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
		public Resistor Element
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
					MessageBox.Show(
						"Попытка присвоить null значение в поле Element резстора.",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		#endregion – – Свойства – – 
	}
}