using System;
using System.Windows.Forms;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Форма редактирования элементов.
    /// </summary>
    public partial class EditForm : Form
    {
        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="element">Элемент.</param>
        public EditForm(ElementBase element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
            Text = "Элемент: " + element.Name;
            EditNumericUpDown.Text = element.Value.ToString();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Закрыть форму.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Изменить номинал элемента.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            _element.Value = _value;
            Close();
        }

        /// <summary>
        ///     Считать данные с NumericUpDown.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void EditNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _value = Convert.ToDouble(EditNumericUpDown.Text);
        }

        #endregion

        #region Fields

        #region Readonly fields

        /// <summary>
        ///     Элемент.
        /// </summary>
        private readonly ElementBase _element;

        #endregion

        #region Private fields

        /// <summary>
        ///     Номинал.
        /// </summary>
        private double _value;

        #endregion

        #endregion
    }
}