using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Model.Elements;
using Model.Elements.Checks;
using Model.Elements.Enums;

namespace Model
{
    /// <summary>
    ///     Цепь.
    /// </summary>
    public class Circuit
    {
        #region Properties

        /// <summary>
        ///     Корень.
        /// </summary>
        public INode Root { get; private set; }

        #endregion

        #region Public methods

        /// <summary>
        ///     Пустая ли цепь.
        /// </summary>
        /// <returns>Пустая ли цепь.</returns>
        public bool IsEmpty()
        {
            return Root == null || Root.Nodes.Count < 1;
        }

        /// <summary>
        ///     Очистить цепь.
        /// </summary>
        public void Clear()
        {
            Root = null;
        }

        /// <summary>
        ///     Рассчитать импедансы.
        /// </summary>
        /// <param name="frequencies">Частоты.</param>
        /// <returns>Импедансы.</returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            Calculation.CheckFrequencies(frequencies);

            if (Root == null)
            {
                throw new NullReferenceException("В цепи нет элементов.");
            }

            return frequencies.Select(frequency => Root.CalculateZ(frequency)).ToList();
        }

        /// <summary>
        ///     Удалить элемент.
        /// </summary>
        /// <param name="element">Элемент.</param>
        /// <returns>Удален ли элемент.</returns>
        public bool TryRemove(ElementBase element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (IsEmpty())
            {
                throw new NullReferenceException("В цепи нет элементов.");
            }

            if (element.Parent == Root)
            {
                if (Root.Nodes == null)
                {
                    throw new NullReferenceException("Дети корня были null.");
                }

                return Root.Nodes.Remove(element);
            }

            if (element.Parent is SubcircuitBase subcircuit &&
                subcircuit.Nodes.Count == 2 &&
                element.Parent != Root)
            {
                foreach (INode children in subcircuit.Nodes)
                {
                    if (children != element)
                    {
                        if (!subcircuit.Parent.Nodes.Remove(subcircuit))
                        {
                            //TODO: надо использовать конкретный тип исключения, а не базовый
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
                            //TODO: поменять на конкретный тип исключения
                            throw new Exception("Неизвестный родитель.");
                        }

                        return true;
                    }
                }
            }

            if (element.Parent != Root && element.Parent.Nodes.Count == 1)
            {
                //TODO: проверки родителей второго уровня обязательны?
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
            if (IsEmpty())
            {
                if (newElement == null)
                {
                    throw new ArgumentNullException(nameof(newElement));
                }

                Root = new SeriesSubcircuit();
                Root.Nodes.Add(newElement);
                newElement.Parent = Root;
                return;
            }

            //TODO: это должны быть раздельные проверки
            //TODO: проверка nullElement должна быть в самом начале
            if (element == null || newElement == null)
            {
                throw new ArgumentNullException(
                    nameof(element) + " или " + nameof(newElement));
            }

            if (element == newElement)
            {
                throw new ArgumentException($"{nameof(element)} и {nameof(newElement)} были равны.");
            }


            switch (connection)
            {
                case ConnectionType.Serial:
                {
                        //TODO: большая вложенность. Код под кейсами в отдельные методы
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
                            //TODO: конкретный тип исключения
                            throw new Exception(element.Name + " не был удален из родителя.");
                    }
                        //TODO: конкретный тип исключения
                        throw new Exception($"У {element.Name} неизвестный родитель.");
                }
            }
        }

        #endregion
    }
}