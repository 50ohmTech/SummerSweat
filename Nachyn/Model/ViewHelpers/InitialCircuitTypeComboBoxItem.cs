using System;
using Model.ViewHelpers.Enums;

namespace Model.ViewHelpers
{
    /// <summary>
    ///     Тип элемента в ComboBox'е.
    /// </summary>
    public sealed class InitialCircuitTypeComboBoxItem
    {
        #region Properties

        /// <summary>
        ///     Тип элемента.
        /// </summary>
        public InitialCircuitType Value { get; }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description
        {
            get
            {
                switch (Value)
                {
                    case InitialCircuitType.A:
                        return "Цепь A";
                    case InitialCircuitType.B:
                        return "Цепь B";
                    case InitialCircuitType.C:
                        return "Цепь C";
                    case InitialCircuitType.D:
                        return "Цепь D";
                    case InitialCircuitType.E:
                        return "Цепь E";
                    default:
                        throw new ArgumentException();
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="value">Тип элемента.</param>
        public InitialCircuitTypeComboBoxItem(InitialCircuitType value)
        {
            Value = value;
        }

        #endregion
    }
}