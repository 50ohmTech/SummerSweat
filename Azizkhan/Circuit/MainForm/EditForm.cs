using System;
using System.ComponentModel;
using System.Windows.Forms;
using CircuitLibrary.Elements;

namespace CircuitView
{
    /// <summary>
    ///     Форма редактирования элементов цепи
    /// </summary>
    public partial class EditForm : Form
    {
        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Элемент
        /// </summary>
        private readonly ElementBase _element;

        #endregion

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Элемент</param>
        public EditForm(ElementBase element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
            Text = "Элемент: " + element.Name;
            valueTextBox.Text = element.Value.ToString();

            DialogResult = DialogResult.Yes;
            cancelButton.DialogResult = DialogResult.Cancel;
        }

        #endregion

        #region Private methods

        private void OkButton_Click(object sender, EventArgs e)
        {
            _element.Value = Convert.ToDouble(valueTextBox.Text);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = valueTextBox.Text.Length != 0;
        }

        private void valueTextBox_Validating(object sender, CancelEventArgs e)
        {
            FormTools.TextBoxCheck(valueTextBox, e);
        }

        #endregion
    }
}