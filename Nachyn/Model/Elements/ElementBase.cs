﻿using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Checks;
using Model.Enums;
using Model.Events;

namespace Model.Elements
{
    /// <summary>
    ///     Базовый элемент эл. элементов.
    /// </summary>
    public abstract class ElementBase : ICircuitNode
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
                    throw new ArgumentOutOfRangeException(nameof(Name),"Имя не может быть пустым.");
                }

                if (value.Contains(" "))
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), "Имя не может содержать пробелы.");
                }

                if (value.Length > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), "Имя не может содержать более 5 символов.");
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

                Checks.Check.CheckFrequencies(value);
                _value = value;
                ValueChanged?.Invoke(this, new ElementValueEventArgs
                    (Name, _value));
            }
            get => _value;
        }

        /// <summary>
        ///     Родитель.
        /// </summary>
        public ICircuitNode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<ICircuitNode> Nodes { get; } = new List<ICircuitNode>();

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
        ///     Возвращает символ элемента.
        /// </summary>
        /// <returns>Тип узла.</returns>
        public static string GetSymbol(NodeType nodeType)
        {
            switch (nodeType)
            {
                case NodeType.Resistor:
                    return "R";
                case NodeType.Inductor:
                    return "L";
                case NodeType.Capacitor:
                    return "C";
                default:
                    return "?";
            }
        }

        #endregion
    }
}