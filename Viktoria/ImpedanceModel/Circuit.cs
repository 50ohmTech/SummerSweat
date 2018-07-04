using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceModel
{
    public class Circuit
    {
        /// <summary>
        ///     Список пассивных элементов
        /// </summary>
        public List<IElement> elements;

        private List<Complex> GetImpedance(double[] Z, List<double> frequencies)
        {
            var impedances = new List<Complex>();

            foreach (var frequency in frequencies)
            {
                var impedance = new Complex();

                foreach (var element in elements)
                {
                    impedance += element.GetImpedanceUsingFrequency(frequency);
                }

                impedances.Add(impedance);
            }
            return impedances;
        }
    }
}