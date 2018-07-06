using System;
using Model.Elements;

namespace Model.Factories
{
    /// <summary>
    ///     Фаблика элементов
    /// </summary>
    public static class ElementFactory
    {
        /// <summary>
        /// Рандом
        /// </summary>
        private static readonly Random _random = new Random();
        
        public static uint NumberRandomElement = 1;

        /// <summary>
        ///     Получить сущность
        /// </summary>
        /// <param name="elementType">Тип элемента</param>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Номинал</param>
        /// <returns>Элемент</returns>
        public static ElementBase GetInstance(ElementType elementType, string name,
            double value)
        {
            ElementBase newElement = null;
            switch (elementType)
            {
                case ElementType.Resistor:
                    newElement = new Resistor(name, value);

                    break;
                case ElementType.Inductor:
                    newElement = new Inductor(name, value);

                    break;
                case ElementType.Capacitor:
                    newElement = new Capacitor(name, value);

                    break;
                default:
                    throw new ArgumentException();
            }

            return newElement;
        }

        /// <summary>
        /// Получить рандомную сущность типа ElementBase
        /// </summary>
        /// <returns>Элемент</returns>
        public static ElementBase GetRandomInstance()
        {
            ElementType elementType = (ElementType) _random.Next(3);
            string name = ElementBase.GetSymbol(elementType) + NumberRandomElement++;
            double value = Math.Round(_random.NextDouble(), 3) + _random.Next(100) + 1;
            return GetInstance(elementType, name, value);
        }
    }
}