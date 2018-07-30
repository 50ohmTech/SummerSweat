using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;

namespace Gpt.Model
{
    /// <summary>
    ///     Электрическая цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        ///     Список элементов цепи
        /// </summary>
        public ObservableCollection<ElementBase> Elements;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public Circuit()
        {
            Elements = new ObservableCollection<ElementBase>();
        }

        /// <summary>
        ///     Расчет комплексного сопротивления элементов
        /// </summary>
        /// <param name="f">Частоты</param>
        /// <returns></returns>
        public List<Complex> CalculateZ(params double[] frequency)
        {
            var result = new List<Complex>();

            for (var i = 0; i < frequency.Length; i++)
            {
                var impedance = new Complex();
                foreach (var element in Elements)
                {
                    impedance += element.CalculateZ(frequency[i]);
                }
                result.Add(impedance);
            }

            return result;
        }
    }
}