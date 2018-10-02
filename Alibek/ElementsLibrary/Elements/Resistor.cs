using System;
using System.Numerics;


namespace ElementsLibrary
{
    /// <summary>
    ///     Класс резистор <see cref="Resistor" />
    /// </summary>
    public class Resistor : ElementBase
    {
        #region Constructor

        /// <summary>
        ///     Конструктор класса <see cref="Resistor" />
        /// </summary>
        /// <param name="value">Значение элемента</param>
        /// <param name="name">Имя элемента</param>
        public Resistor(double value, string name) : base(name, value)
        {
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод расчета импеданса в резисторе <see cref="CalculateZ" />
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public override Complex CalculateZ(double frequency)
        {
            if (frequency <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(frequency));
            }

            return new Complex(Value, 0);
        }

        #endregion
    }
}