using System;
using System.Numerics;

namespace CircuitLibrary.Elements
{
    /// <summary>
    ///     Катушка индуктивности
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Properties

        /// <inheritdoc />
        public override NodeType Type { get; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор класса Inductor
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Номинал</param>
        public Inductor(string name, double value) : base(name, value)
        {
            Type = NodeType.Inductor;
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

            return new Complex(0, 2 * Math.PI * frequency * Value);
        }

        #endregion
    }
}