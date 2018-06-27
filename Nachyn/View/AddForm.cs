using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Forms;
using Model;
using Model.ComboBoxType;
using Model.Elements;

namespace View
{
    public partial class AddForm : Form
    {
        private const string _buttonEditName = "Изменить";

        private readonly ViewElement _element;

        private readonly ObservableCollection<ElementBase> _elements;

        private readonly Panel _panel;

        private double _value;

        public AddForm(ObservableCollection<ElementBase> elements, Panel panel)
        {
            InitializeComponent();
            InitializeComboBoxType();

            _elements = elements;
            _panel = panel;
        }

        public AddForm(ViewElement element)
        {
            InitializeComponent();
            InitializeComboBoxType();

            _buttonAdd.Click -= ButtonAddClick;
            _buttonAdd.Click += ButtonEditClick;

            _element = element;

            _buttonAdd.Text = _buttonEditName;

            _textBoxName.Text = element.Item.Name;
            _textBoxName.Enabled = false;

            _comboBoxType.Visible = false;
            _labelSelectType.Visible = false;      
        }

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

        private void ButtonAddClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Добавить?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (_comboBoxType.SelectedItem is ElementTypeComboBoxItem currentElement)
                {
                    ElementBase newElement = null;
                    switch (currentElement.Value)
                    {
                        case ElementType.Resistor:
                            newElement = new Resistor(_textBoxName.Text, _value);
                            break;
                        case ElementType.Inductor:
                            newElement = new Inductor(_textBoxName.Text, _value);
                            break;
                        case ElementType.Capacitor:
                            newElement = new Capacitor(_textBoxName.Text, _value);
                            break;
                    }
                    var newViewElement = new ViewElement(newElement, _elements);
                    _panel.Controls.Add(newViewElement);
                }

                Close();
            }
        }

        private void ButtonEditClick(object sender, EventArgs e)
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

        private void TextBoxValueTextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(_textBoxValue.Text, out _value))
            {
                PassValidation(false);
                return;
            }

            if (_value < 0)
            {
                PassValidation(false);
                return;
            }

            if (string.IsNullOrWhiteSpace(_textBoxName.Text))
            {
                PassValidation(false);
                return;
            }

            PassValidation(true);
        }

        private void PassValidation(bool status)
        {
            _buttonAdd.Enabled = status;
        }
    }
}