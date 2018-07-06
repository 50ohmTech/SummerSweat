using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model.Calculations
{
    public class Calculations
    {
        private double _frequency = 1;

        public double Frequency
        {
            get => _frequency;
            set
            {
                if (value < 1 || value > 1000000000000)
                {
                    throw new ArgumentException(
                        "Частота может иметь значение только от 1 Гц. до 1 ТГц.");
                }
                _frequency = value;
            }
        }

        public Complex Impedance { get; set; }
    }
}
