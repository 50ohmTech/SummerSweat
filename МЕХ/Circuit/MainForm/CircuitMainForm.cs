using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CircuitElements;
using CircuitElements.Circuits;
using CircuitElements.Elements;

namespace MainForm
{
	/// <summary>
	///     Главная форма программы на которой происходит редактирование цепи
	/// </summary>
	public partial class MainForm : Form
	{
		#region Constants

		/// <summary>
		///     Максимальная длинна имени элемента
		/// </summary>
		private const int _maxNameLength = 11;

		/// <summary>
		///     Максимальный номинал элемента
		/// </summary>
		private const long _maxFrecuency = 1000000000000;

		/// <summary>
		///     Минимальный номинал элемента
		/// </summary>
		private const int _minFrecuency = 1;

		#endregion

		#region Readonly fields

		/// <summary>
		///     Форма расчета импедансов
		/// </summary>
		private readonly ImpedanceForm _impedanceForm;

		/// <summary>
		///     Полотно для отрисовки цепей
		/// </summary>
		private readonly PictureBox _pictureBox;

		#endregion

		#region Private fields

		/// <summary>
		///     Выбранная цепь
		/// </summary>
		private CircuitBase _currentCircuit;

		#endregion

		#region Constructor

		/// <summary>
		///     Конструктор
		/// </summary>
		public MainForm()
		{
			InitializeComponent();
			_pictureBox = new PictureBox();
			_impedanceForm = new ImpedanceForm();
			_impedanceForm.Show();
			_impedanceForm.Visible = false;

			InitializeCircuits();
			SelectingCircuitComboBox.SelectedIndex = 0;
			NadeComboBox.SelectedIndex = 0;
		}

		#endregion

		#region Private methods

		/// <summary>
		///     Заполнить дерево текущей цепью
		/// </summary>
		private void FillTreeView()
		{
			treeView.Nodes.Clear();
			treeView.BeginUpdate();

			treeView.Nodes.Add("[Послед](id " + _currentCircuit.Id + " )");

			//Если соединение пустое, просто добавить его
			if (_currentCircuit.Elements == null || _currentCircuit.Elements.Count == 0)
			{
				switch (_currentCircuit)
				{
					case ParallelCircuit paralelCircuit:
						treeView.Nodes[0].Nodes
							.Add("[Паралл] (id " +
							     paralelCircuit.Id + ')');

						break;
					case SerialCircuit serialCircuit:
						treeView.Nodes[0].Nodes
							.Add("[Послед] (id " +
							     serialCircuit.Id + ')');

						break;
				}
			}
			else
			{
				foreach (var circuitElement in _currentCircuit.Elements)
				{
					if (circuitElement is CircuitBase circuit)
					{
						//Если соединение пустое, просто добавить его
						if (circuit.Elements == null || circuit.Elements.Count == 0)
						{
							switch (circuit)
							{
								case ParallelCircuit paralelCircuit:
									treeView.Nodes[0].Nodes
										.Add("[Паралл] (id " +
										     paralelCircuit.Id + ')');

									break;
								case SerialCircuit serialCircuit:
									treeView.Nodes[0].Nodes
										.Add("[Послед] (id " +
										     serialCircuit.Id + ')');

									break;
							}
						}
						else
						{
							switch (circuit)
							{
								case ParallelCircuit subcircuit:
									treeView.Nodes[0].Nodes
										.Add("[Паралл] (id " + subcircuit.Id + ')');

									break;
								case SerialCircuit subcircuit:
									treeView.Nodes[0].Nodes
										.Add("[Послед] (id " + subcircuit.Id + ')');

									break;
							}

							FillSubcircuitInTreeView(treeView.Nodes[0].Nodes, circuit);
						}
					}
					else
					{
						switch (circuitElement)
						{
							case Resistor element:
								treeView.Nodes[0].Nodes
									.Add("[R] [" + element.Value + "] (" + element.Name +
									     ')');

								break;

							case Inductor element:
								treeView.Nodes[0].Nodes
									.Add("[I] [" + element.Value + "] (" + element.Name +
									     ')');

								break;

							case Capacitor element:
								treeView.Nodes[0].Nodes
									.Add("[C] [" + element.Value + "] (" + element.Name +
									     ')');

								break;
						}
					}
				}
			}

			treeView.EndUpdate();
			treeView.ExpandAll();
		}

