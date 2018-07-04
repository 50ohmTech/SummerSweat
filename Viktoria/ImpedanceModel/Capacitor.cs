using System.Numerics;
using System.Runtime.Serialization;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Конденсатор
    /// </summary>
    [DataContract]
    public class Capacitor : IElement
    {
        /// <summary>
        ///     Сопротивление конденсатора.
        /// </summary>
        [DataMember] private double _capacitance;

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public Capacitor(double capacitanceValue)
        {
            Parameter = capacitanceValue;
        }

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _capacitance;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _capacitance = value;
            }
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        public Complex GetImpedance(double w)
        {
            return -Complex.ImaginaryOne / (w * _capacitance);
        }

        /// <summary>
        ///     Переопределение ToString для вывода названия элемента
        /// </summary>
        public override string ToString()
        {
            return "Capacitor";
        }
    }
}