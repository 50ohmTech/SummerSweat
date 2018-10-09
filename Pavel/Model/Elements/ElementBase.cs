#region

using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Events;

#endregion

namespace Model.Elements
{
    /// <summary>
    ///     Элемент цепи
    /// </summary>
    public abstract class ElementBase : INode
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Название элемента.
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
        ///     Возвращает и задает название элемента.
        /// </summary>
        public string Name
        {
            get => _name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Название элемента не может быть пустым или заполненным символами-разделителями");
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Возвращает и задает значение элемента.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Значение должно быть больше нуля");
                }

                _value = value;
                ValueChanged?.Invoke(this, new ElementEventArgs
                    (Name, _value));
            }
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

        #region Events

        /// <summary>
        ///     Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event EventHandler<ElementEventArgs> ValueChanged;

        /// <summary>
        ///     Рассчет импеданса.
        /// </summary>
        /// <param name="frequency">Частота сигнала.</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор класса Element.
        /// </summary>
        /// <param name="name"> Имя элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion
    }
}