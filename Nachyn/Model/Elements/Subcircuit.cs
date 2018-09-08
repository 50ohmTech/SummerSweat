using System.Collections.Generic;
using System.Numerics;

namespace Model.Elements
{
    /// <summary>
    ///     Подцепь
    /// </summary>
    public abstract class Subcircuit : INode
    {
        /// <summary>
        ///     Уникальный идентификатор
        /// </summary>
        private static int _id;

        /// <summary>
        ///     Конструктор
        /// </summary>
        protected Subcircuit()
        {
            _id++;
        }

        /// <summary>
        ///     Уникальный идентификатор
        /// </summary>
        private int Id { get; } = _id;

        /// <summary>
        ///     Дочерние узлы
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>
        ///     Рассчитать импеданс
        /// </summary>
        /// <param name="frequency">Частота</param>
        /// <returns>Импеданс</returns>
        public abstract Complex CalculateZ(double frequency);
    }
}