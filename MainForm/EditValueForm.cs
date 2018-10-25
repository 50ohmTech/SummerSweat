using System;
using System.Windows.Forms;
using CircuitModel;

namespace MainForm
{
    /// <summary>
    /// Форма изменения значения элемента.
    /// </summary>
    public partial class EditValueForm : Form
    {
        #region ~ Переменные ~

        #region ~ Приватные переменные ~

        /// <summary>
        /// Значение элемента.
        /// </summary>
        private double _value;

        #endregion

        #region ~ Только для чтения ~

        /// <summary>
        /// Элемент цепи.
        /// </summary>
        private readonly ElementBase _element;

        #endregion

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="element"> Элемент цепи. </param>
        public EditValueForm(ElementBase element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
            Text = "Элемент: " + element.Name;
            _editValueTextBox.Text = element.Value.ToString();
        }

        #endregion

        #region ~ Приватные методы ~

        /// <summary>
        /// Функция закрытия формы.
        /// </summary>
        private void _closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Функция для изменения значения элемента.
        /// </summary>
        private void _editValueButton_Click(object sender, EventArgs e)
        {
            _element.Value = _value;
            Close();
        }

        private void _editValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(_editValueTextBox.Text, out _value))
            {
                _editValueButton.Enabled = false;
                return;
            }

            if (_value <= 0 || _value > 1000000000000)
            {
                _editValueButton.Enabled = false;
                return;
            }

            _editValueButton.Enabled = true;
        }

        #endregion
    }
}
