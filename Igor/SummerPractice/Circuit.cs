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
        public List<Complex> CalculateZ(params double[] f)
        {
            var result = new List<Complex>();

            for (var i = 0; i < f.Length; i++)
            {
                foreach (var element in Elements)
                {
                    result[i] = Complex.Add(result[i],
                        element.CalculateZ(f[i]));
                }
            }

            return result;
        }
    }
}