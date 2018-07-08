using System;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class EnterElementControl : UserControl
    {
        #region -- Публичные методы --

        /// <summary>
        ///     Конструктор контроллера
        /// </summary>
        public EnterElementControl()
        {
            InitializeComponent();
        }

        #endregion

        #region -- Свойства --

        /// <summary>
        ///     Свойство для ввода/вывода элемента на control в зависимости от типа элемента в combobox
        /// </summary>
        public IElement Element
        {
            get
            {
                ValidationTools.IsDouble(FirstTextView);
                ValidationTools.IsCorrectParameter(Convert.ToDouble(FirstTextView.Text));
                switch (_currentType)
                {
                    case ElementsType.Inductor:
                    {
                        IElement element =
                            new Inductor(Convert.ToDouble(FirstTextView.Text));
                        return element;
                    }
                    case ElementsType.Resistor:
                    {
                        IElement element =
                            new Resistor(Convert.ToDouble(FirstTextView.Text));
                        return element;
                    }
                    case ElementsType.Capacitor:
                    {
                        IElement element =
                            new Capacitor(Convert.ToDouble(FirstTextView.Text));
                        return element;
                    }
                }
                return null;
            }

            set
            {
                if (value is Inductor inductor)
                {
                    ElementTypeComboBox.SelectedIndex = 0;
                    FirstTextView.Text = inductor.Parameter.ToString();
                }
                else if (value is Resistor resistor)
                {
                    ElementTypeComboBox.SelectedIndex = 1;
                    FirstTextView.Text = resistor.Parameter.ToString();
                }
                else if (value is Capacitor capacitor)
                {
                    ElementTypeComboBox.SelectedIndex = 2;
                    FirstTextView.Text = capacitor.Parameter.ToString();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        #endregion

        #region -- Поля --

        #region -- Закрытые поля --

        /// <summary>
        ///     Хранение текущего типа элемента в combobox
        /// </summary>
        private ElementsType _currentType;

        #endregion

        #region -- Открытые поля --

        /// <summary>
        ///     Переменная, показывающая, редактируется элемент или добавляется новый
        /// </summary>
        public bool isModify;

        #endregion

        #endregion

        #region -- Приватные методы --

        /// <summary>
        ///     Обработка изменения значения в combobox с заменой подсказок пользователю
        /// </summary>
        private void ElementTypeComboBox_SelectionChangeCommitted(object sender,
            EventArgs e)
        {
            if (!isModify)
            {
                FirstTextView.Text = string.Empty;
            }
            _currentType = (ElementsType) ((ComboBox) sender).SelectedIndex;
            ConfigureTextBoxPlaceholder();
        }

        /// <summary>
        ///     Метод, выводящий подсказки по заполнению textbox в зависимости от типа в combobox
        /// </summary>
        private void ConfigureTextBoxPlaceholder()
        {
            switch (_currentType)
            {
                case ElementsType.Inductor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите L");
                    break;
                }
                case ElementsType.Resistor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите R");
                    break;
                }
                case ElementsType.Capacitor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите С");
                    break;
                }
            }
        }

        /// <summary>
        ///     Вывод подсказки пользователю в случае если textbox пуст (т.е. пользователь не ввел значение)
        /// </summary>
        /// <param name="title"> Текст "Введите" + физическое обозначение параметра элемента </param>
        private void ConfigureTextBoxText(TextBox textbox, string title)
        {
            if (textbox.Text == string.Empty)
            {
                textbox.Text = title;
            }
        }

        /// <summary>
        ///     Отчищает textbox от подсказки при клике по нему, если элемент не редактируется
        /// </summary>
        private void FirstTextView_Click(object sender, EventArgs e)
        {
            if (!isModify)
            {
                FirstTextView.Text = string.Empty;
            }
        }

        /// <summary>
        ///     Возвращает подсказку пользователю, если он не ввел значение в textbox
        /// </summary>
        private void FirstTextView_Leave(object sender, EventArgs e)
        {
            if (FirstTextView.Text == string.Empty)
            {
                ConfigureTextBoxPlaceholder();
            }
        }

        #endregion
    }
}