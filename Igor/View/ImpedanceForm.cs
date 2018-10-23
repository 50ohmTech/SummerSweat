﻿using System;
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

        #region Private fields

        /// <summary>
        ///     Поле для цепи.
        /// </summary>
        private Circuit _circuit;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Свойство для цепи.
        /// </summary>
        public Circuit Circuit { get; set; }

        #endregion

        #region Constructor

        public ImpedanceForm()
        {
            InitializeComponent();
            dataGridView.RowHeadersVisible = false;
            CalculateButton.Enabled = false;
        }

        #endregion

        #region Private methods

        private void CalculateImpedance()
        {
            _circuit = Circuit;
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
            Tools.IsCorrectStartFinish(StartTextBox, FinishTextBox);
            CalculateImpedance();
        }

        private void ValidatigTextBox(TextBox textBox)
        {
            if (Tools.IsCellCorrect(textBox.Text) != true)
            {
                Tools.ShowError(textBox);
                textBox.Text = null;
                textBox.Clear();
                return;
            }

            if (Tools.IsCellCorrect(StartTextBox.Text) != true ||
                Tools.IsCellCorrect(FinishTextBox.Text) != true ||
                Tools.IsCellCorrect(StepTextBox.Text) != true)
            {
                CalculateButton.Enabled = false;
                return;
            }

            if (Circuit.Root != null)
            {
                CalculateButton.Enabled = true;
            }
        }

        private void StartTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StartTextBox.Text.Length > 0)
            {
                ValidatigTextBox(StartTextBox);
            }

            Tools.IsCorrectStep(StartTextBox, FinishTextBox, StepTextBox);
        }

        private void FinishTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FinishTextBox.Text.Length > 0)
            {
                ValidatigTextBox(FinishTextBox);
            }

            Tools.IsCorrectStep(StartTextBox, FinishTextBox, StepTextBox);
        }

        private void StepTextBox_TextChanged(object sender, EventArgs e)
        {
            if (StartTextBox.Text.Length > 0)
            {
                ValidatigTextBox(StepTextBox);
            }

            Tools.IsCorrectStep(StartTextBox, FinishTextBox, StepTextBox);
        }

        #endregion

        private void ImpedanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Circuit = null;
        }
    }
}