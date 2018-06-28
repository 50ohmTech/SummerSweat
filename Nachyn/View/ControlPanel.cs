using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.ComboBoxType;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Панель управления
    /// </summary>
    public partial class ControlPanel : Form
    {
        /// <summary>
        ///     Текст кнопки
        /// </summary>
        private const string _buttonEditName = "Изменить";

        /// <summary>
        ///     Визуальный элемент
        /// </summary>
        private readonly ViewElement _element;


        /// <summary>
        ///     Входной узел
        /// </summary>
        private uint _nodeIn;

        /// <summary>
        ///     Выходной узел
        /// </summary>
        private uint _nodeOut;

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        private readonly ObservableCollection<ViewElement> _viewElements;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="branches">Список ветвей</param>
        /// <param name="viewElements">Список визуальных элементов</param>
        public ControlPanel(ObservableCollection<Branch> branches,
            ObservableCollection<ViewElement> viewElements)
        {
            InitializeComponent();
            InitializeComboBoxType();

            _viewElements = viewElements;
            _branchBindingSource.DataSource = branches;
        }

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Визуальный элемент</param>
        public ControlPanel(ViewElement element)
        {
            InitializeComponent();
            InitializeComboBoxType();

            _buttonAdd.Click -= ButtonAdd_Click;
            _buttonAdd.Click += ButtonEdit_Click;

            _element = element;

            _buttonAdd.Text = _buttonEditName;

            _textBoxName.Text = element.Item.Name;
            _textBoxName.Enabled = false;

            _comboBoxType.Visible = false;
            _labelSelectType.Visible = false;

            _groupBoxEditBranch.Visible = false;
            _dataGridView1.Visible = false;

            Size = new Size(207, 193);
        }

        /// <summary>
        ///     Инициализировать ComboBoxType
        /// </summary>
        private void InitializeComboBoxType()
        {
            var elementTypes = new List<ElementTypeComboBoxItem>
            {
                new ElementTypeComboBoxItem(ElementType.Resistor),
                new ElementTypeComboBoxItem(ElementType.Inductor),
                new ElementTypeComboBoxItem(ElementType.Capacitor)
            };

            _comboBoxType.DataSource = elementTypes;
            _comboBoxType.ValueMember = "Value";
            _comboBoxType.DisplayMember = "Description";
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Добавить?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (_comboBoxType.SelectedItem is ElementTypeComboBoxItem currentElement)
                {
                    if (_branchBindingSource.Current is Branch currentBranch)
                    {
                        ElementBase newElement = null;
                        switch (currentElement.Value)
                        {
                            case ElementType.Resistor:
                                newElement = new Resistor(currentBranch,
                                    _textBoxName.Text, _value);

                                break;
                            case ElementType.Inductor:
                                newElement = new Inductor(currentBranch,
                                    _textBoxName.Text, _value);

                                break;
                            case ElementType.Capacitor:
                                newElement = new Capacitor(currentBranch,
                                    _textBoxName.Text, _value);

                                break;
                        }

                        var viewElement = new ViewElement(newElement);
                        _viewElements.Add(viewElement);
                    }
                    else
                    {
                        MessageBox.Show("Выберите ветвь",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Изменить?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _element.Item.Value = _value;
                Close();
            }
        }

        private void TextBoxValue_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(_textBoxValue.Text, out _value))
            {
                PassElementValidation(false);
                return;
            }

            if (_value < 0)
            {
                PassElementValidation(false);
                return;
            }

            if (string.IsNullOrWhiteSpace(_textBoxName.Text))
            {
                PassElementValidation(false);
                return;
            }

            PassElementValidation(true);
        }

        /// <summary>
        ///     Элементы прошли валидацию
        /// </summary>
        /// <param name="validate">true/false</param>
        private void PassElementValidation(bool validate)
        {
            _buttonAdd.Enabled = validate;
        }


        private void TextBoxNodeIn_TextChanged(object sender, EventArgs e)
        {
            bool TryParseNode(TextBox textBox, out uint node)
            {
                if (!uint.TryParse(textBox.Text, out node))
                {
                    PassBranchValidation(false);
                    return false;
                }

                if (_value < 0)
                {
                    PassBranchValidation(false);
                    return false;
                }

                return true;
            }

            if (!TryParseNode(_textBoxNodeIn, out _nodeIn))
            {
                PassBranchValidation(false);
                return;
            }

            if (!TryParseNode(_textBoxNodeOut, out _nodeOut))
            {
                PassBranchValidation(false);
                return;
            }

            if (_nodeIn == _nodeOut)
            {
                PassBranchValidation(false);
                return;
            }

            PassBranchValidation(true);
        }

        /// <summary>
        ///     Элементы прошли валидацию
        /// </summary>
        /// <param name="validate">true/false</param>
        private void PassBranchValidation(bool validate)
        {
            _buttonAddBranch.Enabled = validate;
        }


        private void ButtonAddBranch_Click(object sender, EventArgs e)
        {
            _branchBindingSource.Add(new Branch(_nodeIn, _nodeOut));
        }

        private void ButtonDeleteBranchSelected_Click(object sender, EventArgs e)
        {
            if (_branchBindingSource.Current is Branch current)
            {
                _branchBindingSource.Remove(current);
            }
        }
    }
}