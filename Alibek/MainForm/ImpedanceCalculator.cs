using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using ElementsLibrary;

namespace MainForm
{
    //TODO: неправильное название файла
    /// <summary>
    ///     Форма под калькулятор
    /// </summary>
    public partial class ImpedanceCalculatorForm : Form
    {
        #region Readonly fields

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Private fields

        //TODO: почему uint только endvalue?
        private uint _endValue;
        private double _startValue;
        private double _stepValue;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор формы
        /// </summary>
        /// <param name="circuit">Цепь</param>
        public ImpedanceCalculatorForm(Circuit circuit)
        {
            InitializeComponent();
            //TODO: зачем ContextMenu?
            _startValueTextBox.ContextMenu = new ContextMenu();
            _stepValueTextBox.ContextMenu = new ContextMenu();
            _endValueTextBox.ContextMenu = new ContextMenu();
            _circuit = circuit;
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Функция для подсчета
        /// </summary>
        private void CalculateImpedance()
        {
            ValueValidators.ChangeSeparator(_startValueTextBox);
            ValueValidators.ChangeSeparator(_stepValueTextBox);
            ValueValidators.ChangeSeparator(_endValueTextBox);

            var start = double.TryParse(_startValueTextBox.Text, out _startValue);
            var step = double.TryParse(_stepValueTextBox.Text, out _stepValue);
            var finish = uint.TryParse(_endValueTextBox.Text, out _endValue);

            if (!ValueValidators.IsCorrectFrequency(_startValue, _stepValue, _endValue))
            {
                return;
            }

            //TODO: заменить на список, и конвертировать в массив уже при передаче в CalculateZ с помощью LINQ-метода ToArray();
            // Иначе сложночитаемый код, с постоянным динамическим увеличением массива на один элемент в цикле.
            //TODO: Кусок кода Шагаева!!! ВСЁ, что скопировано - удалить, и написать своё!
            var frequency = new double[1];

            var j = 0;
            for (var i =_startValue; i <= _endValue; i += _stepValue)
            {
                frequency[j] = i;
                j++;
                if (!(_endValue - i == 0))
                {
                    Array.Resize(ref frequency, frequency.Length + 1);
                }
            }

            if (Math.Abs(frequency[frequency.Length - 1] - 0 ) < 0.0000001)
            {
                Array.Resize(ref frequency, frequency.Length - 1);
            }

            var impedances = _circuit.CalculateZ(frequency);
            var correctListOfImpedances = new List<string>();

            for (var i = 0; i < impedances.Count; i++)
            {
                correctListOfImpedances.Add($"R:{Math.Round(impedances[i].Real, 3)} " +
                                            $"I:{Math.Round(impedances[i].Imaginary, 3)}");
            }

            for (var i = 0; i < impedances.Count; i++)
            {
                _calculatorDataGridView.Rows.Add(Math.Round(frequency[i], 3),
                    correctListOfImpedances[i]);
            }
        }

        /// <summary>
        ///     Кнопка для расчета импеданса
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            _calculatorDataGridView.Rows.Clear();
            CalculateImpedance();
        }

        /// <summary>
        ///     Событие подготавливающие поле к вводу.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ValueValidators.Enter(sender);
        }

        /// <summary>
        ///     Событие подготавливающие поле к выводу.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ValueValidators.Leave(sender);
        }

        /// <summary>
        ///     Событие для ограничения ввода символов в текстбокс для double.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressDouble(e, ((TextBox) sender).Text);
        }

        /// <summary>
        ///     Собыите для ограничения ввода символов в текстбокс для int .
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        /// <param name="e">Параметры события</param>
        private void IntTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressInt(sender, e);
        }

        #endregion
    }
}