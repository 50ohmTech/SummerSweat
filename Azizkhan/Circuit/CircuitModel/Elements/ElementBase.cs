using System;
using System.Numerics;

namespace CircuitModel.Elements
{
    /// <summary>
    ///     Базовый класс элемента
    /// </summary>
    public abstract class ElementBase
    {
        /// <summary>
        ///     Конструктор базовой сущности
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public ElementBase(double value, string name)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        ///     Метод для расчёта импеданса
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        #region --- Поля ---

        /// <summary>
        ///     Имя
        /// </summary>
        private string _name;

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        #endregion --- Поля ---

        #region --- Свойства ---

        /// <summary>
        ///     Уникальное имя элемента
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name =
                value ?? throw new ArgumentNullException("Имя не может быть пустым!");
        }

        /// <summary>
        ///     Номинал элемента
        /// </summary>
        public double Value
        {
            get => Value;
            set
            {
                if (value > 0)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentException(
                        "Номинал элемента не должен быть меньше или равен 0!");
                }
            }
        }

        /// <summary>
        ///     Вернуть тип элемента
        /// </summary>
        public abstract ElementType Type { get; }

        #endregion --- Свойства ---
    }
}