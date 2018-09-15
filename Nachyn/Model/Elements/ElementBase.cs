﻿using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements.Enums;
using Model.Elements.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Базовый элемент эл. элементов.
    /// </summary>
    public abstract class ElementBase : INode
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Имя.
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал.
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
        ///     Номинал.
        /// </summary>
        public double Value
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Value));
                }

                _value = value;
                ValueChanged?.Invoke(this, new ElementValueEventArgs
                    (Name, _value));
            }
            get => _value;
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
        ///     Событие на изменение номинала.
        /// </summary>
        public event EventHandler<ElementValueEventArgs> ValueChanged;

        /// <summary>
        ///     Расчитать комплексное сопротивление.
        /// </summary>
        /// <param name="frequency">Частота.</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="value">Номинал.</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        ///     Возвращает символ элемента
        /// </summary>
        /// <returns>Тип Элемента</returns>
        public static string GetSymbol(ElementType elementType)
        {
            switch (elementType)
            {
                case ElementType.Resistor:
                    return "R";
                case ElementType.Inductor:
                    return "L";
                case ElementType.Capacitor:
                    return "C";
                default:
                    return null;
            }
        }

        #endregion
    }
}