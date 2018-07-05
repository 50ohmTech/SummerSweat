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
        ///     Получить сущность
        /// </summary>
        /// <param name="elementType">Тип элемента</param>
        /// <param name="name">Имя элемента</param>
        /// <param name="value">Номинал</param>
        /// <returns></returns>
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

        static private Random random = new Random();
        public static ElementBase GetRandomInstance()
        {
            ElementType elementType = (ElementType)random.Next(3);
            string name = Guid.NewGuid().ToString().Remove(5);
            double value = Math.Round(random.NextDouble(), 3) + random.Next(100) + 1;
            return GetInstance(elementType, name, value);
        }
    }
}