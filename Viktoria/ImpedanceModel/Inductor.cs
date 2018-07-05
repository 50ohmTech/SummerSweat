using System;
using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Катушка индуктивности
    /// </summary>
    public class Inductor : IElement
    {
        #region -- Поля --

        /// <summary>
        ///     Сопротивление катушки индуктивности
        /// </summary>
        private double _inductance;

        #endregion

        #region -- Свойства --

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _inductance;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _inductance = value;
            }
        }

        #endregion

        #region -- Публичные методы --

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public Inductor(double inductanceValue)
        {
            Parameter = inductanceValue;
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления для w
        /// </summary>
        public Complex GetImpedanceUsingAngularFrequency(double w)
        {
            return Complex.ImaginaryOne * w * _inductance;
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления для f
        /// </summary>
        public Complex GetImpedanceUsingFrequency(double f)
        {
            return 2 * Math.PI * f * _inductance;
        }

        /// <summary>
        ///     Переопределение ToString для вывода названия элемента
        /// </summary>
        public override string ToString()
        {
            return "Inductor";
        }

        #endregion
    }
}