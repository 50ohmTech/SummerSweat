using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLibrary
{
    /// <summary>
    /// Класс для события
    /// </summary>
   public class ValueChangedEvent : EventArgs
    {
        /// <summary>
        /// Значение на изменение
        /// </summary>
        private double _value;

        /// <summary>
        /// Сообщение 
        /// </summary>
        private string _message;

        /// <summary>
        /// Поставить/убрать новое сообщение
        /// </summary>
        public string Message
        {
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(Message));
                }

                _message = value;
            }
            get { return _message; }
        }

        /// <summary>
        /// Поставить/убрать новое значение
        /// </summary>
        public double Value
        {
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                _value = value;
            }
            get { return _value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value"></param>
        /// <param name="message"></param>
        public ValueChangedEvent(double value, string message)
        {
            Value = value;
            Message = message;
        }
    }
}
