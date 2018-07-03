using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace Model.PropertyGrid
{
    /// <summary>
    ///     Вычисления для PropertyGrid
    /// </summary>
    public sealed class Calculations
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        public Calculations()
        {
            Frequencies = new List<Frequency>();
            Impedances = new List<Complex>();
        }

        [DisplayName("Частоты")]
        [Description("Список частот, на основе которых высчитываются импедансы.")]
        [Category("Данные для расчета")]
        public List<Frequency> Frequencies { get; set; }

        [DisplayName("Импедансы")]
        [Description(
            "Рассчитанные значения импедансов для каждой частоты, которую задал пользователь.")]
        [Category("Результаты")]
        public List<Complex> Impedances { get; set; }

        public double[] GetFrequencies()
        {
            List<double> frequencies = new List<double>();
            foreach (Frequency frequency in Frequencies)
            {
                frequencies.Add(frequency.Value);
            }

            return frequencies.ToArray();
        }
    }
}