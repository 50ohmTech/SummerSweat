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
        ///     Свойство для работы с типом пассивных элементов
        /// </summary>
        public string Type => "Катушка индуктивности";

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _inductance;
            set
            {
                ValidationTools.IsCorrectParameter(value);
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
        ///     Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="frequency"> Частота </param>
        /// <returns> Значение комплексного сопротивления элемента</returns>
        public Complex CalculateImpedance(double frequency)
        {
            return new Complex(0, 2 * Math.PI * frequency * _inductance);
        }

        #endregion
    }
}