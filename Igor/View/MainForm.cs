using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gpt.Model;

namespace Gpt.View
{
    public partial class MainForm : Form
    {
        private List<ElementBase> _elements;    
        private AddForm _addForm;
        public MainForm()
        {
            InitializeComponent();
            _addForm = new AddForm();
            bindingSource1.DataSource = _elements;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _addForm.ShowDialog();
            if (_addForm.ElementBase != null)
            {
                bindingSource1.Add(_addForm.ElementBase);
                //_elements.Add(_addForm.ElementBase);
               // _addForm.NewElementControl = new ElementControl();
            }

            panel1.Controls.Add(_addForm.NewElementControl);
        }
    }
}
