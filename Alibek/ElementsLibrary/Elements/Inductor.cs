using System;
using System.Numerics;

namespace ElementsLibrary
{
    /// <summary>
    ///     Класс катушка индуктивности <see cref="Inductor" />
    /// </summary>
    public class Inductor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса <see cref="Inductor" />
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение элемента</param>
        public Inductor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод расчета импенданса в катушке индуктивности <see cref="CalculateZ" />
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплесное значение импеданса</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }

            return new Complex(0, 2 * Math.PI * Value);
        }

        #endregion
    }
}