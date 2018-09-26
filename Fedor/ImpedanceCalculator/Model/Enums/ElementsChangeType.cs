namespace Model.Enums
{
    //TODO: Название типа данных не объясняет изменения чего она описывает
    //+
    /// <summary>
    /// Типы изменения цепи.
    /// </summary>
    public enum ElementsChangeType
    {
        /// <summary>
        /// Сменить дерево элементов.
        /// </summary>
        ChangeTree,

        /// <summary>
        /// Добавление.
        /// </summary>
        Add,

        /// <summary>
        /// Удаление.
        /// </summary>
        Delete,

        /// <summary>
        /// Очистка цепи.
        /// </summary>
        Clear
    }
}
