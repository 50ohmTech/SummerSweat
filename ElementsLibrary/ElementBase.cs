using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Numerics;

namespace ElementsLibrary
{
    public abstract class ElementBase
    {
        private string _name;
        private double _value;

        public double Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                _value = value;
            }
            
        }

        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Задайте имя!");
        }

        public abstract Complex CalculateZ(double frequency);

        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }


    }
}
