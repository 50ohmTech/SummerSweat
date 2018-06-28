using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    ///     Сущность расчёты
    /// </summary>
    public sealed class Calculations
    {
        /// <summary>
        ///     Конструктор сущности расчёты
        /// </summary>
        public Calculations()
        {
            Frequencies = new List<double>();
            Impedances = new List<Complex>();
        }

        /// <summary>
        ///     Список частот для расчёта импедансов
        /// </summary>
        [DisplayName("Частоты")]
        [Description("Список частот для расчёта импедансов")]
        [Category("Данные для расчета")]
        public List<double> Frequencies { get; set; }

        /// <summary>
        ///     Результаты для каждой частоты
        /// </summary>
        [DisplayName("Импедансы")]
        [Description("Результаты для каждой частоты")]
        [Category("Результаты")]
        public List<Complex> Impedances { get; set; }
    }
}