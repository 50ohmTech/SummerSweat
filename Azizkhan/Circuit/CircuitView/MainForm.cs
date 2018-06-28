using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitModel;
using CircuitModel.Elements;

namespace CircuitView
{
    public partial class MainForm : Form
    {
        private readonly Calculations _calculations;
        private readonly List<ElementBase> _elements = new List<ElementBase>();

        public MainForm()
        {
            InitializeComponent();
            _calculations = new Calculations();
            _frequencyGrid.SelectedObject = _calculations;
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                _elements.Add(form.Object);
            }
        }
    }
}