using System;

namespace Model.ComboBoxType
{
    /// <summary>
    ///     Тип элемента в ComboBox'е
    /// </summary>
    public sealed class ElementTypeComboBoxItem
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="value">Тип элемента</param>
        public ElementTypeComboBoxItem(ElementType value)
        {
            Value = value;
        }

        /// <summary>
        ///     Тип элемента
        /// </summary>
        public ElementType Value { get; }

        /// <summary>
        ///     Описание
        /// </summary>
        public string Description
        {
            get
            {
                switch (Value)
                {
                    case ElementType.Resistor:
                        return "Резистор";
                    case ElementType.Inductor:
                        return "Катушка";
                    case ElementType.Capacitor:
                        return "Конденсатор";
                    default:
                        throw new ArgumentException();
                }
            }
        }
    }
}