using System;

namespace CircuitLibrary.Events
{
    /// <summary>
    ///     Event handler SubcircuitChanged
    /// </summary>
    public sealed class SubcircuitChangedEventArgs
    {
        #region Properties

        /// <summary>
        /// Message
        /// </summary>
        private string _message;

        /// <summary>
        ///     Parent
        /// </summary>
        private INode Parent { get; }

        /// <summary>
        ///     Get/Set new message
        /// </summary>
        private string Message
        {
            get => _message;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Message is empty");
                }

                _message = value;
            }            
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <param name="message">Message</param>
        public SubcircuitChangedEventArgs(INode parent, string message)
        {
            Parent = parent ?? throw new ArgumentException("Parent is null");
            Message = message;
        }

        #endregion
    }
}