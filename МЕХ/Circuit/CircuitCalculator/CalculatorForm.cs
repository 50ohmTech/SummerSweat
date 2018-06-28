using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitElements;

namespace CircuitCalculator
{
	/// <summary>
	///     Форма в которой производятся расчеты
	/// </summary>
	public partial class CalculatorForm : Form
	{
		#region – – Публичные методы – – 

		/// <inheritdoc />
		/// <summary>
		///     Конструктор
		/// </summary>
		public CalculatorForm()
		{
			InitializeComponent();
			InitializeCircuits();
			_redactorForm = new CircuitRedactorForm();
			_redactorForm.Show();

			//Подписывается на событие изменения значения одного из элементов цепи
			_redactorForm.CircuitValueChanged += ElementChanged;
		}

		#endregion – – Публичные методы – –

		#region – – Поля – – 

		/// <summary>
		///     Редактор цепей, взаимодействующий с this формой
		/// </summary>
		private readonly CircuitRedactorForm _redactorForm;

		/// <summary>
		///     Список доступных цепей
		/// </summary>
		private List<Circuit> _circuitList;

		/// <summary>
		///     Выбранная цепь
		/// </summary>
		private Circuit _currentCircuit;

		/// <summary>
		///     Список частот, для которых производятся расчеты
		/// </summary>
		private double[] _frequencies;

		#endregion – – Поля – –

		#region – – Приватные методы – – 

		/// <summary>
		///     Инициализация тестовых цепей
		/// </summary>
		private void InitializeCircuits()
		{
			_circuitList = new List<Circuit>();
			var circuitElements1 = new List<Element>();

			circuitElements1.Add(new Capacitor("C1", 10));
			circuitElements1.Add(new Inductor("L1", 5));
			circuitElements1.Add(new Resistor("R1", 20));
			var circuit1 = new Circuit(circuitElements1);
			_circuitList.Add(circuit1);

			var circuitElements2 = new List<Element>();
			circuitElements2.Add(new Capacitor("C1", 10));
			circuitElements2.Add(new Capacitor("C2", 5));
			circuitElements2.Add(new Resistor("R1", 20));
			circuitElements2.Add(new Resistor("R2", 20));
			circuitElements2.Add(new Resistor("R3", 20));
			circuitElements2.Add(new Resistor("R4", 20));
			var circuit2 = new Circuit(circuitElements2);
			_circuitList.Add(circuit2);

			var circuitElements3 = new List<Element>();
			circuitElements3.Add(new Inductor("L1", 10));
			circuitElements3.Add(new Capacitor("C1", 5));
			circuitElements3.Add(new Resistor("R1", 20));
			circuitElements3.Add(new Inductor("L2", 20));
			circuitElements3.Add(new Resistor("R2", 20));
			circuitElements3.Add(new Capacitor("C2", 20));
			var circuit3 = new Circuit(circuitElements3);
			_circuitList.Add(circuit3);

			var circuitElements4 = new List<Element>();
			circuitElements4.Add(new Inductor("L1", 10));
			var circuit4 = new Circuit(circuitElements4);
			_circuitList.Add(circuit4);

			var circuitElements5 = new List<Element>();
			circuitElements5.Add(new Capacitor("C1", 10));
			circuitElements5.Add(new Capacitor("C2", 5));
			circuitElements5.Add(new Resistor("R1", 20));
			circuitElements5.Add(new Resistor("R2", 20));
			circuitElements5.Add(new Resistor("R3", 20));
			circuitElements5.Add(new Inductor("I1", 20));
			var circuit5 = new Circuit(circuitElements5);
			_circuitList.Add(circuit5);

			foreach (var circuit in _circuitList)
			{
				circuitListComboBox.Items.Add("Тестовая цепь №" +
				                              (_circuitList.IndexOf(circuit) + 1));
			}
		}

		/// <summary>
		///     Обработка события изменения значения элемента цепи
		/// </summary>
		/// <param name="newValue"> новое значение </param>
		/// <param name="changedElement"> измененный элемент </param>
		private void ElementChanged(object newValue, object changedElement)
		{
			foreach (var element in _currentCircuit.Elements)
			{
				if (element == changedElement)
				{
					element.Value = (double) newValue;
				}
			}
		}

		/// <summary>
		///     Валидация редактирования ячеек частот
		/// </summary>
		private void FrequenciesGridView_CellValidating(object sender,
			DataGridViewCellValidatingEventArgs e)
		{
			if (frequenciesGridView.CurrentCell.ColumnIndex == 0)
			{
				frequenciesGridView.Rows[e.RowIndex].ErrorText = "";

				if (frequenciesGridView.Rows[e.RowIndex].IsNewRow)
				{
					return;
				}

				if (double.TryParse(e.FormattedValue.ToString(),
					    out var newValue) && !(Math.Abs(newValue) < 0.000000001))
				{
					return;
				}

				e.Cancel = true;
				frequenciesGridView.Rows[e.RowIndex].ErrorText =
					"Значение должно быт положительным вещественным числом, большим 0.000000001 по модулю";
			}
		}

		/// <summary>
		///     Расчитать импедансы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalculateButton_Click(object sender, EventArgs e)
		{
			if (_currentCircuit == null)
			{
				MessageBox.Show("Выберите цепь", "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			else
			{
				_frequencies = new double[frequenciesGridView.RowCount - 1];

				for (var i = 0; i < frequenciesGridView.RowCount - 1; i++)
				{
					_frequencies[i] = Convert.ToDouble(frequenciesGridView[0, i].Value);
				}

				var impedance = _currentCircuit.CalculateZ(_frequencies);

				for (var i = 0; i < frequenciesGridView.RowCount - 1; i++)
				{
					frequenciesGridView[1, i].Value = impedance[i].Real +
					                                  (impedance[i].Imaginary < 0
						                                  ? " - "
						                                  : " + ") +
					                                  Math.Abs(impedance[i].Imaginary) +
					                                  " * i";
				}

				calculateButton.Text = "Пересчитать";
			}
		}

		/// <summary>
		///     Выбор цепи
		/// </summary>
		private void CircuitListComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_currentCircuit = _circuitList[circuitListComboBox.SelectedIndex];
			_redactorForm.DisplayingCircuit = _currentCircuit;

			calculateButton.Text = "Расчитать";
		}

		/// <summary>
		///     Сбросить значения таблицы
		/// </summary>
		private void ResetButton_Click(object sender, EventArgs e)
		{
			calculateButton.Text = "Расчитать";
			for (var i = 0; i < frequenciesGridView.RowCount - 1; i++)
			{
				frequenciesGridView.Rows.Clear();
			}
		}

		/// <summary>
		///     При закрытии формы, приложение закрывается
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalculatorForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		#endregion – – Приватные методы – –
	}
}