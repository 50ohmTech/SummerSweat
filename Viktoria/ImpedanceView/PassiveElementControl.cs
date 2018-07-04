using System;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class PassiveElementControl : UserControl
    {
        /// <summary>
        ///     Хранение текущего типа элемента в combobox
        /// </summary>
        private int _currentType;

        /// <summary>
        ///     Переменная, показывающая, редактируется элемент или добавляется новый
        /// </summary>
        public bool IsModify;

        /// <summary>
        ///     Конструктор контроллера
        /// </summary>
        public PassiveElementControl()
        {
            InitializeComponent();
        }

        public IElement Element
        {
            get
            {
                ValidationTools.IsDouble(FirstTextView);
                switch (_currentType)
                {
                    case (int) ElementsType.Inductor:
                    {
                        var L = Convert.ToDouble(FirstTextView.Text);
                        IElement element = new Inductor(L);
                        return element;
                    }
                    case (int) ElementsType.Resistor:
                    {
                        var R = Convert.ToDouble(FirstTextView.Text);
                        IElement element = new Resistor(R);
                        return element;
                    }
                    case (int) ElementsType.Capacitor:
                    {
                        var C = Convert.ToDouble(FirstTextView.Text);
                        IElement element = new Capacitor(C);
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

        /// <summary>
        ///     Обработка изменения значения в combobox с заменой подсказок пользователю
        /// </summary>
        private void ElementTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FirstTextView.Text = string.Empty;
            _currentType = ((ComboBox)sender).SelectedIndex;
            ConfigureTextBoxPlaceholder();
        }

        /// <summary>
        ///     Метод, выводящий подсказки по заполнению textbox в зависимости от типа в combobox
        /// </summary>
        private void ConfigureTextBoxPlaceholder()
        {
            switch (_currentType)
            {
                case (int)ElementsType.Inductor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите L");
                    break;
                }
                case (int)ElementsType.Resistor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите R");
                    break;
                }
                case (int)ElementsType.Capacitor:
                {
                    ConfigureTextBoxText(FirstTextView, "Введите С");
                    break;
                }
            }
        }

        /// <summary>
        ///     Вывод подсказки пользователю в случае если textbox пуст (т.е. пользователь не ввел значение)
        /// </summary>
        /// <param name="title"> Текст "Введите" + обозначение параметра элемента </param>
        private void ConfigureTextBoxText(TextBox textbox, string title)
        {
            if (textbox.Text == string.Empty)
            {
                textbox.Text = title;
            }
        }

        /// <summary>
        ///     Отчищает textbox от подсказки при клике по нему
        /// </summary>
        private void FirstTextView_Click(object sender, EventArgs e)
        {
            if (!IsModify)
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
    }
}