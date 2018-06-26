using System.Windows.Forms;
using CircuitElements;

namespace CircuitCalculator.Controls.ElementsOfCircuit
{
	/// <summary>
	///     userControl, представляющий графическое отображение катушки индуктивности.
	/// </summary>
	public partial class InductorControl : ElementControlBase
	{
		#region – – Поля – – 

		/// <summary>
		///     Элемент цепи, представляемый контролом
		/// </summary>
		private Inductor _element;

		#endregion – – Поля – – 

		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор класса InductorControl
		/// </summary>
		/// <param name="element"> Катушка индуктивности </param>
		public InductorControl(Inductor element)
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
		public Inductor Element
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
						"Попытка присвоить null значение в поле Element индуктора.",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		#endregion – – Свойства – – 
	}
}