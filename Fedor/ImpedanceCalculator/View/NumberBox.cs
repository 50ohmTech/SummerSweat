using System;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Обработчик элемента управления для чисел.
    /// </summary>
    public static class NumberBox
    {
        #region - - Публичные методы - -

        /// <summary>
        /// Ввести вещественное значение.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <param name="text">Текст элемента.</param>
        public static void PressDouble(KeyPressEventArgs e, string text)
        {
            var separator = System.Globalization.NumberFormatInfo.CurrentInfo
                .NumberDecimalSeparator;

            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back) return;

            if (text.IndexOf(separator, StringComparison.Ordinal) != -1)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar.ToString() == separator) return;

            e.Handled = true;
        }

        /// <summary>
        /// Ввести целочисленное значение.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        public static void PressInt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Back || char.IsDigit(e.KeyChar) &&
                ((TextBox) sender).Text.Length < 4)
                return;

            e.Handled = true;
        }

        /// <summary>
        /// Начать ввод символов.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        public static void Enter(object sender)
        {
            if (!(sender is TextBox textBox)) return;

            if (textBox.Text == "0")
            {
                textBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Закончить ввод символов.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        public static void Leave(object sender)
        {
            if (!(sender is TextBox textBox)) return;

            if (textBox.Text == string.Empty)
            {
                textBox.Text = "0";
            }
        }

        /// <summary>
        /// Заменить символ-разделитель.
        /// </summary>
        /// <param name="valueBox">Элемент управления текстового поля.</param>
        public static void ChangeSeparator(TextBox valueBox)
        {
            if (valueBox.Text == System.Globalization.NumberFormatInfo.CurrentInfo
                    .NumberDecimalSeparator)
            {
                valueBox.Text = "0";
            }
        }

        #endregion
    }
}
