using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Интерфейс элементов
    /// </summary>
    public interface IElement
    {
        /// <summary>
        ///     Свойство для работы с параметрами пассивных элементов
        /// </summary>
        double Parameter { get; }

        /// <summary>
        ///     Рассчет комплексного сопротивления
        /// </summary>
        Complex GetImpedance(double w);
    }
}