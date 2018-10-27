using System;
using System.Collections.Generic;
using System.Numerics;
using ElementsLibrary.Circuits;
using ElementsLibrary.Elements;

namespace ElementsLibrary
{
    //TODO: ВЖУХ! И 22 октября куча готовых классов и форм за один коммит.
    // Код скопирован и целыми кусками совпадает с кодом Шагаева. Удалить и написать свой
    //Ну чето попытался переписать, но так как логика одна кардинально ничего не поменялось.
    /// <summary>
    ///     Класс электрическая цепь Circuit
    /// </summary>
    public class Circuit
    {
      
        #region Properties

        /// <summary>
        ///     Корень дерева
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Метод очистки
        /// </summary>
        public void Clean()
        {
            Root = null;
        }

        /// <summary>
        ///     Метод расчета полного импеданса цепи
        /// </summary>
        /// <param name="frequencies">Частота</param>
        /// <returns>Импеданс всей цепи</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            var impedance = new List<Complex>();

            for (int index = 0; index < frequencies.Length; index++)
            {
                double frequency = frequencies[index];
                impedance.Add(Root.CalculateZ(frequency));
            }

            return impedance;
        }

        /// <summary>
        ///     Функция добавления
        /// </summary>
        /// <param name="node">Текущая нода</param>
        /// <param name="nextNode">Следующая нода</param>
        public void AddNodes(INode node, INode nextNode)
        {
            if (nextNode == null)
            {
                throw new ArgumentNullException(nameof(nextNode), "Пустая нода!");
            }
            if (IsEmpty())
            {
                Root = nextNode;
                return;
            }
            
            if (node is SubCircuitBase circuit)
            {
                if (circuit.Nodes == null)
                {
                    throw new InvalidOperationException("Дочерние узлы не должны быть null!");
                }
                circuit.Nodes.Add(nextNode);
                if (nextNode is SubCircuitBase nextSubcircuit)
                {
                    nextSubcircuit.Parent = circuit;
                }
                if (nextNode is ElementBase nextElementBase)
                {
                    nextElementBase.Parent = circuit;
                }
            }
        }

        /// <summary>
        ///     Проверка на null
        /// </summary>
        /// <returns>Возвращает bool значение</returns>
        public bool IsEmpty()
        {
            return Root == null;
        }

        #endregion
    }
}