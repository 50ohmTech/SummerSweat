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

        public List<Complex> GetImpedanceUsingAngularFrequency(double minFrequency, double maxFrequency, double step)
        {
            List<Complex> impedances = new List<Complex>();
            for (var i = minFrequency; i <= maxFrequency; i = i + step)
            {
                Complex impedance = 0;
                for (var n = 0; n <= elements.Count - 1; n++)
                {
                    impedance += elements[n].GetImpedanceUsingAngularFrequency(i);
                }
                impedances.Add(impedance);
            }
            return impedances;
        }

        public List<Complex> GetImpedanceUsingFrequency(double minFrequency, double maxFrequency, double step)
        {
            List<Complex> impedances = new List<Complex>();
            for (var i = minFrequency; i <= maxFrequency; i = i + step)
            {
                Complex impedance = 0;
                for (var n = 0; n <= elements.Count - 1; n++)
                {
                    impedance += elements[n].GetImpedanceUsingFrequency(i);
                }
                impedances.Add(impedance);
            }
            return impedances;
        }
    }
}