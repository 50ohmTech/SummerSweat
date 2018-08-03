using System;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class AddElementForm : Form

    {
        #region -- Свойства --

        /// <summary>
        ///     Свойство для ввода/вывода элемента на EnterElementControl
        /// </summary>
        public IElement NewElement
        {
            get => addFormControl.Element;
            set => addFormControl.Element = value;
        }

        #endregion

        #region -- Публичные методы --

        /// <summary>
        ///     Конструктор формы для добавления элемента
        /// </summary>
        public AddElementForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Конструктор формы для редактирования элемента
        /// </summary>
        /// <param name="element"> Редактируемый элемент </param>
        /// <param name="isModify"> Сообщение контроллеру о том что элемент редактируется</param>
        public AddElementForm(IElement element, bool isModify)
        {
            InitializeComponent();
            addFormControl.isModify = isModify;
            NewElement = element;
        }

        #endregion

        #region -- Приватные методы --

        /// <summary>
        ///     Сохранение данных об элементе для дальнейшего добавления/редактирования элемента в MainForm
        /// </summary>
        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        ///     Отмена создания/редактирования элементов
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}