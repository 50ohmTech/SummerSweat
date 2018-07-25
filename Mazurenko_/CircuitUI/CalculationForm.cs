using System;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using CircuitLibrary;

namespace CircuitUI
{
    /// <summary>
    /// The calculation of the total resistance
    /// </summary>
    public partial class CalculationForm : Form
    {
        #region Constructor

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public CalculationForm()
        {
            InitializeComponent();            
            DefaultSettingCalculationForm();
        }

        #endregion Constructor

        #region Fields

        /// <summary>
        /// List of electrical circuit elements
        /// </summary>
        private Circuit _curcuit;

        /// <summary>
        /// Field to store all added frequencies
        /// </summary>
        private double[] _frequencies;

        /// <summary>
        /// Field for temporary storage of frequency values
        /// </summary>
        private TextBox _frequency;

        /// <summary>
        /// Field to store the initial value of the cell
        /// </summary>
        private double _oldValueFrequency;

        /// <summary>
        /// The minimum value that the cell takes
        /// </summary>
        private const double _minValue = 0.0000001;

        /// <summary>
        /// The Maximum value that the cell takes
        /// </summary>
        private const double _maxValue = 100000000000000;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Adding a list of electrical circuit elements
        /// </summary>
        public Circuit SetCircuit
        {
            set
            {
                if (value.Elements.Any())
                {
                    _curcuit = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Empty list of electrical circuit elements is added");
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initial setting CalculationForm
        /// </summary>
        private void DefaultSettingCalculationForm()
        {
            dataGridViewCalculation.RowHeadersVisible = false;
            dataGridViewCalculation.MultiSelect = false;
            dataGridViewCalculation.Columns.Add("columnFrequenies", "Frequenies");
            dataGridViewCalculation.Columns.Add("columnImpendances", "Impendances");
            dataGridViewCalculation.Columns[1].Width = 150;
            dataGridViewCalculation.Columns[0].ReadOnly = false;
            dataGridViewCalculation.Columns[1].ReadOnly = true;
            dataGridViewCalculation.ShowCellToolTips = true;
        }

        #endregion Methods

        #region Buttons

        /// <summary>
        /// Calculation of the total complex resistance of the electrical
        /// circuit on a given list of frequencies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonСalculation_Click(object sender, EventArgs e)
        {
            if (dataGridViewCalculation.RowCount > 0)
            {
                _frequencies = new double[dataGridViewCalculation.RowCount - 1];

                for (int i = 0; i < dataGridViewCalculation.RowCount - 1; i++)
                {
                    _frequencies[i] = Convert.ToDouble(dataGridViewCalculation[0, i].Value);
                }

                Complex[] impedance = _curcuit.CalculateZ(_frequencies);

                for (int j = 0; j < dataGridViewCalculation.RowCount - 1; j++)
                {                  
                    dataGridViewCalculation[1, j].Value =
                        "( " + Math.Round(impedance[j].Real, 6) + " , " +
                        Math.Round(impedance[j].Imaginary, 6) + " )";
                }                
            }
        }

        /// <summary>
        /// Clear the entire list of values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            dataGridViewCalculation.Rows.Clear();
        }

        /// <summary>
        /// Delete the selected line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCalculation.CurrentRow != null)
            {
                int indexDeleteRow = dataGridViewCalculation.SelectedCells[0].RowIndex;

                if (dataGridViewCalculation.CurrentRow != null &&
                    (indexDeleteRow >= 0 && !dataGridViewCalculation.CurrentRow.IsNewRow))
                {
                    dataGridViewCalculation.Rows.RemoveAt(indexDeleteRow);
                }
            }
        }

        #endregion Buttons

        #region DataGridView

        /// <summary>
        /// Fires when the cursor is over the cells of the "Frequenies" column"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCalculation_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                dataGridViewCalculation[e.ColumnIndex, e.RowIndex].ToolTipText =
                    MyToolTipText.MessageForRows;
            }
        }

        /// <summary>
        /// Triggered when validating a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCalculation_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridViewCalculation.CurrentRow != null && (e.ColumnIndex == 0 && !dataGridViewCalculation.CurrentRow.IsNewRow))
            {
                double.TryParse(e.FormattedValue.ToString(), out double newFrequency);
                if (newFrequency < _minValue || newFrequency > _maxValue)
                {
                    _frequency.Text = Convert.ToString(_oldValueFrequency);
                }
            }            
        }

        /// <summary>
        /// Triggered when the edit mode is started for the selected cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCalculation_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _frequency = new TextBox();
            _oldValueFrequency = !dataGridViewCalculation.CurrentRow.IsNewRow ? Convert.ToDouble(dataGridViewCalculation.CurrentCell.Value) : _minValue;
        }

        /// <summary>
        /// Event when changing the value Frequency of the electrical circuit element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewCalculationForm_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _frequency = (TextBox)e.Control;
            _frequency.KeyPress += new KeyPressEventHandler(Frequency_KeyPress);
        }

        /// <summary>
        /// Event to checking the key pressed in a cell 'Value'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frequency_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !EditTextBoxValue.IsCurrectionTextBoxValue_Edit(_frequency.Text, e.KeyChar);
        }

        #endregion DataGridView       
    }
}
