using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи.
    /// </summary>
    internal abstract class ElementBase : INode
    {
        #region Private fields

        /// <summary>
        ///     Название элемента.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал элемента.
        /// </summary>
        private double _value;

        #endregion

        #region Properties

        /// <summary>
        ///     Свойство для работы с названием элемента.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Название элемента не может быть пустым");
                }

                _name = value;
            }
        }

        /// <summary>
        ///     Свойство для работы с номиналом элемента.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                ValidationTools.IsCorrectValue(value);
                _value = value;
            }
        }

        /// <summary>
        ///     Список дочерних нод.
        /// </summary>
        public List<INode> Nodes { get; set; }

        /// <summary>
        ///     Нода - родитель.
        /// </summary>
        public INode Parent { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        /// <param name="name"> Название элемента. </param>
        /// <param name="value"> Номинал элемента. </param>
        public ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        /// <param name="frequency"> Частота. </param>
        /// <returns> Значение комплексного сопротивления элемента. </returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion
    }
}