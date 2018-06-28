using System;
using System.Windows.Forms;
using Circuit;

namespace CircuitView
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            ElementControl.ReadOnly = false;
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
                   elementBase = ElementControl.Element;
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
                    ElementControl.Element = value;
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