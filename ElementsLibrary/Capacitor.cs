using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace ElementsLibrary
{
    public class Capacitor : ElementBase
    {
        public Capacitor(string name, double value) : base(name, value)
        {

        }

        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }
            return new Complex(0, -1 /2 * Math.PI * frequency * Value);
        }
    }
}
