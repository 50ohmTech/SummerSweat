using System;
using Model.Elements.Enums;

namespace Model.ViewHelpers
{
    /// <summary>
    ///     Тип элемента в ComboBox'е.
    /// </summary>
    public sealed class ConnectionTypeComboBoxItem
    {
        #region Properties

        /// <summary>
        ///     Тип элемента.
        /// </summary>
        public ConnectionType Value { get; }

        /// <summary>
        ///     Описание.
        /// </summary>
        public string Description
        {
            get
            {
                switch (Value)
                {
                    case ConnectionType.Parallel:
                        return "Параллельное соединение";
                    case ConnectionType.Serial:
                        return "Последовательное соединение";
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
        public ConnectionTypeComboBoxItem(ConnectionType value)
        {
            Value = value;
        }

        #endregion
    }
}