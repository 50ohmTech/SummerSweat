using System.Numerics;

namespace Circuit
{
    /// <summary>
    ///     Базовый класс элемента
    /// </summary>
    public abstract class ElementBase
    {
        /// <summary>
        ///     Уникальное имя элемента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Номинал элемента
        /// </summary>
        public abstract double Value { get; set; }

        /// <summary>
        ///     Метод для расчёта импеданса
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);
    }
}