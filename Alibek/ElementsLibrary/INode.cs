using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
   public interface INode
    {
        /// <summary>
        /// Главный узел
        /// </summary>
        INode Parent { get; }

        /// <summary>
        /// Дочерние узлы
        /// </summary>
        List<INode> Nodes { get; }

        /// <summary>
        /// Тип подключения
        /// </summary>
        NodeType ConnectionType { get; set; }

        /// <summary>
        /// Метод расчета импеданса в ноде <see cref="CalculateZ"/>
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns>Комплексное значение импеданса</returns>
        Complex CalculateZ(double frequency);
    }
}
