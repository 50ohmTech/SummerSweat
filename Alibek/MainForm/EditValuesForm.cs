using System;
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

        private ElementBase element { get; set; }

        #region Constructor

        //TODO: элемент должен передаваться через открытое свойство, а не аргумент конструктора
        //сделал
        /// <summary>
        ///     Конструктор формы
        /// </summary>
        /// <param name="element">Элемент цепи</param>
        /// <returns>Инициализирует форму</returns>
        public EditValuesForm()
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Событие подготавливающие поле к вводу.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {

            if (sender is TextBox textBox)
            {
                ValueValidators.Enter(textBox);
            }
        }

        /// <summary>
        ///     Событие подготавливающие поле к вводу.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                ValueValidators.Leave(textBox);
            }
        }

        /// <summary>
        ///     Собыите для ограничиния вводв символов в текстбокс для double.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressDouble(e, ((TextBox) sender).Text);
        }

        /// <summary>
        ///     Событие по которому изменяется значение элемента
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void EditValueButton_Click(object sender, EventArgs e)
        {
            _element.Value = Convert.ToDouble(_editValuesTextBox.Text);
            //TODO: Почему Cancel?
            //долгая история но если поставить DialogResult.OK, то значения не меняются
            //и я понятия не имею с чем это связано
            // РАЗБЕРИСЬ И СДЕЛАЙ ЧЕРЕЗ OK, А НЕ ПРОСТО КОПИРУЙ КОД
     
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        ///     Событие для выхода из формы
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}