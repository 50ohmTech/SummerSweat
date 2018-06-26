using System.Collections.Generic;
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
        public List<Element> Elements;

        /// <summary>
        ///     Расчет комплексного сопротивления элементов
        /// </summary>
        /// <param name="f">Частоты</param>
        /// <returns></returns>
        public List<Complex> CalculateZ(double[] f)
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