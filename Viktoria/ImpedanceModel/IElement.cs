using System.Numerics;

namespace ImpedanceModel
{
    /// <summary>
    ///     Интерфейс элементов
    /// </summary>
    public interface IElement
    {
        #region -- Методы --

        /// <summary>
        ///     Рассчет комплексного сопротивления для w
        /// </summary>
        Complex CalculateImpedance(double w);

        #endregion

        #region -- Свойства --

        /// <summary>
        ///     Свойство для работы с типом пассивных элементов
        /// </summary>
        string Type { get; }

        /// <summary>
        ///     Свойство для работы с параметрами пассивных элементов
        /// </summary>
        double Parameter { get; }

        #endregion
    }
}