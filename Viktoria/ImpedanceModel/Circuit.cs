using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceModel
{
    public class Circuit
    {
        #region -- Поля --

        /// <summary>
        ///     Список пассивных элементов
        /// </summary>
        public List<IElement> elements;

        #endregion

        #region -- Публичные методы --

        /// <summary>
        ///     Рассчет комплексного сопротивления цепи для диапазона частот w
        /// </summary>
        /// <param name="minFrequency"> Минимальное значение частоты</param>
        /// <param name="maxFrequency"> Максимальное значение частоты</param>
        /// <param name="step"> Цена деления/Шаг</param>
        /// <returns> Список сопротивлений для каждой частоты из заданного диапазона с заданным шагом</returns>
        public List<Complex> GetImpedanceUsingAngularFrequency(double minFrequency,
            double maxFrequency, double step)
        {
            var impedances = new List<Complex>();
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

        /// <summary>
        ///     Рассчет комплексного сопротивления цепи для диапазона частот f
        /// </summary>
        /// <param name="minFrequency"> Минимальное значение частоты</param>
        /// <param name="maxFrequency"> Максимальное значение частоты</param>
        /// <param name="step"> Цена деления/Шаг</param>
        /// <returns> Список сопротивлений для каждой частоты из заданного диапазона с заданным шагом</returns>
        public List<Complex> GetImpedanceUsingFrequency(double minFrequency,
            double maxFrequency, double step)
        {
            var impedances = new List<Complex>();
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

        #endregion
    }
}