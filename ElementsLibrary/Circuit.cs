using System;
using System.Collections.Generic;
using System.Numerics;

namespace ElementsLibrary
{
    /// <summary>
    /// Класс электрическая цепь Circuit
    /// </summary>
   public class Circuit
    {
        /// <summary>
        /// Список элементов цепи
        /// </summary>
        private List<ElementBase> _elements;

        /// <summary>
        /// Конструктор класса <see cref="Circuit"/>
        /// </summary>
        /// <param name="elements">Элементы</param>
        public Circuit(List<ElementBase> elements)
        {
            Elements = elements;
        }

        /// <summary>
        /// Свойство для возвращения и задачи элементов в цепи
        /// </summary>
        public List<ElementBase> Elements
        {
            get => _elements;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
            }
        }

        /// <summary>
        /// Метод расчета полного импеданса цепи
        /// </summary>
        /// <param name="frequencies">Частота</param>
        /// <returns>Импеданс всей цепи</returns>
        public List<Complex> CalculateZ(List<double> frequencies)
        {
            if (_elements == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }

            if (frequencies == null)
            {
                throw new ArgumentNullException(nameof(frequencies));
            }
            var counter = 0;
            var impedance = new List<Complex>();
            foreach (var element in Elements)
            {
                foreach (var frequency in frequencies)
                {
                    impedance[counter] = element.CalculateZ(frequency);
                    counter++;
                }
            }
            return impedance;
        }
    }
}
