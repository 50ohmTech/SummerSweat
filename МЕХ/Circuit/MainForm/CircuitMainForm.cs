using System;
using System.Collections.Generic;
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
		#region Readonly fields

		/// <summary>
		///     Форма расчета импедансов
		/// </summary>
		private readonly ImpedanceForm _impedanceForm;

		#endregion

		#region Private fields

		/// <summary>
		///     Список начальных цепей
		/// </summary>
		private List<CircuitBase> _circuits;

		/// <summary>
		///     Выбранная цепь
		/// </summary>
		private CircuitBase _currentCircuit;

		#endregion

		#region Constructor

		public MainForm()
		{
			InitializeComponent();

			_impedanceForm = new ImpedanceForm();
			_impedanceForm.Show();
			_impedanceForm.Visible = false;

			InitializeCircuits();
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

			treeView.Nodes.Add("Цепь");

			foreach (var circuitElement in _currentCircuit.Elements)
			{
				if (circuitElement is CircuitBase circuit)
				{
					switch (circuit)
					{
						case ParallelCircuit subcircuit:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes
								.Add("[Паралл] (id " + subcircuit.ElementId + ')');

							break;
						case SerialCircuit subcircuit:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes
								.Add("[Послед] (id " + subcircuit.ElementId + ')');

							break;
					}

					FillSubcircuitInTreeView(treeView.Nodes[0].Nodes, circuit);
				}
				else
				{
					switch (circuitElement)
					{
						case Resistor element:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes
								.Add("[R] [" + element.Value + "] (" + element.Name +
								     ')');

							break;

						case Inductor element:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes
								.Add("[I] [" + element.Value + "] (" + element.Name +
								     ')');

							break;

						case Capacitor element:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes
								.Add("[C] [" + element.Value + "] (" + element.Name +
								     ')');

							break;
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
			foreach (var circuitElement in subcircuit.Elements)
			{
				if (circuitElement is CircuitBase circuit)
				{
					switch (circuit)
					{
						case ParallelCircuit paralelCircuit:
							newLevel[newLevel.Count - 1].Nodes
								.Add("[Паралл] (id " +
								     paralelCircuit.ElementId + ')');

							break;
						case SerialCircuit serialCircuit:
							newLevel[newLevel.Count - 1].Nodes
								.Add("[Послед] (id " +
								     serialCircuit.ElementId + ')');

							break;
					}

					FillSubcircuitInTreeView(newLevel[newLevel.Count - 1].Nodes, circuit);
				}
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

        //TODO: генерацию тестовых цепей в отдельный класс - это не задача главной формы, это отладочная вспомогательная задача
        /// <summary>
        ///     Инициализация цепей
        /// </summary>
        private void InitializeCircuits()
		{
			_circuits = new List<CircuitBase>();

			var circuitElements1 = new List<ICircuitElement>
			{
				new Capacitor("C1", 10),
				new Inductor("L1", 5),
				new Resistor("R1", 20)
			};

			_circuits.Add(new SerialCircuit(circuitElements1));

			var circuitElements2 = new List<ICircuitElement>
			{
				new ParallelCircuit(new List<ICircuitElement>
				{
					new Capacitor("C1", 10),
					new Inductor("L1", 5),
					new Resistor("R1", 20)
				})
			};

			_circuits.Add(new ParallelCircuit(circuitElements2));

			var circuitElements3 = new List<ICircuitElement>
			{
				new Capacitor("C4", 10),
				new ParallelCircuit(new List<ICircuitElement>
				{
					new ParallelCircuit(new List<ICircuitElement>
					{
						new Capacitor("C2", 10),
						new Inductor("L3", 5)
					}),
					new Capacitor("C1", 10),
					new Resistor("R1", 20)
				}),
				new Inductor("L4", 5),
				new Resistor("R2", 20)
			};

			_circuits.Add(new SerialCircuit(circuitElements3));

			var circuitElements4 = new List<ICircuitElement>
			{
				new Capacitor("C2", 10),
				new Inductor("L2", 5),
				new ParallelCircuit(new List<ICircuitElement>
				{
					new Capacitor("C3", 10),
					new Inductor("L3", 5)
				}),
				new Resistor("R2", 20)
			};

			_circuits.Add(new SerialCircuit(circuitElements4));

			var circuitElements5 = new List<ICircuitElement>
			{
				new ParallelCircuit(new List<ICircuitElement>
				{
					new Capacitor("C1", 10),
					new Inductor("L1", 5),
					new ParallelCircuit(new List<ICircuitElement>
					{
						new Inductor("L3", 5),

						new SerialCircuit(new List<ICircuitElement>
						{
							new Capacitor("C2", 10),
							new Inductor("L2", 5)
						})
					}),
					new Resistor("R1", 20)
				}),
				new Capacitor("C4", 10),
				new Inductor("L4", 5),
				new Resistor("R2", 20)
			};

			_circuits.Add(new SerialCircuit(circuitElements5));
			foreach (var circuit in _circuits)
			{
				SelectingCircuitComboBox.Items.Add("Тестовая цепь №" +
				                                   (_circuits.IndexOf(circuit) + 1));
			}

			var emptyCircuitElements = new List<ICircuitElement>();
			_circuits.Add(new SerialCircuit(emptyCircuitElements));

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
                //TODO: PictureBox было бы логичнее использовать
                CircuitDraw.BackgroundImage =
					Drawer.DrawCircuit(_circuits[SelectingCircuitComboBox.SelectedIndex]);

				_currentCircuit = _circuits[SelectingCircuitComboBox.SelectedIndex];
				FillTreeView();
			}
			else
			{
				CircuitDraw.BackgroundImage = null;
			}
		}

		/// <summary>
		///     Нажатие на кнопку расчета импедансов
		/// </summary>
		private void CalculateImpedanceButton_Click(object sender, EventArgs e)
		{
			_impedanceForm.Visible = !_impedanceForm.Visible;
		}

		#endregion
	}
}