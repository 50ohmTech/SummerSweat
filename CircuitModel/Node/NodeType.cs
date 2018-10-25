using System;

namespace CircuitModel
{
    /// <summary>
    /// Типы соединений.
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// Последовательное соединение
        /// </summary>
        Serial,

        /// <summary>
        /// Параллельное соединение
        /// </summary>
        Parallel,

        /// <summary>
        /// Резистор
        /// </summary>
        Resistor,

        /// <summary>
        /// Катушка индуктивности
        /// </summary>
        Inductor,

        /// <summary>
        /// Конденсатор
        /// </summary>
        Capacitor
    }
}
