using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;
using Model.ComboBoxType;
using Model.Elements;
using Model.Factories;
using View.Properties;

namespace View
{
    /// <summary>
    ///     Панель управления
    /// </summary>
    public partial class ElementManagerForm : Form
    {
        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="branches">Список ветвей</param>
        /// <param name="viewElements">Список визуальных элементов</param>
        public ElementManagerForm(List<Branch> branches,
            List<ViewElement> viewElements)
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
        public ElementManagerForm(ViewElement element)
        {
            InitializeComponent();
            InitializeComboBoxType();

            _buttonAdd.Click -= ButtonAdd_Click;
            _buttonAdd.Click += ButtonEdit_Click;

            _element = element;

            _buttonAdd.Text = Resources.ButtonEditName;

            _textBoxName.Text = element.Item.Name;
            _textBoxName.Enabled = false;

            _comboBoxType.Visible = false;
            _labelSelectType.Visible = false;

            _groupBoxEditBranch.Visible = false;
            _dataGridViewBranches.Visible = false;
            _groupBoxAddElement.Text = Resources.GroupBoxEditName;
            _groupBoxAddElement.Location = _groupBoxEditBranch.Location;

            _buttonAdd.Location = _textBoxName.Location;
            _textBoxName.Location = _textBoxValue.Location;
            _textBoxValue.Location = _comboBoxType.Location;
            _labelName.Location = _labelValue.Location;
            _labelValue.Location =
                new Point(_labelName.Location.X, _labelName.Location.Y - 30);

            _groupBoxAddElement.Size = new Size(_groupBoxAddElement.Size.Width,
                _groupBoxAddElement.Size.Height - 25);

            Size = new Size(207, 170);
        }

        #endregion

        #region Private

        /// <summary>
        ///     Визуальный элемент
        /// </summary>
        private readonly ViewElement _element;

        /// <summary>
        ///     Список визуальных элементов
        /// </summary>
        private readonly List<ViewElement> _viewElements;


        /// <summary>
        ///     Входной узел
        /// </summary>
        private uint _nodeIn;

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        /// <summary>
        ///     Инициализировать ComboBoxType
        /// </summary>
        private void InitializeComboBoxType()
        {
            List<ElementTypeComboBoxItem> elementTypes = new List<ElementTypeComboBoxItem>
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
            if (_comboBoxType.SelectedItem is ElementTypeComboBoxItem currentElement)
            {
                if (_branchBindingSource.Current is Branch currentBranch)
                {
                    ElementBase newElement =
                        ElementFactory.GetInstance(currentElement.Value,
                            _textBoxName.Text, _value);

                    _viewElements.Add(new ViewElement(newElement,
                        currentBranch.Elements));

                    currentBranch.Elements.Add(newElement);
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

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Изменить?",
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

            if (_value <= 0 || _value > 1000000000000)
            {
                PassElementValidation(false);
                return;
            }

            if (string.IsNullOrWhiteSpace(_textBoxName.Text) ||
                _textBoxName.Text.Length > 10)
            {
                PassElementValidation(false);
                return;
            }

            PassElementValidation(true);
        }

        /// <summary>
        ///     Элементы прошли валидацию
        /// </summary>
        /// <param name="isValidated">true/false</param>
        private void PassElementValidation(bool isValidated)
        {
            _buttonAdd.Enabled = isValidated;
        }


        private void TextBoxNodeIn_TextChanged(object sender, EventArgs e)
        {
            if (!uint.TryParse(_textBoxNodeIn.Text, out _nodeIn))
            {
                PassBranchValidation(false, "Введенный текст не является" +
                                            "\r\nположительным числом");

                return;
            }

            if (_nodeIn > Branch.NodeOutLast)
            {
                PassBranchValidation(false, "Вход. узел должен быть " +
                                            "\r\nравен или меньше " +
                                            $"\r\nпоследнего узла = {Branch.NodeOutLast}");

                return;
            }


            PassBranchValidation(true);
        }

        /// <summary>
        ///     Элементы прошли валидацию
        /// </summary>
        /// <param name="isValidated">true/false</param>
        private void PassBranchValidation(bool isValidated, string message = "")
        {
            _buttonAddBranch.Enabled = isValidated;
            if (isValidated)
            {
                _labelValidateBranch.Text = "Валидация успешна";
                _labelValidateBranch.ForeColor = Color.Green;
            }
            else
            {
                _labelValidateBranch.Text = message;
                _labelValidateBranch.ForeColor = Color.Red;
            }
        }


        private void ButtonAddBranch_Click(object sender, EventArgs e)
        {
            _branchBindingSource.Add(new Branch(_nodeIn));
        }

        private void ButtonDeleteBranchSelected_Click(object sender, EventArgs e)
        {
            if (_branchBindingSource.Current is Branch current)
            {
                _branchBindingSource.Remove(current);
            }
        }

        #endregion
    }
}