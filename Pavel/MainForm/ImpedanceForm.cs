using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using System.Numerics;

namespace MainForm
{
 /// <summary>
 /// Форма для расчета импедансов
 /// </summary>
    public partial class ImpedanceForm : Form
    {
        /// <summary>
        /// Цепь
        /// </summary>
        private readonly Circuit _circuit;

        /// <summary>
        /// Список импедансов цепи.
        /// </summary>
        private List<Complex> _impedancies;
        /// <summary>
        /// Список частот сигнала.
        /// </summary>
        private List<double> _frequencies;
        /// <summary>
        /// Конструктор класса ImpedanceForm
        /// </summary>
        /// <param name="circuit"></param>
        public ImpedanceForm(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
        }
        /// <summary>
        ///     Расчет импедансов.
        /// </summary>
        /// <param name="frequencies"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var start = double.Parse(StartTextBox.Text);
            var finish = double.Parse(FinishTextBox.Text);
            var step = double.Parse(StepTextBox.Text);

            _frequencies = new List<double>();

            for (var index = start; index <= finish;)
            {
                _frequencies.Add(index += step);
            }

            _impedancies = _circuit.CalculateZ(_frequencies.ToArray());
            dataGridView.Rows.Clear();

            for (var index = 0; index < _impedancies.Count; index++)
            {
                dataGridView.Rows.Add(_frequencies[index], _impedancies[index]);
            }
        }
    }
    
}
