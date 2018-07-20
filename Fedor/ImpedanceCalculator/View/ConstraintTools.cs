using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Класс, определяющий коректность значений.
    /// </summary>
    public static class ConstraintTools
    {
        #region -- Публичные статичные методы --

        /// <summary>
        /// Определить корректность диапазона частот.
        /// </summary>
        /// <param name="startValue">Начальное значение диапазона частот.</param>
        /// <param name="interval">Интервал диапазона частот.</param>
        /// <param name="count">Количество значений диапазона частот.</param>
        /// <returns>Корректность диапазона частот.</returns>
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

        /// <summary>
        /// Определить корректность номинала элемента.
        /// </summary>
        /// <param name="value">Номинал элемента.</param>
        /// <returns>Корректность номинала элемента.</returns>
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

        #endregion

        #region -- Приватные статичные методы --

        /// <summary>
        /// Определить корректность параметра диапазона.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <param name="type">Тип параметра.</param>
        /// <returns>Корректность параметра диапазона.</returns>
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
    }
}
