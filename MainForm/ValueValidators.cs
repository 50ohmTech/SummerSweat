using System;
using System.Windows.Forms;
using System.Globalization;

namespace MainForm
{
    /// <summary>
    /// Инструменты для проверки значений, вводимых в калькулятор импеданса.
    /// </summary>
    public class ValueValidators
    {
        #region ~ Приватные методы ~

        /// <summary>
        /// Проверка значений на границы.
        /// </summary>
        /// <param name="value"> Значение. </param>
        /// <param name="min"> Минимум. </param>
        /// <param name="max"> Максимум. </param>
        /// <param name="type"></param>
        /// <returns> Входит ли в границы. </returns>
        private static bool IsCorrectRangeParametr(double value, double min, double max,
            string type)
        {
            if (value >= min && value <= max)
            {
                return true;
            }

            MessageBox.Show(
                type + " для всех элементов должно быть\nне менее " + min + " и не более " + max + ".",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Проверка на ввод целых чисел.
        /// </summary>
        public static void PressInt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || char.IsDigit(e.KeyChar) &&
                ((TextBox)sender).Text.Length < 4)
            {
                return;
            }

            e.Handled = true;
        }

        /// <summary>
        /// Проверка на ввод вещественных значений.
        /// </summary>
        public static void PressDouble(KeyPressEventArgs e, string text)
        {
            var separator = NumberFormatInfo.CurrentInfo
                .NumberDecimalSeparator;

            if (text.IndexOf(separator, StringComparison.Ordinal) != -1)
            {
                e.Handled = true;
                return;
            }

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if (e.KeyChar.ToString() == separator)
            {
                return;
            }

            e.Handled = true;
        }

        /// <summary>
        /// Проверка значений на границы.
        /// </summary>
        /// <param name="value"> Проверяемое значение. </param>
        /// <returns> Корректное ли значение. </returns>
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
                minElementValue + " и не более " +
                maxElementValue,
                "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        /// <summary>
        /// Проверка частот на границы.
        /// </summary>
        /// <param name="startValue"> Начальное значение. </param>
        /// <param name="interval"> Интервал. </param>
        /// <param name="count"> Количество значений. </param>
        /// <returns></returns>
        public static bool IsCorrectFrequency(double startValue, double interval,
            uint count)
        {
            const double maxStartValue = 1000000000000.0;
            const double minStartValue = 1.0;

            const double maxInterval = 10000000000.0;
            const double minInterval = 1.0;

            const double maxCount = 1000;
            const double minCount = 1;

            return IsCorrectRangeParametr(startValue, minStartValue, 
                        maxStartValue, "Начальное значение диапазона") &&
                   IsCorrectRangeParametr(interval, minInterval,
                       maxInterval, "Интервал диапазона") &&
                   IsCorrectRangeParametr(count, minCount,
                       maxCount, "Количество значений диапазона");
        }

        /// <summary>
        /// Замена символа-разделителя.
        /// </summary>
        /// <param name="valueBox"> Значение символа. </param>
        public static void ChangeSeparator(TextBox valueBox)
        {
            if (valueBox.Text == NumberFormatInfo.CurrentInfo
                    .NumberDecimalSeparator)
            {
                valueBox.Text = "0";
            }
        }

        /// <summary>
        /// Подготовка поля к вводу значения.
        /// </summary>
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
        /// Подготовка поля в выводу значения.
        /// </summary>
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

        #endregion
    }
}
