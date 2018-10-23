using System;
using System.Numerics;

namespace ElementsLibrary.Elements
{
    /// <summary>
    ///     Класс Конденсатор 
    /// </summary>
    public class Capacitor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса <see cref="Capacitor" />
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение элемента</param>
        public Capacitor(string name, double value) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод расчета импеданса в конденсаторе <see cref="CalculateZ" />
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }

            return new Complex(0, 1 / (2 * Math.PI * frequency * Value));
        }

        #endregion
    }
}