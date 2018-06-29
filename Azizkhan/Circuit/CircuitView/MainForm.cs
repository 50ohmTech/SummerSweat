using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitModel;
using CircuitModel.Elements;
using Circuit = Circuit.Circuit;

namespace CircuitView
{
    public partial class MainForm : Form
    {
        private Calculations _calculations;
        private List<ElementBase> _elements = new List<ElementBase>();
        private List<global::Circuit.Circuit> _circuits = new List<global::Circuit.Circuit>();
        private static uint _circuitIterator = 1;

        public MainForm()
        {
            InitializeComponent();
            _calculations = new Calculations();
            _frequencyGrid.SelectedObject = _calculations;
        }

        private void AddElementButton_Click(object sender, EventArgs e)
        {
            if (_circuitComboBox.SelectedItem != null)
            {
                var form = new AddForm();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    _elements.Add(form.Object);
                }
            }
            else
            {
                MessageBox.Show("Перед добавлением нужно создать цепь и выбрать её!");
            }
            
        }

        private void AddCircuitButton_Click(object sender, EventArgs e)
        {
            _circuitComboBox.Items.Add($"Цепь #{_circuitIterator}");
            _circuits.Add(new global::Circuit.Circuit(_elements));
            _circuitIterator++;
        }

        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _elements = _circuits[
                    _circuitComboBox.Items.IndexOf(_circuitComboBox.SelectedItem)]
                .Elements;
        }
    }
}