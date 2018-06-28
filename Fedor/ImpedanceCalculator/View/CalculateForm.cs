using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using Model;

namespace View
{
    public partial class CalculateForm : Form
    {
        private List<double> _frequencies;

        public CalculateForm()
        {
            InitializeComponent();

            _frequencies = new List<double>
            {
                12.55,
                34.49,
                470,01,
                0.02,
                2,
                98,5
            };
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Circuit circuit = CircuitControl.Circuit;
            List<Complex> impedancies = circuit.CalculateZ(_frequencies);
            for (var index = 0; index < impedancies.Count; index++)
            {
                circuitGridView.Rows.Add(impedancies[index], _frequencies[index]);
            }
        }
    }
}
