using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace CircuitCalculator
{
    /// <summary>
    /// Электрическая цепь
    /// </summary>
    class Circuit
    {
        #region Свойства

        /// <summary>
        /// Коллекция элементов цепи
        /// </summary>
        public ObservableCollection<Element> Elements { get; set; }

        #endregion

        #region Публичные методы

        /// <summary>
        /// Конструктор класса Circuit
        /// </summary>
        public Circuit()
        {
            Elements = new ObservableCollection<Element>();
        }

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
    }
}
