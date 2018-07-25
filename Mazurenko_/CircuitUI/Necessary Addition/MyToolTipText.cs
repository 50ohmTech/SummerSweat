namespace CircuitUI
{
    /// <summary>
    /// The class serves to group shared messages "Tooltip"
    /// </summary>
    public static class MyToolTipText
    {
        #region Properties

        /// <summary>
        /// Property passing a string containing information to fill in the fields "Value" and " Frequenies"
        /// </summary>
        /// <returns></returns>
        public static string MessageForRows
        {
            get
            {
                string messageRows = "\t Allowed input values : \n" +
                                     "-- Inserting values is not allowed ! -- \n" +
                                     "-- The number can be integer or real -- \n" +
                                     "-- The number must be greater than 0.000000 -- \n" +
                                     "-- The number must be equal to or less than 100000000000000 -- \n" +
                                     "-- The total length of the number must not exceed 15 characters (including the comma) --";

                return messageRows;
            }
        }

        #endregion Properties
    }
}
