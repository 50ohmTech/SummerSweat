using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace View
{
    /// <summary>
    /// Форма для расчета имеданса
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Fields

        #region Readonly fields

        private readonly Circuit _circuit;

        #endregion

        #endregion

        #region Constructor

        //TODO: заменить входной аргумент конструктора на свойство внутри формы.
        // Иначе ограничиваешь варианты использования формы
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
            //TODO: переименовать frequence на frequency
            var frequence = new double[1];

            var j = 0;
            for (var i = start; i <= finish; i += step)
            {
                frequence[j] = i;
                j++;
                if (!(finish - i == 0))
                {
                    Array.Resize(ref frequence, frequence.Length + 1);
                }
            }

            if (frequence[frequence.Length - 1] == 0)
            {
                Array.Resize(ref frequence, frequence.Length - 1);
            }

            var impedances = _circuit.CalculateZ(frequence);
            //TODO: никаких сокращений в названии. Переименовать
            var impd = new List<string>();

            for (var i = 0; i < impedances.Count; i++)
            {
                impd.Add(
                    $"R:{Math.Round(impedances[i].Real, 3)} " +
                    $"I:{Math.Round(impedances[i].Imaginary, 3)}");
            }

            for (var i = 0; i < impedances.Count; i++)
            {
                dataGridView.Rows.Add(Math.Round(frequence[i], 3), impd[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateImpedance();
        }

        private void ValidatigTextBox(TextBox textBox)
        {
            //TODO: избавиться от сравнения с false
            if (IsCellCorrect(textBox.Text) == false)
            {
                MessageBox.Show(
                    "Вы ввели: " + textBox.Text + "\n" +
                    "Вводимое значение должно удовлетворять следующим условиям:\n " +
                    "-быть положительным числом\n " +
                    "-быть вещественным или натуральным числом\n " +
                    "-быть большим 0.000 000 1 по модулю\n " +
                    "-быть меньше 1 000 000 000\n " +
                    "-запись не должна содержать пробелов\n " +
                    "-запись должна начинаться с цифры\n " +
                    "-использование экспоненциальной записи не допускается\n " +
                    "-eсли первой цифрой числа являтся ноль, значит после него обязательно должна быть запятая.",
                    "Ошибка ввода значения частоты", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                textBox.Clear();
            }
            //TODO: избавиться от сравнения с false
            if (IsCellCorrect(StartTextBox.Text) == false ||
                IsCellCorrect(FinishTextBox.Text) == false ||
                IsCellCorrect(StepTextBox.Text) == false)
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

        #region Public methods

        public static bool IsCellCorrect(string e)
        {
            var formatingString = e.Replace('.', ',');
            if (double.TryParse(formatingString, //TODO: сложные условия надо комментировать. Парсить внутри сложного условия - тяжело читается код
                    out var newValue) && !(newValue < 0.0000001) &&
                newValue <= 1000000000) //TODO: заменить на экспоненциальную форму вещественного числа
            {
                //TODO: сложные условия надо комментировать
                if (formatingString.Length > 1 && formatingString[0] == '0' &&
                    formatingString[1] != ',')
                {
                    return false;
                }

                if (formatingString[0] == ',' || formatingString[0] == '.')
                {
                    return false;
                }

                if (e.Contains(" "))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        #endregion
    }
}