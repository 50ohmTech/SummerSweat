using System;
using System.Numerics;
using Model.Elements.Checks;

//TODO: цепи и элементы должны быть в разных папках
namespace Model.Elements
{
    /// <summary>
    ///     Конденсатор.
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="capacity">Емкость.</param>
        public Capacitor(string name, double capacity) : base(name, capacity)
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
            Calculation.CheckFrequencies(frequency);
            double valueZ = 1 / (2 * Math.PI * frequency * Value);
            return new Complex(0, valueZ);
        }

        #endregion
    }
}