using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Резистор
    /// </summary>
    public class Resistor : IElement
    {
        #region -- Поля --

        /// <summary>
        ///     Сопротивление резистора.
        /// </summary>
        private double _resistance;

        #endregion

        #region -- Свойства --


        /// <summary>
        ///     Свойство для работы с типом пассивных элементов
        /// </summary>
        public string Type => "Резистор";

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _resistance;
            set
            {
                ValidationTools.IsCorrectParameter(value);
                _resistance = value;
            }
        }

        #endregion

        #region -- Публичные методы --

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public Resistor(double resistanceValue)
        {
            Parameter = resistanceValue;
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления
        /// </summary>
        /// <param name="frequency"> Частота </param>
        /// <returns> Значение комплексного сопротивления элемента</returns>
        /// <remarks>
        ///     Входные параметры не используются при рассчете
        ///     комплексного сопротивления резистора.
        /// </remarks>
        public Complex CalculateImpedance(double frequency)
        {
            return _resistance;
        }

        #endregion
    }
}