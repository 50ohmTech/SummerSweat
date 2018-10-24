using System;
using System.Windows.Forms;
using Model.Elements;

namespace MainForm
{
    /// <summary>
    /// Форма изменения элемента
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

        #region Private fields
        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор формы EditForm
        /// </summary>
        /// <param name="element"></param>
        public EditForm(ElementBase element)
        {

            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
            EditTextBox.Value = Convert.ToDecimal(element.Value);
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Обработчик нажатия кнопки исправления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            if(!double.TryParse(EditTextBox.Text, out _value))
            {
                return;
            }
            _element.Value = _value;
            Close();
        }

        #endregion
        /// <summary>
        /// Обработчик закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}