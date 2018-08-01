using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gpt.Model;

namespace Gpt.View
{
    public partial class CalculateForm : Form
    {
        private ObservableCollection<ElementBase> _elements;

        private List<Complex> _impedancies;

        private Circuit Circuit;

        public CalculateForm(Circuit circuit)
        {
            InitializeComponent();
            _elements = circuit.Elements;
            Circuit = circuit;
        }

        public void CalculateImpedance_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[] temp = new double[dataGridView1.Rows.Count - 1];
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                temp[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[0].Value);
            }

            _impedancies = Circuit.CalculateZ(temp);
            dataGridView1.Rows.Clear();

            for (var index = 0; index < _impedancies.Count; index++)
            {
                dataGridView1.Rows.Add(temp[index], _impedancies[index]);
            }
        }
    }
}
