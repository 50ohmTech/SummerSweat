using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ElementsLibrary;

namespace MainForm
{
    public partial class ImpedanceCalculator : Form
    {
        private readonly Circuit _circuit;

        public ImpedanceCalculator(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
            CalculatorDataGridView.RowHeadersVisible = false;
            CalculateButton.Enabled = false;

        }
    }
}
