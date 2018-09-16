using System;
using System.Numerics;

namespace Model.Elements
{
    public abstract class ElementBase
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Имя элемента.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Значение элемента.
        /// </summary>
        private double _value;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Имя элемента.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(Name));
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Значение элемента.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException($"Значение {value}" +
                                                $" не является вещесвенным числом.");
                }

                if (value <= 0)
                {
                    throw new ArgumentException(
                        $"Значение {value} не может быть меньше или равно 0.");
                }

                _value = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="value">Значение</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Расчет комплексного сопротивления.
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>Комплексное сопротивление</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}