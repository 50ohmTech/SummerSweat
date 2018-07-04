using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
   public class Circuit
    {
        public List<ElementBase> _elements;

        public Circuit(List<ElementBase> elements)
        {
            Elements = elements;
        }

        public List<ElementBase> Elements
        {
            get => _elements;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }

        public List<Complex> CalculateZ(List<double> frequencies)
        {
            if (_elements == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }
            var counter = 0;
            var impedance = new List<Complex>();
            foreach (var element in Elements)
            {
                foreach (var frequency in frequencies)
                {
                    impedance[counter] = element.CalculateZ(frequency);
                    counter++;
                }
            }
            return impedance;
        }
    }
}
