using System.Numerics;

namespace CircuitLibrary.Elements
{
    /// <summary>
    ///     Резистор
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса Resistor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Resistor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            CheckFrequency.CheckFrequencies(frequency);

            return new Complex(Value, 0);
        }

        #endregion
    }
}