using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Резистор.
    /// </summary>
    internal class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        /// <param name="name"> Название элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public Resistor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        /// <param name="frequency"> Частота. </param>
        /// <returns> Значение комплексного сопротивления элемента. </returns>
        /// <remarks>
        ///     Входные параметры не используются при рассчете
        ///     комплексного сопротивления резистора.
        /// </remarks>
        public override Complex CalculateZ(double frequency)
        {
            return Value;
        }

        #endregion
    }
}