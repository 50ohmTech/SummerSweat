using System;
using System.Numerics;

namespace Model.Elements
{
    //TODO: Элементы и цепи разнести по отдельным подпапкам в проекте для удобной навигации
    //+
    /// <summary>
    /// Элемент электрической цепи.
    /// </summary>
    public abstract class ElementBase
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

            set
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
            }   
        }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса ElementBase.
        /// </summary>
        /// <param name="name">Имя элемента.</param>
        /// <param name="value">Номинал элемента.</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns>Комплексное значение импеданса.</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}
