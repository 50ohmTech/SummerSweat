using System;
using System.Windows.Forms;
using CircuitModel.Elements;

namespace CircuitView
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            _elementControl.ReadOnly = false;
        }

        /// <summary>
        ///     Вернуть и установить сущность ElementBase
        /// </summary>
        public ElementBase Object
        {
            get
            {
                ElementBase elementBase = null;
                try
                {
                    elementBase = _elementControl.Element;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }

                return elementBase;
            }
            set
            {
                try
                {
                    _elementControl.Element = value;
                }
                catch (ArgumentException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Добавить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Object != null)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}