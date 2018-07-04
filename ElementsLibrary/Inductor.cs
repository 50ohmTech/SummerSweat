using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    public class Inductor : ElementBase
    {
        public Inductor(string name, double value) : base(name, value)
        {

        }

        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }
            return new Complex(0, 2 * Math.PI * Value);
        }
    }
}
