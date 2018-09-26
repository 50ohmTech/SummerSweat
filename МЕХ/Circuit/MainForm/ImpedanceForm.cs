using System;
using System.Windows.Forms;
using CircuitElements;

namespace MainForm
{
	public partial class ImpedanceForm : Form
	{
		#region Private fields

		/// <summary>
		///     Обрабатываемая цепь
		/// </summary>
		private CircuitBase _circuit;

		/// <summary>
		///     Конечное значение
		/// </summary>
		private double _finalValue;

		/// <summary>
		///     Начальное значение
		/// </summary>
		private double _initialValue;

		/// <summary>
		///     Шаг
		/// </summary>
		private double _step;

		#endregion

		#region Properties

		/// <summary>
		///     Обрабатываемая цепь
		/// </summary>
		public CircuitBase Circuit
		{
			get => _circuit;
			set
			{
				if (value != null)
				{
					_circuit = value;
					if (CanCalculate())
					{
						Calculate();
					}
				}
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		///     Конструктор
		/// </summary>
		public ImpedanceForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods
		
		/// <summary>
		///     Обработчик события закрытия формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ImpedanceForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Visible = false;
			e.Cancel = true;
			_dataGridView.Rows.Clear();
			_circuit = null;
			_initialValue = 0;
			_finalValue = 0;
			_step = 0;
			initialValue.Text = string.Empty;
			finalValue.Text = string.Empty;
			step.Text = string.Empty;
		}

		/// <summary>
		///     Произвести расчеты и вывести их в таблицу
		/// </summary>
		private void Calculate()
		{
			_dataGridView.Rows.Clear();
			for (var i = _initialValue; i <= _finalValue; i += _step)
			{
				var frequency = Circuit.CalculateZ(i);
				_dataGridView.Rows.Add(i,
					frequency.Real + (frequency.Imaginary < 0 ? " - " : " + ") +
					Math.Abs(frequency.Imaginary) + " * i");
			}
		}

		/// <summary>
		///     Валидация текстбоксов
		/// </summary>
		/// <param name="textBox"></param>
		/// <returns></returns>
		private bool TextBoxValidating(Control textBox)
		{
			if (string.IsNullOrEmpty(textBox.Text))
			{
				errorProvider.SetError(textBox, "Введите значение");
				return false;
			}

			if (textBox.Text.Contains(" "))
			{
				errorProvider.SetError(textBox, "Поле не должно содержать пробелы.");
				return false;
			}

			return true;
		}

		/// <summary>
		///     Возможно ли произвести расчеты по имеющимся данным
		/// </summary>
		/// <returns></returns>
		private bool CanCalculate()
		{
			errorProvider.Clear();

			//Начальное значение
			if (!TextBoxValidating(initialValue))
			{
				return false;
			}

			if (!double.TryParse(initialValue.Text, out _initialValue))
			{
				errorProvider.SetError(initialValue, "Поле не является числом");
				return false;
			}

			//Конечное значение
			if (!TextBoxValidating(finalValue))
			{
				return false;
			}

			if (!double.TryParse(finalValue.Text, out _finalValue))
			{
				errorProvider.SetError(finalValue, "Поле не является числом");
				return false;
			}

			//Шаг 
			if (!TextBoxValidating(step))
			{
				return false;
			}

			if (!double.TryParse(step.Text, out _step))
			{
				errorProvider.SetError(step, "Поле не является числом");
				return false;
			}

			if (step.Text[step.TextLength - 1] == ',')
			{
				errorProvider.SetError(step, "Поле не должно заканчиваться запятой");
				return false;
			}

			errorProvider.Clear();
			return true;
		}

		/// <summary>
		///     Выполняется при изменении текста текстбокса finalValue
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void finalValue_TextChanged(object sender, EventArgs e)
		{
			if (CanCalculate())
			{
				Calculate();
			}
		}

		/// <summary>
		///     Выполняется при изменении текста текстбокса initialValue
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void initialValue_TextChanged(object sender, EventArgs e)
		{
			if (CanCalculate())
			{
				Calculate();
			}
		}

		private void step_Leave(object sender, EventArgs e)
		{
			step.Text = step.Text.Replace(".", ",");
			if (CanCalculate())
			{
				Calculate();
			}
		}

		private void finalValue_Leave(object sender, EventArgs e)
		{
			finalValue.Text = finalValue.Text.Replace(".", ",");
		}

		private void initialValue_Leave(object sender, EventArgs e)
		{
			initialValue.Text = initialValue.Text.Replace(".", ",");
		}

		#endregion
	}
}