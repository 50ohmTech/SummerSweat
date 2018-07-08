﻿using System;
using System.Numerics;

namespace ElementsLibrary
{
    /// <summary>
    /// Базовый класс элемента
    /// </summary>
    public abstract class ElementBase
    {
        /// <summary>
        /// Имя элемента
        /// </summary>
        private string _name;

        /// <summary>
        /// Значение номинала
        /// </summary>
        private double _value;

        /// <summary>
        /// Свойство номинала(задает и возвращает значение элемента)
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
        /// Свойство имени элемента(задает и возвращает имя элемента)
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException("Задайте имя!");
        }

        /// <summary>
        /// Абстрактный метод для расчета импеданса элемента <see cref="CalculateZ"/>
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Комплексное значение импеданса</returns>
        public abstract Complex CalculateZ(double frequency);

        /// <summary>
        /// Конструктор класса <see cref="ElementBase"/>
        /// </summary>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Значение элемента</param>
        protected ElementBase(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
