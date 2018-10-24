using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Форма редактирования элементов
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

        #region Private methods

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            _element.Value = _value;
            Close();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            //TODO: А Close() зачем убрал?
            //TODO: Либо здесь Close(), либо этот обработчик вообще не нужен
        }

        private void TextBoxValue_TextChanged(object sender, EventArgs e)
       {
            if (!double.TryParse(_textBoxValue.Text, out _value))
            {
                buttonEdit.Enabled = false;
                return;
            }

            if (_value <= 0.1 || _value >= 1e12)
            {
                buttonEdit.Enabled = false;
                return;
            }

            buttonEdit.Enabled = true;
        }

        #endregion

        #region Public methods

        //TODO: ЕЩЕ РАЗ! элемент должен быть открытым свойством, а не входным аргументом конструктора!
        //TODO: НЕЛЬЗЯ ПРОСТО ТАК УДАЛЯТЬ TODO!!!
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Элемент</param>
        public EditForm(ElementBase element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
            InitializeComponent();
            Text = "Элемент: " + element.Name;
            _textBoxValue.Text = element.Value.ToString();

            //TODO: Результат диалога должен присваиваться в обработчиках, закрывающих форму, а не в конструкторе
            DialogResult = DialogResult.Yes;
            //TODO: Зачем кнопке присваивать DialogResult?
            buttonCancel.DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}
