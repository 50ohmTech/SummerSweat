using System.Numerics;
using Model.Elements.Checks;

namespace Model.Elements
{
    /// <summary>
    ///     Резистор.
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="resistance">Сопротивление.</param>
        public Resistor(string name, double resistance) : base(name, resistance)
        {
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента.
        /// </summary>
        /// <param name="frequency">Частоста.</param>
        /// <returns>Комплексное сопротивление.</returns>
        public override Complex CalculateZ(double frequency)
        {
            Calculations.CheckFrequencies(frequency);

            return new Complex(Value, 0);
        }

        #endregion
    }
}