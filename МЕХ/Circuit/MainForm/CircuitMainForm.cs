using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircuitElements;
using CircuitElements.Circuits;
using CircuitElements.Elements;

namespace MainForm
{
	/// <summary>
	/// Главная форма программы на которой происходит редактирование цепи
	/// </summary>
    public partial class MainForm : Form
	{
		private List<CircuitBase> _circuits;

		private CircuitBase _currentCircuit;

		private readonly ImpedanceForm _impedanceForm;

		private void InitializeTreeView()
		{
			//treeView.BeginUpdate();
			//treeView.Nodes.Add("Parent");
			//treeView.Nodes[0].Nodes.Add("Child 1");
			//treeView.Nodes[0].Nodes.Add("Child 2");
			//treeView.Nodes[0].Nodes[0].Nodes.Add("Grandchild");
			//treeView.Nodes[0].Nodes[0].Nodes.Add("Grandchild");
			//treeView.Nodes[0].Nodes[0].Nodes.Add("Grandchild");
			//treeView.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("Great Grandchild");
			//treeView.EndUpdate();
		}

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
							treeView.Nodes[treeView.Nodes.Count-1].Nodes.Add("[Паралл] (id " + subcircuit.ElementId + ')');
							break;
						case SerialCircuit subcircuit:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes.Add("[Послед] (id " + subcircuit.ElementId + ')');
							break;
					}

					FillSubcircuitInTreeView(treeView.Nodes[0].Nodes, circuit);
				}
				else
				{
					switch (circuitElement)
					{
						case Resistor element:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes.Add("[R] [" + element.Value + "] (" + element.Name + ')');
							break;

						case Inductor element:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes.Add("[I] [" + element.Value + "] (" + element.Name + ')');
							break;

						case Capacitor element:
							treeView.Nodes[treeView.Nodes.Count - 1].Nodes.Add("[C] [" + element.Value + "] (" + element.Name + ')');
							break;
					}
				}

			}

			treeView.EndUpdate();
			treeView.ExpandAll();
		}
		//treeView.BeginUpdate();
		//treeView.Nodes.Add("Parent");
		//treeView.Nodes[0].Nodes.Add("Child 1");
		//treeView.Nodes[0].Nodes.Add("Child 2");
		//treeView.Nodes[0].Nodes[0].Nodes.Add("Grandchild");
		//treeView.Nodes[0].Nodes[0].Nodes.Add("Grandchild");
		//treeView.Nodes[0].Nodes[0].Nodes.Add("Grandchild");
		//treeView.Nodes[0].Nodes[0].Nodes[2].Nodes.Add("Great Grandchild");
		//treeView.EndUpdate();
		private void FillSubcircuitInTreeView(TreeNodeCollection newLevel, CircuitBase subcircuit)
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
					try
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
					catch (Exception e)
					{
						MessageBox.Show("error: " + e.Message);
					}
				}

			}
		}

		public MainForm()
        {
            InitializeComponent();
	        _impedanceForm = new ImpedanceForm();
			_impedanceForm.Show();
	        _impedanceForm.Visible = false;

	        InitializeTreeView();

			InitializeCircuits();
	        CircuitDraw.VerticalScroll.Enabled = true;
	        CircuitDraw.HorizontalScroll.Enabled = true;
		}

	    private void InitializeCircuits()
	    {
		    _circuits = new List<CircuitBase>();
			
			List<ICircuitElement> circuitElements1 = new List<ICircuitElement>
		    {
			    new Capacitor("C1", 10),
			    new Inductor("L1", 5),
			    new Resistor("R1", 20)
			};
			_circuits.Add(new SerialCircuit(circuitElements1));

		    List<ICircuitElement> circuitElements2 = new List<ICircuitElement>
		    {
				new ParallelCircuit(new List<ICircuitElement>
				{
					new Capacitor("C1", 10),
					new Inductor("L1", 5),
					new Resistor("R1", 20)
				})
			};
			_circuits.Add(new ParallelCircuit(circuitElements2));

		    List<ICircuitElement> circuitElements3 = new List<ICircuitElement>
		    {
			    new Capacitor("C4", 10),
				new ParallelCircuit(new List<ICircuitElement>
			    {
					new ParallelCircuit(new List<ICircuitElement>
				    {
					    new Capacitor("C2", 10),
						new Inductor("L3", 5),
				    }),
				    new Capacitor("C1", 10),
					new Resistor("R1", 20)
			    }),
			    new Inductor("L4", 5),
			    new Resistor("R2", 20)
			};
			_circuits.Add(new SerialCircuit(circuitElements3));

		    List<ICircuitElement> circuitElements4 = new List<ICircuitElement>
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

		    List<ICircuitElement> circuitElements5 = new List<ICircuitElement>
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

		    List<ICircuitElement> emptyCircuitElements = new List<ICircuitElement>();
			_circuits.Add(new SerialCircuit(emptyCircuitElements));

			SelectingCircuitComboBox.Items.Add("Пустая цепь");
		}

		private void SelectingCircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(SelectingCircuitComboBox.SelectedIndex!=6)
			{
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

		private void CalculateImpedanceButton_Click(object sender, EventArgs e)
		{
			_impedanceForm.Visible = !_impedanceForm.Visible;
		}

	}
}
