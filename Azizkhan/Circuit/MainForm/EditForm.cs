using System;
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

        #region Private fields

        /// <summary>
        ///     Элемент
        /// </summary>
        private ElementBase _element;

        #endregion

        #endregion

        #region Properties

        public ElementBase Element
        {
            get => _element;
            set
            {
                _element = value ?? throw new ArgumentNullException(nameof(_element));
                Text = "Элемент: " + Element.Name;
                valueTextBox.Text = Convert.ToString((decimal) Element.Value);
            }
        }

        #endregion

        #region Constructor

        //TODO: элемент должен передаваться в форму через свойство, а не аргумент конструктора.
        //+
        // Иначе ограничиваются варианты использования формы
        /// <summary>
        ///     Конструктор
        /// </summary>
        public EditForm()
        {
            InitializeComponent();

            //TODO: зачем decimal? Преобразование вообще не нужно, как и класс Convert
            //Странные преобразования для того,
            //чтобы экспоненциальная форма записи не тянулась с TreeView в форму.

            //TODO: DialogResult должен присваиваться перед закрытием формы, а не в конструкторе
            //+
        }

        #endregion

        #region Private methods

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!FormTools.CheckCorrectValue(valueTextBox.Text))
            {
                FormTools.ShowError(valueTextBox);
                valueTextBox.Text = "";
                return;
            }

            _element.Value = Convert.ToDouble(valueTextBox.Text);
            DialogResult = DialogResult.Yes;
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

        #endregion
    }
}