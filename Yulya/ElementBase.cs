using System;
using System.Numerics;


namespace Model
{
    /// <summary>
    /// Класс элемента электрической цепи (ElementBase).
    /// </summary>
    public abstract class ElementBase
    {
        #region Поля

        /// <summary>
        /// Имя элемента.
        /// </summary>
        private string _name;

        /// <summary>
        /// Номинал элемента.
        /// </summary>
        private double _value;

        #endregion

        #region Свойства

        /// <summary>
        /// Возвращает и задает имя элемента.
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Поле не может быть пустым.");
        }

        /// <summary>
        /// Возвращает и задает номинал элемента.
        /// </summary>
        public double Value
        {
            get => _value;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение должно быть больше нуля.");
                }
                _value = value;
            }
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса Element.
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

        #region События

        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion
    }
}
