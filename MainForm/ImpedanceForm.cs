using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitModel;
using System.Numerics;

/// <summary>
/// Форма расчета комплексного сопротивления цепи.
/// </summary>
namespace MainForm
{
    public partial class ImpedanceForm : Form
    {

        #region ~ Переменные  ~

        #region ~ Только для чтения ~

        /// <summary>
        /// Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region ~ Приватные переменные ~

        /// <summary>
        /// Список частот.
        /// </summary>
        private List<double> _frequencies;

        /// <summary>
        /// Список импедансов.
        /// </summary>
        private List<Complex> _impedances;

        private uint _endValue;
        private double _startValue;
        private double _stepValue;

        #endregion 

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="circuit"> Цепь. </param>
        public ImpedanceForm(Circuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
            //TODO: Зачем ContextMenu?
            //.
        }

        #endregion

        #region ~ Приватные методы ~
        /// <summary>
        /// Событие, срабатывающее при закрытии окна.
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Вычисление комплексного сопротивления для всех элементов.
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            _dataGridView.Rows.Clear();
            CalculateImpedances();
        }

        /// <summary>
        /// Подготавливает поле к вводу.
        /// </summary>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            ValueValidators.Enter(sender);
        }

        /// <summary>
        /// Подготавливает поле к выводу.
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            ValueValidators.Leave(sender);
        }

        /// <summary>
        /// Для ограничения ввода символов в текстбокс для double.
        /// </summary>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressDouble(e, ((TextBox)sender).Text);
        }

        /// <summary>
        /// Для ограничения ввода символов в текстбокс для int .
        /// </summary>
        private void IntTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValueValidators.PressInt(sender, e);
        }

        /// <summary>
        /// Функция подсчета коплексного сопротивления.
        /// </summary>
        private void CalculateImpedances()
        {
            //TODO: Почему start и step - double, а finish - uint?
            //.
            var _start = double.Parse(_startValueTextBox.Text);
            var _step = double.Parse(_stepValueTextBox.Text);
            var _finish = double.Parse(_endValueTextBox.Text); 

            //TODO: кусок кода полностью совпадает с кодом Аханова,
            // который в свою очередь накопировал у Шагаева.
            // Удалить скопированное и написать своё решение
            ValueValidators.ChangeSeparator(_startValueTextBox);
            ValueValidators.ChangeSeparator(_stepValueTextBox);
            ValueValidators.ChangeSeparator(_endValueTextBox);

            if (!ValueValidators.IsCorrectFrequency(_start, _step, _finish))
            {
                return;
            }

            //TODO: Заменить на список вместо массива, 
            //и конвертировать список в массив уже при вызове CalculateZ() с помощью LINQ-метода ToArray()
            //.
            _frequencies = new List<double>();

            for (var index = 0; index < _finish; index++)
            {
                _frequencies.Add(_start + index * _step);
            }

            _impedances = _circuit.CalculateZ(_frequencies.ToArray());
            _dataGridView.Rows.Clear();

            for (var index = 0; index < _impedances.Count; index++)
            {
                _dataGridView.Rows.Add(_frequencies[index], _impedances[index]);
            }
        }

        #endregion
    }
}
