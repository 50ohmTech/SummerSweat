using System;
using System.Numerics;


namespace Yulya
{
    /// <summary>
    /// Класс элемента электрической цепи (Element).
    /// </summary>
    public abstract class Element
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
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает номинал элемента.
        /// </summary>
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
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
        public Element(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Расчитать импеданс элемента.
        /// </summary>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns>Комплексное значение импеданса.</returns>
        public abstract Complex GetImpedance(double frequency);

        #endregion
    }
}
