using System;
using System.Globalization;
using System.Windows.Forms;
using CircuitCalculator.Controls.ElementsOfCircuit;
using CircuitElements;

namespace CircuitCalculator
{
	/// <summary>
	///     Форма редактирования эл. цепи
	/// </summary>
	public partial class CircuitRedactorForm : Form
	{
		#region – – Поля – – 

		/// <summary>
		///     Отображаемая цепь
		/// </summary>
		private Circuit _displayingCircuit;

		#endregion – – Поля – –

		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор
		/// </summary>
		public CircuitRedactorForm()
		{
			InitializeComponent();

		#if !DEBUG
			checkButton.Visible = false;
#endif
		}

		#endregion – – Публичные методы – –

		#region – – Свойства – – 

		/// <summary>
		///     Задание отображаемой цепи
		/// </summary>
		public Circuit DisplayingCircuit
		{
			set
			{
				_displayingCircuit =
					value ?? throw new NullReferenceException(
						"Попытка передачи Null значенияя вместо отображаемой цепи");

				RefreshRedactor();

				CleanTable();
			}
		}

		#endregion – – Свойства – –

		#region – – События – – 

		/// <summary>
		///     Событие изменения значения одного из элементов
		/// </summary>
		public event ValueStateHandler CircuitValueChanged;

		#endregion – – События – –

		#region – – Приватные методы – – 

		/// <summary>
		///     Инициализация тестовых элементов
		/// </summary>
		private void InitializeTestingElements()
		{
			if (_displayingCircuit != null)
			{
				CleanTable();
			}

			redactorPanel.CleanPanel();

			for (var i = 1; i < 3; i++)
			{
				var newElementControl = new ResistorControl(new Resistor("R" + i, 2));
				redactorPanel.AddControl(newElementControl);
			}

			var newElementControl1 = new CapacitorControl(new Capacitor("C1", 3));
			redactorPanel[1, 2] = newElementControl1;
			var newElementControl2 = new InductorControl(new Inductor("I1", 4));
			redactorPanel[0, 2] = newElementControl2;
			var newElementControl3 = new InductorControl(new Inductor("I2", 5));
			redactorPanel[1, 1] = newElementControl3;
			var newElementControl4 = new ResistorControl(new Resistor("R3", 6));
			redactorPanel[2, 1] = newElementControl4;

			var newElementControl5 = new StartCircuitControl();
			redactorPanel.AddControl(newElementControl5);

			var newElementControl6 = new EndCirccuitControl();
			redactorPanel.AddControl(newElementControl6);
		}

		/// <summary>
		///     Очистка таблицы
		/// </summary>
		private void CleanTable()
		{
			while (elementGridView.Rows.Count >= 1)
			{
				for (var i = 0; i < elementGridView.Rows.Count; i++)
				{
					elementGridView.Rows.Remove(elementGridView.Rows[i]);
				}
			}
			
			foreach (var element in _displayingCircuit.Elements)
			{
				object[] elementData =
				{
					element.Name, element.Value.ToString(CultureInfo.InvariantCulture)
				};

				elementGridView.Rows.Add(elementData);
			}
		}

		/// <summary>
		///     Добавление резистора на панель
		/// </summary>
		private void AddResistorButton_Click(object sender, EventArgs e)
		{
			var newElementControl =
				new ResistorControl(new Resistor(resistorNameTextBox.Text,
					Convert.ToDouble(resistorValueTextBox.Text)));

			redactorPanel.AddControl(newElementControl);
		}

		/// <summary>
		///     Добавление конденсатора на панель
		/// </summary>
		private void AddCapacitorButton_Click(object sender, EventArgs e)
		{
			var newElementControl =
				new CapacitorControl(new Capacitor(capacitorNameTextBox.Text,
					Convert.ToDouble(capacitorValueTextBox.Text)));

			redactorPanel.AddControl(newElementControl);
		}

		/// <summary>
		///     Добавление катушки индуктивности на панель
		/// </summary>
		private void AddInductorButton_Click(object sender, EventArgs e)
		{
			var newElementControl =
				new InductorControl(new Inductor(inductorNameTextBox.Text,
					Convert.ToDouble(inductorValueTextBox.Text)));

			redactorPanel.AddControl(newElementControl);
		}

		/// <summary>
		///     При закрытии формы, приложение завершает работу
		/// </summary>
		private void CircuitRedactor_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		///     разместить на панели тестовые элементы
		/// </summary>
		private void TestButton_Click(object sender, EventArgs e)
		{
			InitializeTestingElements();
		}

		/// <summary>
		///     Валидация ввода double значений в таблицу при изменении значений элементов
		/// </summary>
		private void ElementGridView_CellValidating(object sender,
			DataGridViewCellValidatingEventArgs e)
		{
			elementGridView.Rows[e.RowIndex].ErrorText = "";

			if (elementGridView.CurrentCell.ColumnIndex != 1)
			{
				return;
			}

			try
			{
				if (!double.TryParse(e.FormattedValue.ToString(), out var newDouble) ||
				    newDouble <= 0)
				{
					e.Cancel = true;
					elementGridView.Rows[e.RowIndex].ErrorText =
						"Значение должно быть положительным вещественным числом";
				}
				else
				{
					_displayingCircuit.Elements[e.RowIndex].Value =
						Convert.ToDouble(e.FormattedValue.ToString());

					RefreshRedactor();
					CircuitValueChanged?.Invoke(
						Convert.ToDouble(e.FormattedValue.ToString()),
						_displayingCircuit.Elements[e.RowIndex]);
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		/// <summary>
		///     Обновить панель редактора
		/// </summary>
		private void RefreshRedactor()
		{
			redactorPanel.CleanPanel();

			var startingElementControl = new StartCircuitControl();
			redactorPanel.AddControl(startingElementControl);

			foreach (var element in _displayingCircuit.Elements)
			{
				if (element is Resistor)
				{
					var newElementControl =
						new ResistorControl(new Resistor(element.Name, element.Value));

					redactorPanel.AddControl(newElementControl);
				}
				else if (element is Inductor)
				{
					var newElementControl =
						new InductorControl(new Inductor(element.Name, element.Value));

					redactorPanel.AddControl(newElementControl);
				}
				else if (element is Capacitor)
				{
					var newElementControl =
						new CapacitorControl(new Capacitor(element.Name, element.Value));

					redactorPanel.AddControl(newElementControl);
				}
				else
				{
					throw new TypeLoadException(
						"Один из элементов цепи не поддерживается редактором.");
				}
			}

			var endingElementControl = new EndCirccuitControl();
			redactorPanel.AddControl(endingElementControl);
		}

		#endregion – – Приватные методы – –
	}
}
