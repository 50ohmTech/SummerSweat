using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingTool
{
    public partial class EditForm : Form
    {
        private ViewElement _viewElement;

        public EditForm(ViewElement viewElement)
        {
            InitializeComponent();
            _buttonEdit.Enabled = false;
            _textBoxName.Text = viewElement.Item.Name;
            _textBoxValue.Text = viewElement.Item.Value.ToString(CultureInfo.CurrentCulture);
            _viewElement = viewElement;
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            _viewElement.Item.Value = _value;
            Close();
        }

        private double _value;

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
