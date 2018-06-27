using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CircuitModel
{
    public sealed class Calculations
    {
        [DisplayName("Частоты")]
        [Description("Список частот для расчёта импедансов.")]
        [Category("Данные для расчета")]
        public List<double> Frequencies { get; set; }

        [DisplayName("Импедансы")]
        [Description("Результаты для каждой частоты")]
        [Category("Результаты")]
        public List<Complex> Impedances { get; set; }

        public Calculations()
        {
            Frequencies = new List<double>();
            Impedances = new List<Complex>();
        }
    }
}
