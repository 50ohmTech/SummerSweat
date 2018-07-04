using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public class Resistor : ElementBase
    {
        public Resistor(double value, string name) : base(name, value)
        {

        }

        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }
            return new Complex(Value , 0);
        }
    }
}