		/// <summary>
		///     Функция для обхода и добавления в TreeView подцепей
		/// </summary>
		/// <param name="newLevel">уровень добавляемой подцепи</param>
		/// <param name="subcircuit">подцепь</param>
		private void FillSubcircuitInTreeView(TreeNodeCollection newLevel,
			CircuitBase subcircuit)
		{
			//Если соединение пустое, просто добавить его
			if (subcircuit.Elements == null)
			{
				switch (subcircuit)
				{
					case ParallelCircuit paralelCircuit:
						newLevel[newLevel.Count - 1].Nodes
							.Add("[Паралл] (id " +
							     paralelCircuit.Id + ')');

						break;
					case SerialCircuit serialCircuit:
						newLevel[newLevel.Count - 1].Nodes
							.Add("[Послед] (id " +
							     serialCircuit.Id + ')');

						break;
				}
			}

			//Добавление вместе с элементами
			else
			{
				foreach (var circuitElement in subcircuit.Elements)
				{
					//Добавление подцепи в дерево
					if (circuitElement is CircuitBase circuit)
					{
						//Если соединение пустое, просто добавить его
						if (circuit.Elements == null || circuit.Elements.Count == 0)
						{
							switch (circuit)
							{
								case ParallelCircuit paralelCircuit:
									newLevel[newLevel.Count - 1].Nodes
										.Add("[Паралл] (id " +
										     paralelCircuit.Id + ')');

									break;
								case SerialCircuit serialCircuit:
									newLevel[newLevel.Count - 1].Nodes
										.Add("[Послед] (id " +
										     serialCircuit.Id + ')');

									break;
							}
						}
						else
						{
							switch (circuit)
							{
								case ParallelCircuit paralelCircuit:
									newLevel[newLevel.Count - 1].Nodes
										.Add("[Паралл] (id " +
										     paralelCircuit.Id + ')');

									break;
								case SerialCircuit serialCircuit:
									newLevel[newLevel.Count - 1].Nodes
										.Add("[Послед] (id " +
										     serialCircuit.Id + ')');

									break;
							}


							FillSubcircuitInTreeView(newLevel[newLevel.Count - 1].Nodes,
								circuit);
						}
					}

					//Добавление элемента в дерево
					else
					{
						switch (circuitElement)
						{
							case Resistor element:
								newLevel[newLevel.Count - 1].Nodes
									.Add("[R] [" + element.Value + "] (" + element.Name +
									     ')');

								break;

							case Inductor element:
								newLevel[newLevel.Count - 1].Nodes
									.Add("[I] [" + element.Value + "] (" + element.Name +
									     ')');

								break;

							case Capacitor element:
								newLevel[newLevel.Count - 1].Nodes
									.Add("[C] [" + element.Value + "] (" + element.Name +
									     ')');

								break;
						}
					}
				}
			}
		}

		/// <summary>
		///     Инициализация ComboBox'a
		/// </summary>
		private void InitializeCircuits()
		{
			for (var i = 0; i < 5; i++)
			{
				SelectingCircuitComboBox.Items.Add("Тестовая цепь №" + (i + 1));
			}

			SelectingCircuitComboBox.Items.Add("Пустая цепь");
		}

		/// <summary>
		///     Смена выбранной цепи в комбобоксе
		/// </summary>
		private void SelectingCircuitComboBox_SelectedIndexChanged(object sender,
			EventArgs e)
		{
			if (SelectingCircuitComboBox.SelectedIndex != 6)
			{
				_currentCircuit =
					TestCircuitsGenerator.GenerateCircuit(SelectingCircuitComboBox
						                                      .SelectedIndex + 1);

				DrawCircuit();

				FillTreeView();
			}
			else
			{
				circuitDrawLayoutPanel.BackgroundImage = null;
			}
		}

		/// <summary>
		///     Нарисовать цепь
		/// </summary>
		private void DrawCircuit()
		{
			_pictureBox.Image = Drawer.DrawCircuit(_currentCircuit);
			_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

			circuitDrawLayoutPanel.AutoScroll = true;
			circuitDrawLayoutPanel.Controls.Add(_pictureBox);
		}

		/// <summary>
		///     Нажатие на кнопку расчета импедансов
		/// </summary>
		private void CalculateImpedanceButton_Click(object sender, EventArgs e)
		{
			if (CalculateImpedanceButton.Text == "Нарисовать цепь")
			{
				if (IsDrawable())
				{
					DrawCircuit();
					CalculateImpedanceButton.Text = "Расчитать импеданс";
				}
			}
			else
			{
				_impedanceForm.Circuit = _currentCircuit;
				_impedanceForm.Visible = !_impedanceForm.Visible;
				_impedanceForm.Circuit = _currentCircuit;
			}
		}

		/// <summary>
		///     Очистка текста текстбокса перед редактированием
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _textBoxAddElementName_Enter(object sender, EventArgs e)
		{
			_textBoxAddElementName.Text = null;
			_textBoxAddElementName.ForeColor = Color.Black;
		}

