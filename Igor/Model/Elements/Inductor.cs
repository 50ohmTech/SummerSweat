using System;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Индуктивность
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор для создание индуктивности.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="inductance">Индуктивность</param>
        public Inductor(string name, double inductance) : base(name, inductance)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет комплексного сопротивления индуктивности.
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        public override Complex CalculateZ(double frequency)
        {
            var valueZ = 2 * Math.PI * frequency * Value;
            return new Complex(0, valueZ);
        }

        #endregion
    }
}