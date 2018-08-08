using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using CircuitCalculator.Controls;
using CircuitCalculator.Factories;
using CircuitCalculator.Validation;
using CircuitElements;

namespace CircuitCalculator
{
	/// <summary>
	///     Форма редактирования эл. цепи
	/// </summary>
	public partial class CircuitEditorForm : Form
	{
		#region – – Публичные методы – – 

		/// <summary>
		///     Конструктор
		/// </summary>
		public CircuitEditorForm()
		{
			InitializeComponent();

			InitializeCircuits();
		#if !DEBUG
			testButton.Visible = false;
#endif
		}

		#endregion – – Публичные методы – –

		#region – – Свойства – – 

		/// <summary>
		///     Задание отображаемой цепи
		/// </summary>
		public Circuit CurrentCircuit
		{
			get => _currentCircuit;
			set
			{
				_currentCircuit =
					value ?? throw new NullReferenceException(
						"Попытка передачи Null значенияя вместо отображаемой цепи");

				RefreshRedactor();

				CleanTable();
			}
		}

		#endregion – – Свойства – –

		#region – – События – – 

		/// <summary>
		///     Событие, которое загорается при выборе цепи из comboBox'a
		/// </summary>
		public event ComboBoxStateHandler CircuitChanged;

		#endregion – – События – –

		#region – – События – – 

		/// <summary>
		///     Событие изменения значения одного из элементов
		/// </summary>
		public event ValueStateHandler CircuitValueChanged;

		#endregion – – События – –

		#region – – Поля – – 

		/// <summary>
		///     Отображаемая цепь
		/// </summary>
		private Circuit _currentCircuit;

		/// <summary>
		///     Список доступных цепей
		/// </summary>
		private List<Circuit> _circuitList;

		#endregion – – Поля – –

		#region – – Приватные методы – – 

		/// <summary>
		///     Инициализация тестовых элементов
		/// </summary>
		private void InitializeTestingElements()
		{
			if (_currentCircuit != null)
			{
				CleanTable();
			}

			redactorPanel.CleanPanel();

			for (var i = 1; i < 3; i++)
			{
				var newElementControl = new ElementControl(new Resistor("R" + i, 2));
				redactorPanel.AddControl(newElementControl);
			}

			var newElementControl1 = new ElementControl(new Capacitor("C1", 3));
			redactorPanel[1, 2] = newElementControl1;
			var newElementControl2 = new ElementControl(new Inductor("I1", 4));
			redactorPanel[0, 2] = newElementControl2;
			var newElementControl3 = new ElementControl(new Inductor("I2", 5));
			redactorPanel[1, 1] = newElementControl3;
			var newElementControl4 = new ElementControl(new Resistor("R3", 6));
			redactorPanel[2, 1] = newElementControl4;

			var newElementControl5 = new ElementControl(DrawingElements.StartingElement);
			redactorPanel.AddControl(newElementControl5);

			var newElementControl6 = new ElementControl(DrawingElements.FiniteElement);
			redactorPanel.AddControl(newElementControl6);
		}

		/// <summary>
		///     Инициализация тестовых цепей
		/// </summary>
		private void InitializeCircuits()
		{
			_circuitList = new List<Circuit>();
			var circuitElements1 = new List<ElementBase>
			{
				new Capacitor("C1", 10),
				new Inductor("L1", 5),
				new Resistor("R1", 20)
			};

			var circuit1 = new Circuit(circuitElements1);
			_circuitList.Add(circuit1);

			var circuitElements2 = new List<ElementBase>
			{
				new Capacitor("C1", 10),
				new Capacitor("C2", 5),
				new Resistor("R1", 20),
				new Resistor("R2", 20),
				new Resistor("R3", 20),
				new Resistor("R4", 20)
			};

			var circuit2 = new Circuit(circuitElements2);
			_circuitList.Add(circuit2);

			var circuitElements3 = new List<ElementBase>
			{
				new Inductor("L1", 10),
				new Capacitor("C1", 5),
				new Resistor("R1", 20),
				new Inductor("L2", 20),
				new Resistor("R2", 20),
				new Capacitor("C2", 20)
			};

			var circuit3 = new Circuit(circuitElements3);
			_circuitList.Add(circuit3);

			var circuitElements4 = new List<ElementBase>
			{
				new Inductor("L1", 10)
			};

			var circuit4 = new Circuit(circuitElements4);
			_circuitList.Add(circuit4);

			var circuitElements5 = new List<ElementBase>
			{
				new Capacitor("C1", 10),
				new Capacitor("C2", 5),
				new Resistor("R1", 20),
				new Resistor("R2", 20),
				new Resistor("R3", 20),
				new Inductor("I1", 20)
			};

			var circuit5 = new Circuit(circuitElements5);
			_circuitList.Add(circuit5);

			foreach (var circuit in _circuitList)
			{
				circuitListComboBox.Items.Add("Тестовая цепь №" +
				                              (_circuitList.IndexOf(circuit) + 1));
			}
		}

