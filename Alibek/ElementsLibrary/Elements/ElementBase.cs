using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace ElementsLibrary.Elements
{
    //TODO: По заданию в минимальной версии должны быть еще событие ValueChanged!
    //сделал
    /// <summary>
    ///     Базовый класс элемента <see cref="ElementBase" />
    /// </summary>
    public abstract class ElementBase : INode
    {
        #region Private fields

        /// <summary>
        ///     Имя элемента
        /// </summary>
        private string _name;

        /// <summary>
        ///     Значение номинала
        /// </summary>
        private double _value;

        #endregion

        #region Properties

        /// <summary>
        ///     Свойство номинала(задает и возвращает значение элемента)
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _value = value;
            }
        }

        /// <summary>
        ///     Свойство имени элемента(задает и возвращает имя элемента)
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Задайте имя!");
        }

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        #endregion

        public event EventHandler<ValueChangedEvent> ValueChanged;

        #region Constructor

        /// <summary>
        ///     Конструктор класса <see cref="ElementBase" />
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение элемента</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Абстрактный метод для расчета импеданса элемента <see cref="CalculateZ" />
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}