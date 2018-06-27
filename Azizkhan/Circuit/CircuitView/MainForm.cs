using System;
using System.Windows.Forms;
using CircuitModel;

namespace CircuitView
{
    public partial class MainForm : Form
    {
        private Calculations _calculations;
        public MainForm()
        {
            InitializeComponent();
            _calculations = new Calculations();
            FrequencyGrid.SelectedObject = _calculations;
        }

        private void AddFrequencyButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}