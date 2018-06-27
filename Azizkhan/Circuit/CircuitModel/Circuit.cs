using System;
using System.Collections.Generic;
using System.Numerics;

namespace Circuit
{
    /// <summary>
    ///     Электрическая цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        ///     Список элементов в цепи
        /// </summary>
        private List<ElementBase> _elements;

        /// <summary>
        ///     Конструктор сущности электрическая цепь
        /// </summary>
        /// <param name="elements"></param>
        public Circuit(List<ElementBase> elements)
        {
            Elements = elements;
        }

        /// <summary>
        ///     Вернуть и установить список элементов в цепи
        /// </summary>
        public List<ElementBase> Elements
        {
            get => _elements;
            set => _elements =
                value ?? throw new NullReferenceException("Цепь не может быть пустой!");
        }


        /// <summary>
        ///     Метод расчёта общего импеданса цепи
        /// </summary>
        /// <param name="frequencies"></param>
        /// <returns></returns>
        public Complex[] CalculateZ(double[] frequencies)
        {
            if (Elements == null)
            {
                throw new ArgumentException("Лист элементов пуст!");
            }

            if (frequencies == null)
            {
                throw new ArgumentException("Массив частот пуст!");
            }

            var impedances = new Complex[Elements.Count * frequencies.Length];
            var i = 0;

            foreach (var element in Elements)
            {
                foreach (var frequency in frequencies)
                {
                    impedances[i] = element.CalculateZ(frequency);
                    i++;
                }
            }

            return impedances;
        }
    }
}