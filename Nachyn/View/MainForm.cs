using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DrawingTool;
using Model;
using Model.ComboBoxType;
using Model.Elements;
using Model.Factories;

namespace View
{
    /// <summary>
    ///     Главная форма расчета импедансов
    /// </summary>
    public partial class MainForm : Form
    {
        #region Public

        /// <summary>
        ///     Конструктор
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _drawer = new CircuitDrawer(_panelCircuit, _circuit);
            //Paint += MainForm_Paint;

            InitializeComboBoxType();
            _branchBindingSource.DataSource = _circuit.Branches;    
        }

        #endregion

        #region Private

        private CircuitDrawer _drawer;

        /// <summary>
        ///     Рандом
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        ///     Цепь
        /// </summary>
        private readonly Circuit _circuit = new Circuit();


        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            _drawer.DrawCircuit();
        }

        private void ToolStripButtonAdd_Click(object sender, EventArgs e)
        {
           // new ElementManagerForm(_circuit.Branches, _drawer.ViewElements).ShowDialog();
            _drawer.DrawCircuit();
        }

        private void ToolStripButtonClearCircuit_Click(object sender, EventArgs e)
        {
            if (_circuit.IsEmpty)
            {
                MessageBox.Show("Цепь пуста!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show("Очистить цепь?",
                "Подтвердите",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _branchBindingSource.DataSource = null;
                _drawer.ClearCircuit();             
                _branchBindingSource.DataSource = _circuit.Branches;
            }
        }

        


        private void ToolStripButtonCalculate_Click(object sender, EventArgs e)
        {
            if (_circuit.IsEmpty)
            {
                MessageBox.Show("Цепь пуста!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            new CalculationsForm(_circuit).ShowDialog();
        }


        private void ToolStripRandomizeCircuit_Click(object sender, EventArgs e)
        {
            _drawer.ClearCircuit();
            

            for (uint group = 0; group < _random.Next(5) + 1; group++)
            {
                for (uint branchGroup = 0;
                    branchGroup < _random.Next(7) + 1;
                    branchGroup++)
                {
                    Branch randomBranch = new Branch(group);

                    for (uint countElements = 0;
                        countElements < _random.Next(4) + 1;
                        countElements++)
                    {
                        ElementBase randomElement = ElementFactory.GetRandomInstance();
                        _drawer.ViewElements.Add(new ViewElement(randomElement,
                            randomBranch.Elements));

                        randomBranch.Elements.Add(randomElement);
                    }

                    _branchBindingSource.Add(randomBranch);
                }
            }

            _branchBindingSource.DataSource = null;
            _branchBindingSource.DataSource = _circuit.Branches;
            _drawer.DrawCircuit();
        }

        private void ToolStripButtonHelp_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }

        /// <summary>
        ///     Показать инструкцию
        /// </summary>
        private static void ShowInfo()
        {
            string info =
                "* Добавляете ветви и элементы в главной форме \r\n" +
                "  или получаете случайную цепь в \"Цепь\"\r\n" +
                "* Вводите частоты и получаете результаты в \"Расчеты\"\r\n" +
                "\r\n* Чтоб удалить или изменить номинал на уже созданном элементе\r\n" +
                "необходимо нажать правой кнопкой мыши на элемент.";

            MessageBox.Show(info, "Инструкция");
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ShowInfo();
        }

        #endregion

        #region EditCircuit

        /// <summary>
        ///     Номинал
        /// </summary>
        private double _value;

        /// <summary>
        ///     Входной узел
        /// </summary>
        private uint _nodeIn;

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

                    _drawer.ViewElements.Add(new ViewElement(newElement,
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
        /// <param name="message">Сообщение</param>
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

        private void нарисоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawer.DrawCircuit();
            _branchBindingSource.DataSource = null;
            _branchBindingSource.DataSource = _circuit.Branches;
        }

        private void _dataGridViewBranches_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}