		/// <summary>
		///     Очистка текста текстбокса перед редактированием
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _textBoxAddElementValue_Enter(object sender, EventArgs e)
		{
			_textBoxAddElementValue.Text = null;
			_textBoxAddElementValue.ForeColor = Color.Black;
		}

		/// <summary>
		///     Валидация ввода в текстбоксы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void _textBox_TextChanged(object sender, EventArgs e)
		{
			errorProvider.Clear();

			if (string.IsNullOrWhiteSpace(_textBoxAddElementName.Text) ||
			    _textBoxAddElementName.Text.Contains(" "))
			{
				AddButton.Enabled = false;
				ModufyButton.Enabled = false;
				errorProvider.SetError(_textBoxAddElementName,
					"Имя элемента не может быть пустым или содержать пробелы");

				return;
			}

			if (_textBoxAddElementName.Text.Length > _maxNameLength)
			{
				ModufyButton.Enabled = false;
				AddButton.Enabled = false;
				errorProvider.SetError(_textBoxAddElementName,
					"Масимально допустимая длинна имени - 11 символов");

				return;
			}

			if (_textBoxAddElementValue.Text.Contains(" "))
			{
				ModufyButton.Enabled = false;
				AddButton.Enabled = false;
				errorProvider.SetError(_textBoxAddElementName,
					"Вводимое значение элемена не должно содержать пробелов");

				return;
			}

			if (!double.TryParse(_textBoxAddElementValue.Text, out var value))
			{
				ModufyButton.Enabled = false;
				AddButton.Enabled = false;
				errorProvider.SetError(_textBoxAddElementValue,
					"Введенное значение невозможно преобразовать в число");

				return;
			}

			if (value < _minFrecuency || value > _maxFrecuency)
			{
				ModufyButton.Enabled = false;
				AddButton.Enabled = false;
				errorProvider.SetError(_textBoxAddElementValue,
					"Частота может принимать значение только от 1 Гц. до 1 ТГц");

				return;
			}

			errorProvider.Clear();
			AddButton.Enabled = true;
			ModufyButton.Enabled = true;
		}

		/// <summary>
		///     Обработчик нажатий на кнопку "добавить"
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AddButton_Click(object sender, EventArgs e)
		{
			if (treeView.SelectedNode == null)
			{
				MessageBox.Show(
					"Выберите соединение, в которое хотите добавить элемент ");

				return;
			}

			if (!treeView.SelectedNode.Text.Contains("id"))
			{
				MessageBox.Show("Узел не может быть элементом");
				return;
			}

			var costumasingCircuit =
				_currentCircuit.GetCircuitById(GetCircuitId(treeView.SelectedNode));

			if (costumasingCircuit == null)
			{
				MessageBox.Show("Ошибка поиска цепи");
				return;
			}

			switch (NadeComboBox.SelectedIndex)
			{
				//резистор
				case 0:
					costumasingCircuit.Elements.Add(new Resistor(
						_textBoxAddElementName.Text,
						Convert.ToDouble(_textBoxAddElementValue.Text)));

					break;

				//катушка
				case 1:
					costumasingCircuit.Elements.Add(new Inductor(
						_textBoxAddElementName.Text,
						Convert.ToDouble(_textBoxAddElementValue.Text)));

					break;

				//конденсатор
				case 2:
					costumasingCircuit.Elements.Add(new Capacitor(
						_textBoxAddElementName.Text,
						Convert.ToDouble(_textBoxAddElementValue.Text)));

					break;

				//параллельное соединение
				case 3:
					costumasingCircuit.Elements.Add(new ParallelCircuit());
					break;

				//последовательное cоединение
				case 4:
					costumasingCircuit.Elements.Add(new SerialCircuit());
					break;
			}

			CalculateImpedanceButton.Text = "Нарисовать цепь";
			FillTreeView();

			if (_impedanceForm.Visible)
			{
				_impedanceForm.Circuit = _currentCircuit;
			}
		}

		/// <summary>
		///     Получить ID цепи из дерева
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		private int GetCircuitId(TreeNode node)
		{
			var number = "";
			foreach (var symbol in node.Text)
			{
				if (char.IsDigit(symbol))
				{
					number += symbol;
				}
			}

			return Convert.ToInt16(number);
		}

