using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    ///     Форма для расчета имеданса
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Fields

        #region Readonly fields

        private readonly Circuit _circuit;

        #endregion

        #endregion

        #region Constructor

        public ImpedanceForm(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
            dataGridView.RowHeadersVisible = false;
            CalculateButton.Enabled = false;
        }

        #endregion

        #region Private methods

        private void CalculateImpedance()
        {
            var start = double.Parse(StartTextBox.Text.Replace('.', ','));
            var finish = double.Parse(FinishTextBox.Text.Replace('.', ','));
            var step = double.Parse(StepTextBox.Text.Replace('.', ','));

            var frequency = new double[1];

            var j = 0;
            for (var i = start; i <= finish; i += step)
            {
                frequency[j] = i;
                j++;
                if (!(finish - i == 0))
                {
                    Array.Resize(ref frequency, frequency.Length + 1);
                }
            }

            if (frequency[frequency.Length - 1] == 0)
            {
                Array.Resize(ref frequency, frequency.Length - 1);
            }

            var impedances = _circuit.CalculateZ(frequency);
            var correctListOfImpedances = new List<string>();

            for (var i = 0; i < impedances.Count; i++)
            {
                correctListOfImpedances.Add(
                    $"R:{Math.Round(impedances[i].Real, 3)} " +
                    $"I:{Math.Round(impedances[i].Imaginary, 3)}");
            }

            for (var i = 0; i < impedances.Count; i++)
            {
                dataGridView.Rows.Add(Math.Round(frequency[i], 3),
                    correctListOfImpedances[i]);
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateImpedance();
        }

        private void ValidatigTextBox(TextBox textBox)
        {
            if (Tools.IsCellCorrect(textBox.Text) != true)
            {
                Tools.ShowError(textBox);

                textBox.Clear();
            }

            if (Tools.IsCellCorrect(StartTextBox.Text) != true ||
                Tools.IsCellCorrect(FinishTextBox.Text) != true ||
                Tools.IsCellCorrect(StepTextBox.Text) != true)
            {
                CalculateButton.Enabled = false;
                return;
            }

            CalculateButton.Enabled = true;
        }

        private void StartTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StartTextBox.Text != null)
            {
                ValidatigTextBox(StartTextBox);
            }
        }

        private void FinishTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FinishTextBox.Text != null)
            {
                ValidatigTextBox(FinishTextBox);
            }
        }

        private void StepTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StartTextBox.Text != null)
            {
                ValidatigTextBox(StepTextBox);
            }
        }

        #endregion
    }
}