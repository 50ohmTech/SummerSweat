using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class CircuitControl : UserControl
    {
        private ObservableCollection<Element> _elements;

        private uint _resistorCounter = 0;
        private uint _capacitorCounter = 0;
        private uint _inductorCounter = 0;

        public CircuitControl()
        {
            InitializeComponent();

            _elements = new ObservableCollection<Element>();

            elementBindingSource.DataSource = _elements;
            elementGridView.DataSource = elementBindingSource;            
        }

        private Circuit Circuit
        {
            get => Circuit;
            set => _elements = value.Elements;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (resistorRadioButton.Checked)
            {
                elementBindingSource.Add(new Resistor("R" + Convert.ToString(++_resistorCounter), Convert.ToDouble(valueBox.Text)));
            }
            else if (capacitorRadioButton.Checked)
            {
                elementBindingSource.Add(new Capacitor("C" + Convert.ToString(++_capacitorCounter), Convert.ToDouble(valueBox.Text)));
            }
            else if (inductorRadioButton.Checked)
            {
                elementBindingSource.Add(new Inductor("I" + Convert.ToString(++_inductorCounter), Convert.ToDouble(valueBox.Text)));
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void elementGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
