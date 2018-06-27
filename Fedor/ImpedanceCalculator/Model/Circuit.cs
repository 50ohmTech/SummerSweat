using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    /// <summary>
    /// Электрическая цепь.
    /// </summary>
    public class Circuit
    {
        #region - - Свойства - -

        /// <summary>
        /// Коллекция элементов цепи.
        /// </summary>
        public ObservableCollection<Element> Elements { get; set; }

        #endregion

        #region – – Публичные методы – –

        /// <summary>
        /// Конструктор класса Circuit.
        /// </summary>
        public Circuit()
        {
            Elements = new ObservableCollection<Element>();
        }

        /// <summary>
        /// Расчитать импедансы цепи для списка частот.
        /// </summary>
        /// <param name="frequencies"> Список частот сигнала. </param>
        /// <returns> Список импедансов цепи. </returns>
        public List<Complex> CalculateZ(double[] frequencies)
        {
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

        #region – – События – –

        /// <summary>
        /// Событие, возникающее при изменении номинала элемента.
        /// </summary>
        public event EventHandler<ChangedEventArgs> CircuitChanged;

        #endregion
    }
}
