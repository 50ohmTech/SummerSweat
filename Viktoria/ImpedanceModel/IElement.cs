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
        ///     Рассчет комплексного сопротивления для w
        /// </summary>
        Complex GetImpedanceUsingAngularFrequency(double w);

        /// <summary>
        ///     Рассчет комплексного сопротивления для f
        /// </summary>
        Complex GetImpedanceUsingFrequency(double f);
    }
}