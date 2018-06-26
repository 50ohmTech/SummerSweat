using System;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Элемент электрической цепи.
    /// </summary>
    public abstract class Element
    {
        #region - - Поля - -

        /// <summary>
        /// Имя элемента.
        /// </summary>
        private string _name;

        /// <summary>
        /// Номинал элемента.
        /// </summary>
        private double _value;

        #endregion

        #region - - Свойства - -

        /// <summary>
        /// Возвращаеет и задает имя элемента.
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
        /// Возвращаеет и задает номинал элемента.
        /// </summary>
        public double Value
        {
            get => _value;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                _value = value;
                ValueChanged?.Invoke(this, new ChangedEventArgs(_value));
            }   
        }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса Element.
        /// </summary>
        /// <param name="name"> Имя элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public Element(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency"> Частота сигнала. </param>
        /// <returns> Комплексное значение импеданса. </returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region – – События – –

        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event EventHandler<ChangedEventArgs> ValueChanged;

        #endregion
    }
}
