using System.Numerics;

namespace CircuitElements
{
    //TODO: комментарий!
    //TODO: Именование вводит в заблуждение - это элемент, или цепь, или элемент цепи? Тогда почему его реализуют и цепи, и элементы?
    public interface ICircuitElement
	{
        #region Properties

        //TODO: В названии поля/свойства не надо добавлять части имени класса
        /// <summary>
        ///     ID элемента
        /// </summary>
        int ElementId { get; }

        #endregion

        #region Events

        //TODO: Использовать стандартный делегат EventHandler
        /// <summary>
        ///     Событие, которое загорается при изменении элемента
        /// </summary>
        event ElementStateHandler ElementChanged;

        #endregion

        #region Public methods

        //TODO: frequency
        /// <summary>
        ///     Расчитать импаденс по входной частоте
        /// </summary>
        /// <param name="frequence"></param>
        /// <returns></returns>
        Complex CalculateZ(double frequence);

		#endregion
	}

    //TODO: Для аргументов события надо создавать отдельный класс, с наследием от EventArgs
    /// <summary>
    ///     Делегат, хранящий сигнатуру методов, подписанных на событие ValueChanged
    /// </summary>
    /// <param name="newValue"> Изменившееся значение </param>
    /// <param name="valueOwner"> объект, который изменился </param>
    public delegate void ElementStateHandler(object newValue, ElementBase valueOwner);
}