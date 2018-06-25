using System.Numerics;
using Model.Events;

namespace Model.Elements
{
    public interface IElement
    {
        /// <summary>
        ///     Имя элемента
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Номинал
        /// </summary>
        double Value { get; set; }

        /// <summary>
        ///     Обработчик события на изменение номинала
        /// </summary>
        event ValueChangedEventHandler ValueChanged;

        /// <summary>
        ///     Расчет комплексного сопротивления
        ///     данного элемента
        /// </summary>
        /// <param name="frequency">Частоста</param>
        /// <returns>Комплексное сопротивление</returns>
        Complex CalculateZ(double frequency);
    }
}