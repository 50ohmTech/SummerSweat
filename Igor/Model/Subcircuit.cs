using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Subcircuit : INode
    {
        private readonly int _global;

        private static int _id;

        /// <summary>
        ///     Родитель.
        /// </summary>
        public INode Parent { get; set; }

        /// <summary>
        ///     Дочерние узлы.
        /// </summary>
        public List<INode> Nodes { get; } = new List<INode>();

        /// <summary>ё
        /// Идентификатор.
        /// </summary>
        public int Id { get; } = _id;

        /// <summary>
        ///     Рассчет импеданса.
        /// </summary>
        /// <param name="frequency">Частота сигнала</param>
        /// <returns></returns>
        public abstract Complex CalculateZ(double frequency);

        /// <summary>
        /// 
        /// </summary>
        protected Subcircuit()
        {
            _id++;
        }
    }
}
