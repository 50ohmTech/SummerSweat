using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using Model.Elements;

namespace Model
{
    /// <summary>
    ///     Электрическая цепь
    /// </summary>
    public class Circuit
    {
        /// <summary>
        ///     Список элементов цепи
        /// </summary>
        public ObservableCollection<IElement> Elements;

        /// <summary>
        ///     Конструктор
        /// </summary>
        public Circuit()
        {
            Elements = new ObservableCollection<IElement>();
        }

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента
        /// </summary>
        /// <param name="frequencies">Частоты</param>
        /// <returns>Комплексные сопротивления</returns>
        public List<Complex> CalculateZ(params double[] frequencies)
        {
            var resistances = new List<Complex>();
            foreach (var frequency in frequencies)
            {
                var resistance = new Complex();
                foreach (var element in Elements) resistance += element.CalculateZ(frequency);
                resistances.Add(resistance);
            }

            return resistances;
        }
    }
}