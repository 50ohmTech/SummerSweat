using System;
using System.Numerics;

namespace CircuitLibrary.Elements
{
    /// <summary>
    ///     Конденсатор
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Properties

        /// <inheritdoc />
        public override NodeType Type { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор класса Capacitor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Capacitor(string name, double value) : base(name, value)
        {
            Type = NodeType.Capacitor;
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

            return new Complex(0, 1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}