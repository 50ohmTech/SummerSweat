using System;
using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Конденсатор
    /// </summary>
    public class Capacitor : IElement
    {
        #region -- Поля --

        /// <summary>
        ///     Сопротивление конденсатора.
        /// </summary>
        private double _capacitance;

        #endregion

        #region -- Свойства --

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _capacitance;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _capacitance = value;
            }
        }

        #endregion

        #region -- Публичные методы --

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public Capacitor(double capacitanceValue)
        {
            Parameter = capacitanceValue;
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления для w
        /// </summary>
        public Complex GetImpedanceUsingAngularFrequency(double w)
        {
            return -Complex.ImaginaryOne / (w * _capacitance);
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления для f
        /// </summary>
        public Complex GetImpedanceUsingFrequency(double f)
        {
            return -1 / (2 * Math.PI * f * _capacitance);
        }

        /// <summary>
        ///     Переопределение ToString для вывода названия элемента
        /// </summary>
        public override string ToString()
        {
            return "Capacitor";
        }

        #endregion
    }
}