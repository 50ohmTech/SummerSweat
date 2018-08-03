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
        ///     Емкость конденсатора.
        /// </summary>
        private double _capacitance;

        #endregion

        #region -- Свойства --

        /// <summary>
        ///     Свойство для работы с типом пассивных элементов
        /// </summary>
        public string Type => "Конденсатор";

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _capacitance;
            set
            {
                ValidationTools.IsCorrectParameter(value);
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
        ///     Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="frequency"> Частота </param>
        /// <returns> Значение комплексного сопротивления элемента</returns>
        public Complex CalculateImpedance(double frequency)
        {
            return new Complex(0, -1 / (2 * Math.PI * frequency * _capacitance));
        }

        #endregion
    }
}