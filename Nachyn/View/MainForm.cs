using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.PropertyGrid;


namespace View
{
    public partial class MainForm : Form
    {
        private readonly Circuit _circuit;

        private Calculations _calculations;

        public MainForm()
        {
            InitializeComponent();
            _calculations = new Calculations();
            _circuit = new Circuit();
            _propertyGrid.SelectedObject = _calculations;
        }

        private void _toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            new AddForm(_circuit.Elements, _panelCircuit).ShowDialog();
        }

        private void _toolStripButtonClearCircuit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Очистить цепь?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                _circuit.Elements.Clear();
                _panelCircuit.Controls.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("-----------");
            foreach (var el in _circuit.Elements) Console.WriteLine(el + " " + el.Name + " " + el.Value);

            Console.WriteLine("-----------");
            foreach (ViewElement el in _panelCircuit.Controls) Console.WriteLine(el + " " + el.Name + " " + el.Item.Name);
        }

        private void _toolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            _calculations.Impedances.Clear();
            _calculations.Impedances.AddRange(_circuit.CalculateZ(_calculations.Frequencies.ToArray()));
        }
    }
}