using System;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Элемент цепи
    /// </summary>
    public abstract class Element
    {
        #region - - Поля - -

        /// <summary>
        /// Название элемента
        /// </summary>
        private string _name;

        /// <summary>
        /// Значение элемента
        /// </summary>
        private double _value;

        #endregion

        #region Свойства

        /// <summary>
        /// Возвращает и задает название элемента
        /// </summary>
        public string Name
        {
            get => _name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название элемента не может быть пустым или заполненным символами-разделителями");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает значение элемента
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Значение должно быть больше нуля");
                }
                _value = value;
            }
        }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса Element.
        /// </summary>
        /// <param name="name"> Имя элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public Element(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Рассчет импеданса
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region События

        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event EventHandler<ChangingEventArgs> ValueChanged;

        #endregion
    }
}
