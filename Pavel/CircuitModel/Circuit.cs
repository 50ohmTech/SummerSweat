using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CircuitModel
{
    /// <summary>
    /// Электрическая цепь
    /// </summary>
    public class Circuit
    {
        #region Свойства

        /// <summary>
        /// Коллекция элементов цепи
        /// </summary>
        public List<ElementBase> Elements { get; }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса Circuit
        /// </summary>
        public Circuit(List<ElementBase> elements)
        {
            if (elements.Any())
            {
                Elements = elements;

                foreach (var element in Elements)
                {
                    element.ValueChanged += CircuitChanged;
                }
            }            
        }

        /// <summary>
        /// Расчет импедансов цепи для списка частот
        /// </summary>
        /// <param name="frequencies">Частоты</param>
        /// <returns></returns>
        public List<Complex> CalculateZ(List<double> frequencies)
        {
            if (frequencies == null)
            {
                throw new ArgumentNullException($"Список частот не может быть пустым");
            }
            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                var impedance = new Complex();

                foreach (var element in Elements)
                {
                    impedance += element.CalculateZ(frequency);
                }

                impedances.Add(impedance);
            }
            return impedances;

        }

        #endregion

        #region События
        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event ValueEventHandler CircuitChanged;

        #endregion
    }
}
