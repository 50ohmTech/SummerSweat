using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор (сопротивление)
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор для создания резистора.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="resistance">Сопротивление</param>
        public Resistor(string name, double resistance) : base(name, resistance)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет комплексного сопротивления резистора.
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            return new Complex(Value, 0);
        }

        #endregion
    }
}