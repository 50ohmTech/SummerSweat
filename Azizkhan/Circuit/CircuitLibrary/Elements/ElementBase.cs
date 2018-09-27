using System;
using System.Collections.Generic;
using System.Numerics;
using CircuitLibrary.Events;

namespace CircuitLibrary.Elements
{
    /// <summary>
    ///     Базовый класс элемента
    /// </summary>
    public abstract class ElementBase : INode
    {
        #region Constants

        /// <summary>
        ///     Минимальное значение номинала элемента
        /// </summary>
        private const double _MINVALUE = 0.000001;

        /// <summary>
        ///     Максимальное значение номинала элемента
        /// </summary>
        private const double _MAXVALUE = 1000000000000;

        #endregion

        #region Fields

        #region Private fields

        /// <summary>
        ///     Название элемента
        /// </summary>
        private string _name;

        /// <summary>
        ///     Значение элемента
        /// </summary>
        private double _value;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Вернуть/установить название элемента
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name));
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Вернуть/установить значение элемента
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (double.IsNaN(value) || double.IsInfinity(value))
                {
                    throw new ArgumentException(nameof(value));
                }

                if (value < _MINVALUE)
                {
                    throw new ArgumentException(nameof(value));
                }

                if (value > _MAXVALUE)
                {
                    throw new ArgumentException(
                        nameof(value));
                }

                if (value != _value)
                {
                    _value = value;
                    ValueChanged?.Invoke(this, new ValueChangedEventArgs
                        (Name, _value));
                }
            }
        }

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        ///     Родитель
        /// </summary>
        public INode Parent { get; set; }

        #endregion

        #region Events

        /// <summary>
        ///     Событие изменения номинала элемента
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор базового элемента
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}