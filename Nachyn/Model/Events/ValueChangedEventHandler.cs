namespace Model.Events
{
    /// <summary>
    ///     Делегат изменений значений на номиналах
    /// </summary>
    /// <param name="sender">Отправитель</param>
    public delegate void ValueChangedEventHandler(object sender,
        ElementValueEventArgs arguments);
}