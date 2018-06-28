using System;
using System.Numerics;
using Model.Events;

namespace Model.Elements
{
    public abstract class ElementBase
    {
        private string _name;

        private double _value;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="branch">Ветвь</param>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        protected ElementBase(Branch branch, string name, double value = 0)
        {
            Name = name;
            Branch = branch;
            Value = value;
            branch.Elements.Add(this);
        }

        public Branch Branch { get; }

        /// <summary>
        ///     Имя элемента
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name));
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Номинал
        /// </summary>
        public double Value
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                var oldValue = _value;
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueArgs
                    ("Изменил(ось/ась/ся) " + ToString(), oldValue, _value));
            }
            get => _value;
        }

        public void Delete()
        {
            Branch.Elements.Remove(this);
        }

        /// <summary>
        ///     Обработчик события на изменение номинала
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;


        public abstract Complex CalculateZ(double frequency);
    }
}