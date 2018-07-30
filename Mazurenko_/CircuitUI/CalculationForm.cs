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
        #region -- Fields --

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

        #endregion -- Fields --

        #region -- Properties --

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

        #endregion -- Properties --

        #region -- Public Methods --

        /// <summary>
        /// Constructor
        /// </summary>
        public CalculationForm()
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
        private void CalculationForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            InitializeToolTip();
        }

        /// <summary>
        /// Initializatio ToolTip
        /// </summary>
        private void InitializeToolTip()
        {
            ToolTip toolTipButton = new ToolTip
            {
                InitialDelay = 100,
                ReshowDelay = 100,
                ShowAlways = true
            };

            toolTipButton.SetToolTip(calculationButton,
                "Calculation of the total complex resistance of the electrical" +
                "\n( Ctrl + C )");

            toolTipButton.SetToolTip(deleteButton,
                "Delete the selected line" + "\n( Ctrl + D )");

            toolTipButton.SetToolTip(deleteAllButton,
                "Clear the entire list of values" + "\n( Ctrl + Shift + D )");
        }

        /// <summary>
        /// Calculation of the total complex resistance of the electrical
        /// circuit on a given list of frequencies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СalculationButton_Click(object sender, EventArgs e)
        {
            if (calculationGridView.RowCount > 0)
            {
                _frequencies = new double[calculationGridView.RowCount - 1];

                for (int i = 0; i < calculationGridView.RowCount - 1; i++)
                {
                    _frequencies[i] = Convert.ToDouble(calculationGridView[0, i].Value);
                }

                Complex[] impedance = _curcuit.CalculateZ(_frequencies);

                for (int j = 0; j < calculationGridView.RowCount - 1; j++)
                {
                    calculationGridView[1, j].Value =
                        "( " + Math.Round(impedance[j].Real, 6) + " , " +
                        Math.Round(impedance[j].Imaginary, 6) + " )";
                }
            }
        }

        /// <summary>
        /// Delete the selected line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (calculationGridView.CurrentRow != null)
            {
                int indexDeleteRow = calculationGridView.SelectedCells[0].RowIndex;

                if (calculationGridView.CurrentRow != null &&
                    (indexDeleteRow >= 0 && !calculationGridView.CurrentRow.IsNewRow))
                {
                    calculationGridView.Rows.RemoveAt(indexDeleteRow);
                }
            }
        }

        /// <summary>
        /// Clear the entire list of values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            calculationGridView.Rows.Clear();
        }

        /// <summary>
        /// Fires when the cursor is over the cells of the "Frequenies" column"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculationGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                calculationGridView[e.ColumnIndex, e.RowIndex].ToolTipText =
                    ToolTipText.MessageForRows;
            }
        }

        /// <summary>
        /// Triggered when validating a cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculationGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (calculationGridView.CurrentRow != null && (e.ColumnIndex == 0 && !calculationGridView.CurrentRow.IsNewRow))
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
        private void CalculationGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            _frequency = new TextBox();
            _oldValueFrequency = !calculationGridView.CurrentRow.IsNewRow ? Convert.ToDouble(calculationGridView.CurrentCell.Value) : _minValue;
        }

        /// <summary>
        /// Event when changing the value Frequency of the electrical circuit element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculationGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            e.Handled = !EditTextBoxValue.IsCorrectionTextBoxValue_Edit(_frequency.Text, e.KeyChar);
        }

        /// <summary>
        /// Checking for shortcut Keys
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                calculationButton.PerformClick();
            }

            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                deleteAllButton.PerformClick();
                return;
            }

            if (e.Control && e.KeyCode == Keys.D)
            {
                deleteButton.PerformClick();
            }
        }
        #endregion -- Private Methods --           
        
    }
}
