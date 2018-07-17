using System;
using System.Globalization;
using System.Windows.Forms;

namespace DrawingTool
{
    /// <summary>
    ///     Форма для редактирования визуальных элементов
    /// </summary>
    public partial class EditForm : Form
    {
        /// <summary>
        ///     Номинал элемента
        /// </summary>
        private double _value;

        /// <summary>
        ///     Визуальный элемент
        /// </summary>
        private readonly ViewElement _viewElement;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="viewElement">Визуальный элемент</param>
        public EditForm(ViewElement viewElement)
        {
            InitializeComponent();
            _buttonEdit.Enabled = false;
            _textBoxName.Text = viewElement.Item.Name;
            _textBoxValue.Text =
                viewElement.Item.Value.ToString(CultureInfo.CurrentCulture);

            _viewElement = viewElement;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            _viewElement.Item.Value = _value;
            Close();
        }

        private void TextBoxValue_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(_textBoxValue.Text, out _value))
            {
                _buttonEdit.Enabled = false;
                return;
            }

            if (_value <= 0 || _value > 1000000000000)
            {
                _buttonEdit.Enabled = false;
                return;
            }

            _buttonEdit.Enabled = true;
        }
    }
}