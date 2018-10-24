using System;
using System.Globalization;
using System.Windows.Forms;

namespace MainForm
{
    /// <summary>
    ///     Инструменты для валидации текстбоксов
    /// </summary>
    public class ValueValidators
    {
        #region Private methods

        /// <summary>
        ///     Проверка на границы значений
        /// </summary>
        private static bool IsCorrectRangeParametr(double value, double min, double max,
            string type)
        {
            if (value >= min && value <= max)
            {
                return true;
            }

            MessageBox.Show(
                type + " должно быть\nне менее " + min + " и не более " + max,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Ввод вещественных значений
        /// </summary>
        /// <param name="e">Параметры события</param>
        /// <param name="text">Текст</param>
        public static void PressDouble(KeyPressEventArgs e, string text)
        {
            var separator = NumberFormatInfo.CurrentInfo
                .NumberDecimalSeparator;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back)
            {
                return;
            }

            if (text.IndexOf(separator, StringComparison.Ordinal) != -1)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar.ToString() == separator)
            {
                return;
            }

            e.Handled = true;
        }

        /// <summary>
        ///     Ввод целых значений
        /// </summary>
        /// <param name="sender">Обьект вызывающий событие</param>
        /// <param name="e">Параметры события</param>
        public static void PressInt(object sender, KeyPressEventArgs e)
        {
            const double MaxLength = 4;

            if (e.KeyChar == (char) Keys.Back || char.IsDigit(e.KeyChar) &&
                ((TextBox) sender).Text.Length < MaxLength)
            {
                return;
            }

            e.Handled = true;
        }

        //TODO: метод должен принимать на вход сразу TextBox, а явное преобразование должно происходить в точке вызова метода
        /// <summary>
        ///     Функция подготавливающая поле к вводу.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        public static void Enter(object sender)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            if (textBox.Text == "0")
            {
                textBox.Text = string.Empty;
            }
        }

        //TODO: аналогично методу выше.
        /// <summary>
        ///     Функция подготавливающая поле к выводу.
        /// </summary>
        /// <param name="sender">Обьект который вызвал событие</param>
        public static void Leave(object sender)
        {
            if (!(sender is TextBox textBox))
            {
                return;
            }

            if (textBox.Text == string.Empty)
            {
                textBox.Text = "0";
            }
        }

        /// <summary>
        ///     Заменить символ-разделитель.
        /// </summary>
        /// <param name="valueBox">Значение в текстбоксе</param>
        public static void ChangeSeparator(TextBox valueBox)
        {
            if (valueBox.Text == NumberFormatInfo.CurrentInfo
                    .NumberDecimalSeparator)
            {
                valueBox.Text = "0";
            }
        }

        /// <summary>
        ///     Проверка значений на границы
        /// </summary>
        /// <param name="value">Значение(double)</param>
        /// <returns>Bool значение</returns>
        public static bool IsCorrectNominal(double value)
        {
            const double minValue = 0.000001;
            const double maxValue = 100000.0;

            if (value >= minValue && value <= maxValue)
            {
                return true;
            }

            MessageBox.Show(
                "Номинал элемента должен быть\n больше " +
                minValue + " и не превышать " +
                maxValue,
                "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        /// <summary>
        ///     Проверка частоты на границы
        /// </summary>
        /// <param name="startValue">Начальное значение</param>
        /// <param name="interval">Шаг</param>
        /// <param name="count">Конечное значение</param>
        /// <returns>Bool значение</returns>
        public static bool IsCorrectFrequency(double startValue, double interval,
            uint count)
        {
           
            const double maxStepValue = 10000000000.0;
            const double minStepValue = 0.01;
            const double maxStartValue = 1000000000000.0;
            const double minStartValue = 1.0;
            const double maxEndValue = 1000;
            const double minEndValue = 1;


            return IsCorrectRangeParametr(count, minEndValue,
                       maxEndValue, "Конечное значение интервала") &&
                   IsCorrectRangeParametr(startValue, minStartValue,
                       maxStartValue, "Начальное значение интервала") &&
                   IsCorrectRangeParametr(interval, minStepValue,
                       maxStepValue, "Шаг диапазона");
        }

        #endregion
    }
}