		/// <summary>
		///     Рекурсивная проверка на то можно ли нарисовать цепь
		/// </summary>
		/// <returns></returns>
		private bool IsDrawable()
		{
			if (_currentCircuit.Elements == null)
			{
				MessageBox.Show("Ошибка отрисовки! Соединение с id " +
				                _currentCircuit.Id +
				                " должно хранить в себе минимум два элемента");

				return false;
			}

			if (_currentCircuit.Elements.Count >= 2)
			{
				foreach (var element in _currentCircuit.Elements)
				{
					if (element is CircuitBase circuitBase)
					{
						return IsDrawable(circuitBase);
					}
				}
			}
			else
			{
				MessageBox.Show("Ошибка отрисовки! Соединение с id " +
				                _currentCircuit.Id +
				                " должно хранить в себе минимум два элемента");

				return false;
			}

			return true;
		}

		/// <summary>
		///     Рекурсивная проверка на то можно ли нарисовать цепь
		/// </summary>
		/// <param name="circuit"></param>
		/// <returns></returns>
		private bool IsDrawable(CircuitBase circuit)
		{
			if (circuit.Elements == null)
			{
				MessageBox.Show("Ошибка отрисовки! Соединение с id " +
				                _currentCircuit.Id +
				                " должно хранить в себе минимум два элемента");

				return false;
			}

			if (circuit.Elements.Count >= 2)
			{
				foreach (var element in circuit.Elements)
				{
					if (element is CircuitBase circuitBase)
					{
						return IsDrawable(circuitBase);
					}
				}
			}
			else
			{
				MessageBox.Show("Ошибка отрисовки! Соединение с id " +
				                circuit.Id +
				                " должно хранить в себе минимум два элемента");

				return false;
			}

			return true;
		}

		/// <summary>
		///     Обработчик комбобокса отвечающего за выбор элемента
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			_textBoxAddElementName.Text = "Имя";
			_textBoxAddElementValue.Text = "Номинал";
			if (NadeComboBox.SelectedIndex > 2)
			{
				AddButton.Enabled = true;
				_textBoxAddElementName.Enabled = false;
				_textBoxAddElementValue.Enabled = false;
			}
			else
			{
				AddButton.Enabled = false;
				_textBoxAddElementName.Enabled = true;
				_textBoxAddElementValue.Enabled = true;
			}
		}

		/// <summary>
		///     Удаление элемента цепи
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DeleteButton_Click(object sender, EventArgs e)
		{
			if (treeView.SelectedNode == null)
			{
				MessageBox.Show(
					"Выберите соединение или элемент, который хотите удалить ");

				return;
			}

			var costumasingCircuit =
				_currentCircuit.GetCircuitById(
					GetCircuitId(treeView.SelectedNode.Parent));

			if (costumasingCircuit == null)
			{
				_currentCircuit.Elements = new List<ICircuitElement>();
				return;
			}

			if (treeView.SelectedNode.Text.Contains("id"))
			{
				_currentCircuit.RemoveElement(GetCircuitId(treeView.SelectedNode));
				CalculateImpedanceButton.Text = "Нарисовать цепь";
				FillTreeView();
				return;
			}

			costumasingCircuit.RemoveElement(GetElementFromTreeView(treeView.SelectedNode)
				.Name);

			CalculateImpedanceButton.Text = "Нарисовать цепь";
			FillTreeView();

			if (_impedanceForm.Visible)
			{
				_impedanceForm.Circuit = _currentCircuit;
			}
		}

		/// <summary>
		///     Создание элемента по параметрам указанным в ноде TreeView
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		private ElementBase GetElementFromTreeView(TreeNode node)
		{
			//1-тип элемента 4-номинал 7-имя
			var delimiter = " []()".ToCharArray();
			var split = node.Text.Split(delimiter);

			switch (split[1])
			{
				case "C":
					return new Capacitor(split[7], Convert.ToInt64(split[4]));
				case "R":
					return new Resistor(split[7], Convert.ToInt64(split[4]));
				default:
					return new Inductor(split[7], Convert.ToInt64(split[4]));
			}
		}

		/// <summary>
		///     Редактирование элемента цепи
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModufyButton_Click(object sender, EventArgs e)
		{
			if (_textBoxAddElementName.Text == "Имя" ||
			    _textBoxAddElementValue.Text == "Номинал")
			{
				MessageBox.Show("Выберите элемент для редактирования");
			}


			if (_impedanceForm.Visible)
			{
				_impedanceForm.Circuit = _currentCircuit;
			}
		}

		/// <summary>
		///     Обработчик выбора нноды treeView
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (!treeView.SelectedNode.Text.Contains("id"))
			{
				_textBoxAddElementName.Enabled = true;
				_textBoxAddElementValue.Enabled = true;

				var selectedElement = GetElementFromTreeView(treeView.SelectedNode);
				_textBoxAddElementName.Text = selectedElement.Name;
				_textBoxAddElementValue.Text =
					selectedElement.Value.ToString(CultureInfo.InvariantCulture);
			}
		}

		#endregion
	}
}