		/// <summary>
		///     Выбор цепи
		/// </summary>
		private void CircuitListComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (elementGridView.RowCount != 0)
			{
				CleanTable();
			}

			_currentCircuit = _circuitList[circuitListComboBox.SelectedIndex];
			CurrentCircuit = _currentCircuit;

			CircuitChanged?.Invoke();
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

			foreach (var element in _currentCircuit.Elements)
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
			redactorPanel.AddControl(ControlFactory.CreateResistorControl(
				resistorNameTextBox.Text,
				Convert.ToDouble(resistorValueTextBox.Text)));
		}

		/// <summary>
		///     Добавление конденсатора на панель
		/// </summary>
		private void AddCapacitorButton_Click(object sender, EventArgs e)
		{
			redactorPanel.AddControl(ControlFactory.CreateCapacitorControl(
				capacitorNameTextBox.Text,
				Convert.ToDouble(capacitorValueTextBox.Text)));
		}

		/// <summary>
		///     Добавление катушки индуктивности на панель
		/// </summary>
		private void AddInductorButton_Click(object sender, EventArgs e)
		{
			redactorPanel.AddControl(ControlFactory.CreateInductorControl(
				inductorNameTextBox.Text,
				Convert.ToDouble(inductorValueTextBox.Text)));
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
			if (elementGridView.CurrentCell.ColumnIndex != 1)
			{
				return;
			}

			var formatingString = e.FormattedValue.ToString().Replace('.', ',');
			if (ValidatingClass.IsCellCorrect(e))
			{
				_currentCircuit.Elements[e.RowIndex].Value =
					Convert.ToDouble(formatingString);

				RefreshRedactor();
				CircuitValueChanged?.Invoke(
					Convert.ToDouble(formatingString),
					_currentCircuit.Elements[e.RowIndex]);
			}
			else
			{
				elementGridView.CancelEdit();

				MessageBox.Show(
					"Вы ввели: " + formatingString + "\n" +
					"Вводимое значение должно удовлетворять следующим условиям:\n " +
					"-быть положительным числом\n " +
					"-быть вещественным или натуральным числом\n " +
					"-быть большим 0.000 000 001 по модулю\n " +
					"-быть меньше 1 000 000 000 000\n " +
					"-запись не должна содержать пробелов\n " +
					"-запись должна начинаться с цифры\n " +
					"-использование экспоненциальной записи не допускается\n " +
					"-eсли первой цифрой числа являтся ноль, значит после него обязательно должна быть запятая.",
					"Ошибка ввода значения частоты", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		/// <summary>
		///     Закрытие формы редактора
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CircuitRedactorForm_FormClosing(object sender,
			FormClosingEventArgs e)
		{
			e.Cancel = true;
		}

		/// <summary>
		///     Обновить панель редактора
		/// </summary>
		private void RefreshRedactor()
		{
			redactorPanel.CleanPanel();

			redactorPanel.AddControl(ControlFactory.CreateStartingElementControl());

			foreach (var element in _currentCircuit.Elements)
			{
				if (element is Resistor)
				{
					redactorPanel.AddControl(
						ControlFactory.CreateResistorControl(element.Name,
							element.Value));
				}
				else if (element is Inductor)
				{
					redactorPanel.AddControl(
						ControlFactory.CreateInductorControl(element.Name,
							element.Value));
				}
				else if (element is Capacitor)
				{
					redactorPanel.AddControl(
						ControlFactory.CreateCapacitorControl(element.Name,
							element.Value));
				}
				else
				{
					throw new TypeLoadException(
						"Один из элементов цепи не поддерживается редактором.");
				}
			}

			redactorPanel.AddControl(ControlFactory.CreateFiniteElementControl());
		}

		#endregion – – Приватные методы – –
	}

	public delegate void ComboBoxStateHandler();
}