namespace ElementsLibrary
{
    /// <summary>
    ///     Типы соединения в enumeration <see cref="NodeType" />
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        ///     Последовательное соединение
        /// </summary>
        Serial,

        /// <summary>
        ///     Параллельное соединение
        /// </summary>
        Parallel,

        /// <summary>
        ///     Катушка индуктивности
        /// </summary>
        Inductor,

        /// <summary>
        ///     Конденсатор
        /// </summary>
        Capacitor,

        /// <summary>
        ///     Резистор
        /// </summary>
        Resistor
    }
}