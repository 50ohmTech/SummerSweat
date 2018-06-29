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
        public List<Element> Elements { get; set; }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса Circuit
        /// </summary>
        public Circuit(List<Element> elements)
        {
            if (elements.Any())
            {
                Elements = elements;
            }
            foreach (var element in Elements)
            {
                element.ValueChanged += CircuitChanged;
            }
        }

        /// <summary>
        /// Расчет импедансов цепи для списка частот
        /// </summary>
        /// <param name="frequencies">Частоты</param>
        /// <returns></returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
            var impedance = new List<Complex>();
            for (var i = 0; i < frequencies.Length; i++)
            {
                foreach (var element in Elements)
                {
                    impedance[i] = Complex.Add(impedance[i],
                        element.CalculateZ(frequencies[i]));
                }
            }

            return impedance;
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
