using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Функции для NodeType
    /// </summary>
    public class ToolsNodeType
    {
        /// <summary>
        /// Получить атрибут "Описание"
        /// </summary>
        public static string GetDescription(NodeType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return value.ToString();
        }
    }
}
