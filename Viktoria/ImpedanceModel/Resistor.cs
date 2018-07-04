using System.Numerics;
using System.Runtime.Serialization;

namespace ImpedanceModel
{
    /// <summary>
    ///     Элемент цепи: Резистор
    /// </summary>
    [DataContract]
    public class Resistor : IElement
    {
        /// <summary>
        ///     Сопротивление резистора.
        /// </summary>
        [DataMember] private double _resistance;

        /// <summary>
        ///     Конструктор класса.
        /// </summary>
        public Resistor(double resistanceValue)
        {
            Parameter = resistanceValue;
        }

        /// <summary>
        ///     Свойство для работы с параметрами.
        /// </summary>
        public double Parameter
        {
            get => _resistance;
            set
            {
                ValidationTools.IsDouble(value);
                ValidationTools.IsLessThenNull(value);
                _resistance = value;
            }
        }

        /// <summary>
        ///     Рассчет комплексного сопротивления.
        /// </summary>
        /// <remarks> Входные параметры не используются при рассчете комплексного сопротивления резистора. </remarks>
        public Complex GetImpedance(double w)
        {
            return _resistance;
        }

        /// <summary>
        ///     Переопределение ToString для вывода названия элемента
        /// </summary>
        public override string ToString()
        {
            return "Resistor";
        }
    }
}