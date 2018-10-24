using System;
using System.Collections.Generic;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Делегат хранящий подписчиков события ValueChanged.
    /// </summary>
    /// <param name="value"> Изменённое значение. </param>
    /// <param name="сhangedElement"> Изменённый элемент. </param>
    public delegate void ValueEventHandler(object value, object сhangedElement);

    /// <summary>
    /// Базовый класс элемента.
    /// </summary>
    public abstract class ElementBase : INode
    {
        #region ~ Поля ~

        /// <summary>
        /// Название элемента.
        /// </summary>
        private string _name;

        /// <summary>
        /// Значение элемента.
        /// </summary>
        private double _value;

        #endregion

        #region ~ Конструктор ~

        /// <summary>
        /// Конструктор базового элемента.
        /// </summary>
        /// <param name="name"> Название элемента. </param>
        /// <param name="value"> Значение элемена. </param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region ~ Публичные методы ~

        /// <summary>
        /// Расчет импеданса.
        /// </summary>
        /// <param name="frequency"> Значение частоты. </param>
        /// <returns> Комплексное сопротивление. </returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region ~ Свойства ~

        /// <summary>
        /// Вернуть и задать название элемента.
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name),
                        "Название элемента не может быть пустым.");
                }

                if (value.Contains(" "))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name),
                        "В названии элемента не должны использоваться пробелы.");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Вернуть дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        /// Вернуть и задать родителя элемента.
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        /// Вернуть и задать значение элемента.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(value));
                }
                _value = value;
            }
        }

        #endregion
<<<<<<< HEAD
=======

        #region ~ События ~

        //TODO: Событие создано, но нигде не зажигается. Должно зажигаться в сеттере Value
        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event ValueEventHandler ValueChanged;

        #endregion
>>>>>>> 39f4ca1a6ec16c74848e25ab7f714f32790d1aa0
    }
}
