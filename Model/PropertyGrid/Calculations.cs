using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model.PropertyGrid
{
    public sealed class Calculations
    {
        [DisplayName("Частоты")]
        [Description("Список частот, на основе которых высчитываются импедансы.")]
        [Category("Данные для расчета")]
        public List<double> Frequencies { get; set; }

        [DisplayName("Импедансы")]
        [Description("Рассчитанные значения импедансов для каждой частоты, которую задал пользователь.")]
        [Category("Результаты")]
        public List<Complex> Impedances { get; set; }

        public Calculations()
        {
            Frequencies = new List<double>();
            Impedances = new List<Complex>();
        }
    }
}