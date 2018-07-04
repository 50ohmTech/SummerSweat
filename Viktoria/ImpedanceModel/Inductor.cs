using System.Numerics;
using System.Runtime.Serialization;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Катушка индуктивности
    /// </summary>
    [DataContract]
    public class Inductor : IElement
    {
        /// <summary>
        ///     Сопротивление катушки индуктивности
        /// </summary>
        [DataMember] private double _inductance;

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public Inductor(double inductanceValue)
        {
            Parameter = inductanceValue;
        }

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _inductance;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _inductance = value;
            }
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        public Complex GetImpedance(double w)
        {
            return Complex.ImaginaryOne * w * _inductance;
        }

        /// <summary>
        ///     Переопределение ToString для вывода названия элемента
        /// </summary>
        public override string ToString()
        {
            return "Inductor";
        }
    }
}