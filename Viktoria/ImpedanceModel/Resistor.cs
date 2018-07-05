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
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _resistance;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
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
        ///     Рассчет комплексного сопротивления для w
        /// </summary>
        /// <remarks> Входные параметры не используются при рассчете комплексного сопротивления резистора. </remarks>
        public Complex GetImpedanceUsingAngularFrequency(double w)
        {
            return _resistance;
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления для f
        /// </summary>
        /// <remarks> Входные параметры не используются при рассчете комплексного сопротивления резистора. </remarks>
        public Complex GetImpedanceUsingFrequency(double f)
        {
            return _resistance;
        }

        /// <summary>
        ///     Переопределение ToString для вывода названия элемента
        /// </summary>
        public override string ToString()
        {
            return "Resistor";
        }

        #endregion
    }
}