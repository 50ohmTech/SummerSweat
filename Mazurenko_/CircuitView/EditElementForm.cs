﻿using System;
using System.Windows.Forms;
using CircuitLibrary;

namespace CircuitView
{
    /// <summary>
    ///     Form to edit the value of the item
    /// </summary>
    public partial class EditElementForm : Form
    {
        #region Private fields

        /// <summary>
        ///     Element to change
        /// </summary>
        private ElementBase _element;

        /// <summary>
        ///     The new value for the element
        /// </summary>
        private double _newValue;

        #endregion

        #region Properties

        /// <summary>
        ///     To set the element to change
        /// </summary>
        public ElementBase SetElement
        {
            set
            {
                _element = value ?? throw new ArgumentException("Element is null");
                NameElementLabel.Text = _element.Name;
                ValueTextBox.Text = _element.Value.ToString();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public EditElementForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Action with button "OK"
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            _element.Value = _newValue;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Action with button "Cancel"
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        ///     Event when you press a key in the 'Value' field
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueTextBoxTools.DoubleKeyPress(e, sender);
        }

        /// <summary>
        ///     Event when leaving the 'Value' field
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_Leave(object sender, EventArgs e)
        {
            var resultValue = ValueTextBoxTools.Leave(sender);
            OKButton.Enabled = resultValue;

            if (!string.IsNullOrWhiteSpace(ValueTextBox.Text))
            {
                _newValue = Convert.ToDouble(ValueTextBox.Text);
            }
        }

        /// <summary>
        ///     Event triggered when the field is changed 'Value'
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event parameter</param>
        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            OKButton.Enabled =
                ValueTextBoxTools.TextChanged(sender);
        }

        #endregion
    }
}