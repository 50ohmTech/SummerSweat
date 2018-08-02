using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CircuitLibrary;

namespace CircuitUI
{
    /// <summary>
    /// Electrical circuit control
    /// </summary>
    public partial class MainForm : Form
    {
        #region -- Private Fields --

        /// <summary>
        /// List of all electrical circuits
        /// </summary>
        private List<Circuit> _circuits;

        /// <summary>
        /// Selected circuit
        /// </summary>
        private Circuit _currentCircuit;
        /// <summary>
        /// Field for storing values of the electrical circuit element
        /// </summary>
        private TextBox _newValueElement;

        /// <summary>
        /// Field for storing the initial value of the electric circuit element
        /// </summary>
        private double _oldValueElement;

        /// <summary>
        /// The minimum value that the cell takes
        /// </summary>
        private const double _minValue = 0.0000001;

        /// <summary>
        /// The Maximum value that the cell takes
        /// </summary>
        private const double _maxValue = 100000000000000;

        #endregion -- Private Fields --        

        #region -- Public Methods --

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();           
        }

        #endregion -- Public Methods --

        #region -- Private Methods --

        /// <summary>
        /// Triggered when this form is run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeCircuits();
            MainFormInitialize();
        }

        /// <summary>
        /// Initialization of all electrical circuits
        /// </summary>
        private void InitializeCircuits()
        {
            _circuits = new List<Circuit>();

            var itsCircuit = new Circuit(new List<IElement>());
            _circuits.Add(itsCircuit);
            circuitsComboBox.Items.Add("Your electrical circuit");

            var firstCircuit = new Circuit(new List<IElement>
            {
                new Indutor("I1", 0.000001),
                new Indutor("I2", 0.1),
                new Capacitor("C1", 10),
                new Resistor("R1", 5),
                new Resistor("R2", 20.97),
                new Resistor("R3", 13.12)
            });
            _circuits.Add(firstCircuit);

            var secondCircuit = new Circuit(new List<IElement>
            {
                new Resistor("R1", 0.000123),
                new Resistor("R2", 0.103),
                new Indutor("I1", 20),
                new Resistor("R3", 10.3),
                new Indutor("I2", 20),
                new Capacitor("C1", 15),
                new Capacitor("C2", 5.23)
            });
            _circuits.Add(secondCircuit);

            var thirdCircuit = new Circuit(new List<IElement>
            {
                new Capacitor("C1", 5),
                new Resistor("R1", 10),
                new Indutor("I1", 15)
            });
            _circuits.Add(thirdCircuit);

            var fourCircuit = new Circuit(new List<IElement>
            {
                new Indutor("I1", 0.333),
                new Indutor("I2", 0.123),
                new Resistor("R1", 52.333),
                new Capacitor("C1", 10),
                new Resistor("R2", 32.12)
            });
            _circuits.Add(fourCircuit);

            var fifthCircuit = new Circuit(new List<IElement>
            {
                new Resistor("R1", 9.25)
            });
            _circuits.Add(fifthCircuit);

            for (int i = 1; i < _circuits.Count; i++)
            {
                circuitsComboBox.Items.Add("Test electric circuit № " + i);
            }
        }

        /// <summary>
        /// Initial setting MainForm
        /// </summary>
        private void MainFormInitialize()
        {
            #if !DEBUG
            randomElementButton.Visible = false;
            elementsGridView.Size = new Size(elementsGridView.Size.Width,
                elementsGridView.Size.Height + 20);
            #endif            
            circuitsComboBox.SelectedIndex = 0;

            elementsGridView.DataSource = bindingSourceContainer;            
            elementsGridView.Columns[0].ReadOnly = true;
            elementsGridView.Columns[1].ReadOnly = false;

            elementsGridView.Columns[0].ToolTipText = @"Element name";
            elementsGridView.Columns[1].ToolTipText =
                @"Nominal value of the electrical circuit element";
        }

        /// <summary>
        /// Occurs when the selection of a desired electrical circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCircuit = _circuits[circuitsComboBox.SelectedIndex];
            bindingSourceContainer.DataSource = _currentCircuit.Elements;
        }

        /// <summary>
        /// Adding a random element of an electrical circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandomElementButton_Click(object sender, EventArgs e)
        {
            RandomElement randomElementCircuit = new RandomElement();
            bindingSourceContainer.Add(randomElementCircuit.CreateRandomElement());
        }

        /// <summary>
        /// Adding the element of an electric circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addElementForm = new ControlCircuitForm();
            addElementForm.ShowDialog();
            if (addElementForm.DialogResult == DialogResult.OK)
            {
                var newElement = addElementForm.Element;
                bindingSourceContainer.Add(newElement);
            }
        }

        /// <summary>
        /// Call of the form of calculation of the total complex resistance of an electric circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentCircuit.Elements.Any())
            {
                var calculationForm = new CalculationForm();
                calculationForm.SetCircuit = _currentCircuit;
                calculationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Delete the selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (elementsGridView.CurrentRow != null)
            {
                int rowToDelete = elementsGridView.CurrentRow.Index;

                if (rowToDelete > -1)
                {
                    bindingSourceContainer.RemoveAt(rowToDelete);
                }
            }
        }

        /// <summary>
        /// Remove all values of this electrical circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSourceContainer.Clear();
        }

        /// <summary>
        /// Fires when the cursor is over the nominal value of the electrical circuit element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElementsGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                elementsGridView[e.ColumnIndex, e.RowIndex].ToolTipText =
                    ToolTipText.MessageForRows;
            }
        }

        /// <summary>
        /// Triggered when the edit mode is started for the selected cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElementsGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _newValueElement = new TextBox();
            _oldValueElement = Convert.ToDouble(elementsGridView.CurrentCell.Value);
        }

        /// <summary>
        /// Event triggered when validating a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElementsGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                double.TryParse(e.FormattedValue.ToString(), out double number);
                if (number < _minValue || number > _maxValue)
                {
                    _newValueElement.Text = Convert.ToString(_oldValueElement);
                }
            }
        }

        /// <summary>
        /// Event when changing the value of the electrical circuit element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ElementsGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _newValueElement = (TextBox)e.Control;
            _newValueElement.KeyPress += new KeyPressEventHandler(ValueElement_KeyPress);
        }

        /// <summary>
        /// Event to checking the key pressed in a cell 'Value'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !EditTextBoxValue.IsCorrectionTextBoxValue_Edit(_newValueElement.Text, e.KeyChar);
        }

        #endregion -- Private Methods --
    }
}

