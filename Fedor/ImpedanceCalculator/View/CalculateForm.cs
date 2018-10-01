using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using View.ConstraintTools;

namespace View
{
    /// <summary>
    /// Форма для вычисления импеданса.
    /// </summary>
    public partial class CalculateForm : Form
    {
        #region - - Поля - -

        /// <summary>
        /// Список частот сигнала.
        /// </summary>
        private List<double> _frequencies;

        /// <summary>
        /// Список импедансов цепи.
        /// </summary>
        private List<Complex> _impedancies;

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CalculateForm.
        /// </summary>
        public CalculateForm()
        {
            InitializeComponent();

            startValueBox.ContextMenu = new ContextMenu();
            intervalBox.ContextMenu = new ContextMenu();
            countBox.ContextMenu = new ContextMenu();
        }

        #endregion

        #region - - Приватные методы - -

        /// <summary>
        /// Расчитать импедансы для диапазона частот.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void CreateFrequencyButton_Click(object sender, EventArgs e)
        {
            NumberBoxConstraintTools.ChangeSeparator(startValueBox);
            NumberBoxConstraintTools.ChangeSeparator(intervalBox);
            NumberBoxConstraintTools.ChangeSeparator(countBox);

            var startValue = double.Parse(startValueBox.Text);
            var interval = double.Parse(intervalBox.Text);
            var count = uint.Parse(countBox.Text);

            if (!ValueConstraintTools.IsCorrectFrequency(startValue, interval, count)) return;

            _frequencies = new List<double>();

            for(var index = 0; index < count; index++)
            {
                _frequencies.Add(startValue + index * interval);
            }

            var circuit = ((CreateForm)Owner).Circuit;

            _impedancies = circuit.CalculateZ(_frequencies);
            circuitGridView.Rows.Clear();

            for (var index = 0; index < _impedancies.Count; index++)
            {
                circuitGridView.Rows.Add(_frequencies[index], _impedancies[index]);
            }
        }

        /// <summary>
        /// Подготовить текстовое поле к вводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            NumberBoxConstraintTools.Enter(sender);
        }

        /// <summary>
        /// Подготовить текстовое поле к выводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            NumberBoxConstraintTools.Leave(sender);
        }

        /// <summary>
        /// Ограничить ввод символов в текстовое поля для double.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void DoubleTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBoxConstraintTools.PressDouble(e, ((TextBox)sender).Text);
        }

        /// <summary>
        /// Ограничить ввод символов в текстовое поля для int.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void IntTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBoxConstraintTools.PressInt(sender, e);
        }

        #endregion
    }
}
