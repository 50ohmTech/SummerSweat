namespace CircuitLibrary
{
    /// <summary>
    ///     Enum для типов элементов цепи и соединений
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        ///     Parallel - параллельное соединение
        /// </summary>
        Parallel,

        /// <summary>
        ///     Serial - последовательное соединение
        /// </summary>
        Serial,

        /// <summary>
        ///     Resistor - резистор
        /// </summary>
        Resistor,

        /// <summary>
        ///     Inductor - катушка индуктивности
        /// </summary>
        Inductor,

        /// <summary>
        ///     Capacitor - конденсатор
        /// </summary>
        Capacitor
    }
}