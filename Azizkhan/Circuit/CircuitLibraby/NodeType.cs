using System.ComponentModel;

namespace CircuitLibrary
{
    /// <summary>
    ///     Enum для типов элементов цепи и соединений
    /// </summary>
    public enum NodeType
    {
        [Description("Параллельное")] Parallel,
        [Description("Последовательное")] Serial,
        [Description("Резистор")] Resistor,
        [Description("Катушка")] Inductor,
        [Description("Конденсатор")] Capacitor
    }
}