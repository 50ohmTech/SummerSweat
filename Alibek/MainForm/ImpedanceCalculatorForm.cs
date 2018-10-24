﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using ElementsLibrary;

namespace MainForm
{
    //TODO: неправильное название файла
    //сделяль
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

        private List<double> _frequencies;

        private List<Complex> impedances;

        #endregion

        #region Private fields

        //TODO: почему uint только endvalue?
        //по идее это костыль
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
            //сделяль
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

            var startValue = double.TryParse(_startValueTextBox.Text, out _startValue);
            var stepValue = double.TryParse(_stepValueTextBox.Text, out _stepValue);
            var endValue = uint.TryParse(_endValueTextBox.Text, out _endValue);

            if (!ValueValidators.IsCorrectFrequency(_startValue, _stepValue, _endValue))
            {
                return;
            }

            //TODO: заменить на список, и конвертировать в массив уже при передаче в CalculateZ с помощью LINQ-метода ToArray();
            // Иначе сложночитаемый код, с постоянным динамическим увеличением массива на один элемент в цикле.
            //TODO: Кусок кода Шагаева!!! ВСЁ, что скопировано - удалить, и написать своё!
            //Я сделяль
            _frequencies = new List<double>();

            for (int counter = 0; counter < _endValue; counter++)
            {
                _frequencies.Add(_startValue + counter * _stepValue);
            }

            impedances = _circuit.CalculateZ(_frequencies.ToArray());

            for (int counter = 0; counter < impedances.Count; counter++)
            {
                _calculatorDataGridView.Rows.Add(_frequencies[counter],
                    impedances[counter]);
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