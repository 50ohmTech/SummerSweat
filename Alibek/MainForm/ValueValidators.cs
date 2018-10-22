using System;
using System.Globalization;
using System.Windows.Forms;

namespace MainForm
{
    /// <summary>
    /// Инструменты для валидации текстбоксов
    /// </summary>
    public class ValueValidators
    {
        #region Private methods

        /// <summary>
        /// Проверка на границы значений
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool IsCorrectRangeParametr(double value, double min, double max,
            string type)
        {
            if (value >= min && value <= max)
            {
                return true;
            }

            MessageBox.Show(
                type + " должен (должно) быть\nне менее " + min + " и не более " + max,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Ввод вещественных значений
        /// </summary>
        /// <param name="e"></param>
        /// <param name="text"></param>
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
        /// Ввод целых значений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void PressInt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Back || char.IsDigit(e.KeyChar) &&
                ((TextBox) sender).Text.Length < 4)
            {
                return;
            }

            e.Handled = true;
        }
        /// <summary>
        /// Функция подготавливающая поле к вводу.
        /// </summary>
        /// <param name="sender"></param>
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

        /// <summary>
        /// Функция подготавливающая поле к выводу.
        /// </summary>
        /// <param name="sender"></param>
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
        /// Заменить символ-разделитель.
        /// </summary>
        /// <param name="valueBox"></param>
        public static void ChangeSeparator(TextBox valueBox)
        {
            if (valueBox.Text == NumberFormatInfo.CurrentInfo
                    .NumberDecimalSeparator)
            {
                valueBox.Text = "0";
            }
        }

        /// <summary>
        /// Проверка значений на границы
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCorrectNominal(double value)
        {
            const double minElementValue = 0.000001;
            const double maxElementValue = 100000.0;

            if (value >= minElementValue && value <= maxElementValue)
            {
                return true;
            }

            MessageBox.Show(
                "Номинал элемента должен быть\n больше " +
                minElementValue + " и не превышать " +
                maxElementValue,
                "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        /// <summary>
        /// Проверка частоты на границы
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="interval"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static bool IsCorrectFrequency(double startValue, double interval,
            uint count)
        {
            const double maxCount = 1000;
            const double minCount = 1;

            const double maxStartValue = 1000000000000.0;
            const double minStartValue = 1.0;

            const double maxInterval = 10000000000.0;
            const double minInterval = 0.01;

            return IsCorrectRangeParametr(count, minCount,
                       maxCount, "Количество значений диапазона") &&
                   IsCorrectRangeParametr(startValue, minStartValue,
                       maxStartValue, "Начальное значение диапазона") &&
                   IsCorrectRangeParametr(interval, minInterval,
                       maxInterval, "Интервал диапазона");
        }

        #endregion
    }
}