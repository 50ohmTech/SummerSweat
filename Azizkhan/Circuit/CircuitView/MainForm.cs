using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Circuit;
using CircuitModel;

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
            FrequencyGrid.SelectedObject = _calculations;
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