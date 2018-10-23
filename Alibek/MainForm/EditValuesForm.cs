﻿using System;
using System.Windows.Forms;
using ElementsLibrary.Elements;

namespace MainForm
{
    /// <summary>
    ///     Форма для изменения значений в TreeView
    /// </summary>
    public partial class EditValuesForm : Form
    {
        #region Readonly fields

        /// <summary>
        ///     Элемент
        /// </summary>
        private readonly ElementBase _element;

        #endregion

        #region Private fields

        /// <summary>
        ///     Значение(номинал) элемента
        /// </summary>
        private double _value;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор формы
        /// </summary>
        /// <param name="element"></param>
        public EditValuesForm(ElementBase element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Событие подготавливающие поле к вводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ValueValidators.Enter(sender);
        }

        /// <summary>
        ///     Событие подготавливающие поле к вводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ValueValidators.Leave(sender);
        }

        /// <summary>
        ///     Собыите для ограничиния вводв символов в текстбокс для double.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressDouble(e, ((TextBox) sender).Text);
        }

        /// <summary>
        ///     Событие по которому изменяется значение элемента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditValueButton_Click(object sender, EventArgs e)
        {
            _element.Value = Convert.ToDouble(editValuesTextBox.Text);
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        ///     Событие для выхода из формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}