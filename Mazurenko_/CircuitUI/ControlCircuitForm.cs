using System;
using System.Windows.Forms;
using CircuitLibrary;

namespace CircuitUI
{
    /// <summary>
    /// Adding a new electrical circuit element
    /// </summary>
    public partial class ControlCircuitForm : Form
    {
        #region Fields

        /// <summary>
        /// Field to store the name of electrical circuit element
        /// </summary>
        private string _name;

        /// <summary>
        /// Field to store the value of electrical circuit element
        /// </summary>
        private string _value;

        /// <summary>
        /// Field to store the type of electrical circuit element
        /// </summary>
        private string _type;

        /// <summary>
        /// The minimum value that the cell takes
        /// </summary>
        private const double _minValue = 0.000001;

        /// <summary>
        /// The Maximum value that the cell takes
        /// </summary>
        private const double _maxValue = 100000000000000;

        #endregion Fields

        #region Сonstructor

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public ControlCircuitForm()
        {
            InitializeComponent();
            DefaultSetting();
        }

        #endregion Сonstructor

        #region Properties

        /// <summary>
        /// Property for interaction with an element of an electrical circuit
        /// </summary>
        public IElement Element { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Form settings
        /// </summary>
        private void DefaultSetting()
        {
            comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxType.Text = Convert.ToString(comboBoxType.Items[0]);
            textBoxName.MaxLength = 10;
            textBoxValue.MaxLength = 15;
        }

        /// <summary>
        /// Checking for empty name and value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsClearBlank(string name, string value)
        {
            return string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Method for checking strings for English characters only
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static bool IsEnglishSymbol(char symbol)
        {
            return symbol >= 'A' && symbol <= 'Z';
        }        

        #endregion Methods

        #region TextBox

        /// <summary>
        /// Event when you press a key in the 'Name' field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Back)
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
                if (!IsEnglishSymbol(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Event when leaving the 'Name' field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxName_Leave(object sender, EventArgs e)
        {
            _name = textBoxName.Text;
        }

        /// <summary>
        /// Event when you press a key in the 'Value' field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled =
                !EditTextBoxValue.IsCurrectionTextBoxValue_Edit(textBoxValue.Text,
                    e.KeyChar);
        }

        /// <summary>
        /// Event triggered after pressing the key in the "Value" field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxValue_KeyUp(object sender, KeyEventArgs e)
        {            
            double.TryParse(textBoxValue.Text, out double number);
            buttonOK.Enabled = (number >= _minValue && number <= _maxValue) || textBoxValue.Text == "";
        }

        /// <summary>
        /// Event when leaving the 'Value' field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxValue_Leave(object sender, EventArgs e)
        {
            _value = textBoxValue.Text;
        }

        #endregion TextBox

        #region ComboBox

        /// <summary>
        /// Event occurs when the selection of element type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxType.Text == @"Resistor")
            {
                pictureBoxElementCircuit.Image = Properties.Resources.Resistor;
                _type = "Resistor";
            }
            else if (comboBoxType.Text == @"Inductor")
            {
                pictureBoxElementCircuit.Image = Properties.Resources.Inductor;
                _type = "Inductor";
            }
            else if (comboBoxType.Text == @"Capacitor")
            {
                pictureBoxElementCircuit.Image = Properties.Resources.Capacitor;
                _type = "Capacitor";
            }
        }

        #endregion ComboBox

        #region Button

        /// <summary>
        /// Event when pressing the 'OK' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (IsClearBlank(_name, _value))
            {
                MessageBox.Show(@"Data not fully entered !");
            }
            else
            {
                DialogResult = DialogResult.OK;
                IElement newElement;
                if (_type == "Resistor")
                {
                    newElement = new Resistor(_name, Convert.ToDouble(_value));
                }
                else if (_type == "Inductor")
                {
                    newElement = new Indutor(_name, Convert.ToDouble(_value));
                }
                else
                {
                    newElement = new Capacitor(_name, Convert.ToDouble(_value));
                }

                Element = newElement;

                this.Close();
            }
        }

        /// <summary>
        /// Event when pressing the 'Cancel' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion Button
    }
}
