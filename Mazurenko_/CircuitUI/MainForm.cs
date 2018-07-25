using System;
using System.Collections.Generic;
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
        #region Constructor

        /// <summary>
        /// Empty constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            InitializeCircuits();
            DefaultSettingMainForm();
        }

        #endregion Constructor

        #region Fields

        /// <summary>
        /// List of all electrical circuits
        /// </summary>
        private List<Circuit> _circuitsAll;

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

        #endregion Fields        

        #region Methods
        /// <summary>
        /// Initialization of all electrical circuits
        /// </summary>
        private void InitializeCircuits()
        {
            _circuitsAll = new List<Circuit>();

            var itsCircuit = new Circuit(new List<IElement>());
            _circuitsAll.Add(itsCircuit);
            comboBoxCircuitsAll.Items.Add("Your electrical circuit");

            var firstCircuit = new Circuit(new List<IElement>());
            firstCircuit.Elements.Add(new Indutor("I1", 0.000001));
            firstCircuit.Elements.Add(new Indutor("I2", 0.1));
            firstCircuit.Elements.Add(new Capacitor("C1", 10));
            firstCircuit.Elements.Add(new Resistor("R1", 5));
            firstCircuit.Elements.Add(new Resistor("R2", 20.97));
            firstCircuit.Elements.Add(new Resistor("R3", 13.12));
            _circuitsAll.Add(firstCircuit);

            var secondCircuit = new Circuit(new List<IElement>());
            secondCircuit.Elements.Add(new Resistor("R1", 0.000123));
            secondCircuit.Elements.Add(new Resistor("R2", 0.103));
            secondCircuit.Elements.Add(new Indutor("I1", 20));
            secondCircuit.Elements.Add(new Resistor("R3", 10.3));
            secondCircuit.Elements.Add(new Indutor("I2", 20));
            secondCircuit.Elements.Add(new Capacitor("C1", 15));
            secondCircuit.Elements.Add(new Capacitor("C2", 15));
            _circuitsAll.Add(secondCircuit);

            var thirdCircuit = new Circuit(new List<IElement>());
            thirdCircuit.Elements.Add(new Capacitor("C1", 5));
            thirdCircuit.Elements.Add(new Resistor("R1", 10));
            thirdCircuit.Elements.Add(new Indutor("I1", 15));
            _circuitsAll.Add(thirdCircuit);

            var fourCircuit = new Circuit(new List<IElement>());
            fourCircuit.Elements.Add(new Indutor("I1", 0.333));
            fourCircuit.Elements.Add(new Indutor("I2", 0.123));
            fourCircuit.Elements.Add(new Resistor("R1", 52.333));
            fourCircuit.Elements.Add(new Capacitor("C1", 10));
            fourCircuit.Elements.Add(new Resistor("R2", 32.12));
            _circuitsAll.Add(fourCircuit);

            var fifthCircuit = new Circuit(new List<IElement>());
            fifthCircuit.Elements.Add(new Resistor("R1", 9.25));
            _circuitsAll.Add(fifthCircuit);

            for (int i = 1; i < _circuitsAll.Count; i++)
            {
                comboBoxCircuitsAll.Items.Add("Test electric circuit № " + i);
            }
        }

        /// <summary>
        /// Initial setting MainForm
        /// </summary>
        private void DefaultSettingMainForm()
        {
            #if !DEBUG
            buttonRandomElement.Visible = false;
            dataGridViewValueDisplay.Size = new Size(dataGridViewValueDisplay.Size.Width,
                dataGridViewValueDisplay.Size.Height + 20);
            #endif
            comboBoxCircuitsAll.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCircuitsAll.SelectedIndex = 0;

            dataGridViewValueDisplay.DataSource = bindingSourceContainer;
            dataGridViewValueDisplay.RowHeadersVisible = false;
            dataGridViewValueDisplay.MultiSelect = false;
            dataGridViewValueDisplay.Columns[0].ReadOnly = true;
            dataGridViewValueDisplay.Columns[1].ReadOnly = false;

            mainMenuStrip.ShowItemToolTips = true;
            addElementToolStripMenuItem.ToolTipText =
                @"Adding a new electrical circuit element";
            clearToolStripMenuItem.ToolTipText = @"To choose how to delete rows";
            deleteToolStripMenuItem.ToolTipText = @"Delete the selected row";
            deleteAllToolStripMenuItem.ToolTipText =
                @"Remove all values of this electrical circuit";
            calculationToolStripMenuItem.ToolTipText =
                @"To open the window to calculate the total complex \nresistance of the selected electrical circuit";

            dataGridViewValueDisplay.ShowCellToolTips = true;
            dataGridViewValueDisplay.Columns[0].ToolTipText = @"Element name";
            dataGridViewValueDisplay.Columns[1].ToolTipText =
                @"Nominal value of the electrical circuit element";
        }

        #endregion Methods

        #region ComboBox

        /// <summary>
        /// Occurs when the selection of a desired electrical circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxAllCircuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCircuit = _circuitsAll[comboBoxCircuitsAll.SelectedIndex];
            bindingSourceContainer.DataSource = _currentCircuit.Elements;
        }

        #endregion ComboBox

        #region Buttons

        /// <summary>
        /// Adding a random element of an electrical circuit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRandomElement_Click(object sender, EventArgs e)
        {
            RandomElement randomElementCircuit = new RandomElement();
            bindingSourceContainer.Add(randomElementCircuit.CreateRandomElement());
        }
        #endregion Buttons

        #region ToolStripMenuItem

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
            if (dataGridViewValueDisplay.CurrentRow != null)
            {
                int rowToDelete = dataGridViewValueDisplay.CurrentRow.Index;

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

        #endregion ToolStripMenuItem

        #region DataGridView

        /// <summary>
        /// Fires when the cursor is over the nominal value of the electrical circuit element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewValueDisplay_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {               
                dataGridViewValueDisplay[e.ColumnIndex, e.RowIndex].ToolTipText =
                    MyToolTipText.MessageForRows;
            }          
        }

        /// <summary>
        /// Triggered when the edit mode is started for the selected cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewValueDisplay_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _newValueElement = new TextBox();            
            _oldValueElement = Convert.ToDouble(dataGridViewValueDisplay.CurrentCell.Value);           
        }

        /// <summary>
        /// Event triggered when validating a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewValueDisplay_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
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
        private void DataGridViewValueDisplay_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            e.Handled = !EditTextBoxValue.IsCurrectionTextBoxValue_Edit(_newValueElement.Text, e.KeyChar);
        }

        #endregion DataGridView                                              
    }
}

