using System;
using System.Windows.Forms;
using CircuitCalculator.Validation;
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

			_redactorForm = new CircuitEditorForm();
			_redactorForm.Show();
			_redactorForm.Visible = false;
			_redactorForm.FormClosing += IsRedactorVisible_Click;

			var calculateToolTip = new ToolTip();
			calculateToolTip.SetToolTip(calculateButton,
				"Расчитать импаденсы для введенных частот");

			var resetToolTipt = new ToolTip();
			resetToolTipt.SetToolTip(resetButton,
				"Удаляет из таблицы все введенные частоты");

			var isRedactorVisibleToolTip = new ToolTip();
			isRedactorVisibleToolTip.SetToolTip(isRedactorVisibleButton,
				"Скрывает/Показывает окно редактирования цепи");

			//Подписывается на событие изменения значения одного из элементов цепи
			_redactorForm.CircuitValueChanged += ElementChanged;

			_redactorForm.CircuitChanged += CalculateButton_CircuitChanged;
		}

		#endregion – – Публичные методы – –

		#region – – Поля – – 

		/// <summary>
		///     Редактор цепей, взаимодействующий с this формой
		/// </summary>
		private readonly CircuitEditorForm _redactorForm;

		/// <summary>
		///     Список частот, для которых производятся расчеты
		/// </summary>
		private double[] _frequencies;

		#endregion – – Поля – –

		#region – – Приватные методы – – 

		private void CalculateButton_CircuitChanged()
		{
			calculateButton.Text = "Расчитать";
		}

		/// <summary>
		///     Обработка события изменения значения элемента цепи
		/// </summary>
		/// <param name="newValue"> новое значение </param>
		/// <param name="changedElement"> измененный элемент </param>
		private void ElementChanged(double newValue, ElementBase changedElement)
		{
			foreach (var element in _redactorForm.CurrentCircuit.Elements)
			{
				if (element == changedElement)
				{
					element.Value = newValue;
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
				if (frequenciesGridView.Rows[e.RowIndex].IsNewRow)
				{
					return;
				}

				var formatingString = e.FormattedValue.ToString().Replace('.', ',');
				if (!ValidatingClass.IsCellCorrect(e))
				{
					frequenciesGridView.CancelEdit();

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
		}

		/// <summary>
		///     Расчитать импедансы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalculateButton_Click(object sender, EventArgs e)
		{
			if (_redactorForm.CurrentCircuit == null)
			{
				MessageBox.Show("Выберите цепь", "Ошибка", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			else if (frequenciesGridView.Rows.Count != 1)
			{
				_frequencies = new double[frequenciesGridView.RowCount - 1];

				for (var i = 0; i < frequenciesGridView.RowCount - 1; i++)
				{
					_frequencies[i] = Convert.ToDouble(frequenciesGridView[0, i].Value
						.ToString().Replace('.', ','));
				}

				var impedance = _redactorForm.CurrentCircuit.CalculateZ(_frequencies);

				for (var i = 0; i < frequenciesGridView.RowCount - 1; i++)
				{
					frequenciesGridView[1, i].Value = impedance[i].Real +
					                                  (impedance[i].Imaginary < 0
						                                  ? " - "
						                                  : " + ") +
					                                  Math.Abs(impedance[i]
						                                  .Imaginary) +
					                                  " * i";
				}

				calculateButton.Text = "Пересчитать";
			}
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

		/// <summary>
		///     Скрывает/открывает редактор цепи
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void IsRedactorVisible_Click(object sender, EventArgs e)
		{
			_redactorForm.Visible = !_redactorForm.Visible;
			isRedactorVisibleButton.Text = _redactorForm.Visible
				? "Скрыть редактор цепи"
				: "Показать редактор цепи";
		}

		#endregion – – Приватные методы – –
	}
}