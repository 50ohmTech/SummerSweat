#region

using System;
using System.Collections.Generic;
using System.Numerics;
using Model.Elements;
using Model.Elements.Checks;
using Model.Elements.Enums;

#endregion

namespace Model
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Fields

        #region Private fields

        /// <summary>
        ///     Корень цепи.
        /// </summary>
        private INode _root;

        #endregion

        #endregion

        #region Public methods

        /// <summary>
        ///     Рассчитать импедансы.
        /// </summary>
        /// <param name="frequencies">Частоты.</param>
        /// <returns>Импедансы.</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            Calculations.CheckFrequencies(frequencies);

            if (_root == null)
            {
                throw new NullReferenceException("В цепи нет элементов.");
            }

            List<Complex> impedances = new List<Complex>();

            foreach (double frequency in frequencies)
            {
                impedances.Add(_root.CalculateZ(frequency));
            }

            return impedances;
        }

        /// <summary>
        ///     Удалить элемент.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Удален ли элемент.</returns>
        public bool Remove(ElementBase element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (_root == null)
            {
                throw new NullReferenceException("В цепи нет элементов.");
            }

            if (element.Parent == _root)
            {
                if (_root.Nodes == null)
                {
                    throw new NullReferenceException("Дети корня были null.");
                }

                return _root.Nodes.Remove(element);
            }

            if (element.Parent is SubcircuitBase subcircuit &&
                subcircuit.Nodes.Count == 2 &&
                element.Parent != _root)
            {
                foreach (INode children in subcircuit.Nodes)
                {
                    if (children != element)
                    {
                        if (!subcircuit.Parent.Nodes.Remove(subcircuit))
                        {
                            throw new Exception("Ошибка удаления.");
                        }

                        subcircuit.Parent.Nodes.Add(children);

                        if (children is ElementBase childrenElementBase)
                        {
                            childrenElementBase.Parent = subcircuit.Parent;
                        }
                        else if (children is SubcircuitBase childrenSubcircuit)
                        {
                            childrenSubcircuit.Parent = subcircuit.Parent;
                        }
                        else
                        {
                            throw new Exception("Неизвестный родитель.");
                        }

                        return true;
                    }
                }
            }

            if (element.Parent.Nodes.Count == 1 && element.Parent != _root)
            {
                if (element.Parent == null)
                {
                    throw new NullReferenceException(
                        "Родитель удаляемого элемента был null.");
                }

                if (element.Parent.Parent == null)
                {
                    throw new NullReferenceException(
                        "Родитель родителя удаляемого элемента был null.");
                }

                if (element.Parent.Parent.Nodes == null)
                {
                    throw new NullReferenceException(
                        "Дети родителя родителя удаляемого элемента был null.");
                }

                return element.Parent.Parent.Nodes.Remove(element.Parent);
            }

            return element.Parent.Nodes.Remove(element);
        }

        /// <summary>
        ///     Добавить после элемента.
        ///     Если в цепи нет элементов, то element = null и ConnectionType = Любой.
        /// </summary>
        /// <param name="element">Элемент после которого добавляется новый элемент.</param>
        /// <param name="newElement">Новый элемент.</param>
        /// <param name="connection">Тип соединения.</param>
        public void AddAfter(ElementBase element, ElementBase newElement,
            ConnectionType connection)
        {
            if (_root == null)
            {
                _root = new SeriesSubcircuit();
                _root.Nodes.Add(newElement);
                newElement.Parent = _root;
                return;
            }

            if (element == null || newElement == null)
            {
                throw new ArgumentNullException(
                    nameof(element) + " или " + nameof(newElement));
            }

            switch (connection)
            {
                case ConnectionType.Serial:
                {
                    if (element.Parent is SeriesSubcircuit series)
                    {
                        series.Nodes.Add(newElement);
                        newElement.Parent = series;
                        break;
                    }

                    if (element.Parent is ParallelSubcircuit parallel)
                    {
                        if (parallel.Nodes.Remove(element))
                        {
                            SeriesSubcircuit newSeriesSubcircuit =
                                new SeriesSubcircuit {Parent = parallel};

                            parallel.Nodes.Add(newSeriesSubcircuit);

                            newSeriesSubcircuit.Nodes.Add(element);
                            newSeriesSubcircuit.Nodes.Add(newElement);
                            element.Parent = newSeriesSubcircuit;
                            newElement.Parent = newSeriesSubcircuit;
                            break;
                        }

                        throw new Exception($"{element.Name} не был удален из родителя.");
                    }

                    throw new Exception($"У {element.Name} неизвестный родитель.");
                }

                case ConnectionType.Parallel:
                {
                    if (element.Parent is ParallelSubcircuit parallel)
                    {
                        parallel.Nodes.Add(newElement);
                        newElement.Parent = parallel;
                        break;
                    }

                    if (element.Parent is SeriesSubcircuit series)
                    {
                        if (series.Nodes.Remove(element))
                        {
                            ParallelSubcircuit newParallelSubcircuit =
                                new ParallelSubcircuit {Parent = series};

                            series.Nodes.Add(newParallelSubcircuit);
                            newParallelSubcircuit.Nodes.Add(element);
                            newParallelSubcircuit.Nodes.Add(newElement);
                            element.Parent = newParallelSubcircuit;
                            newElement.Parent = newParallelSubcircuit;
                            break;
                        }

                        throw new Exception(element.Name + " не был удален из родителя.");
                    }

                    throw new Exception($"У {element.Name} неизвестный родитель.");
                }
            }
        }

        #endregion
    }
}