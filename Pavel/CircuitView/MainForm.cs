using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CircuitModel;
namespace CircuitView
{
    /// <summary>
    /// Форма для формирования цепи.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Поля

        /// <summary>
        /// Количество резисторов в цепи.
        /// </summary>
        private uint _resistorIterator;

        /// <summary>
        /// Количество конденсаторов в цепи.
        /// </summary>
        private uint _capacitorIterator;

        /// <summary>
        /// Количество катушек индуктивности в цепи.
        /// </summary>
        private uint _inductorIterator;

        #endregion

        #region Свойства

        /// <summary>
        /// Электрическая цепь
        /// </summary>
        private static List<ElementBase> _elements;

        #endregion

        #region Публичные методы

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public Circuit Circuit => new Circuit(_elements);

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _elements = new List<ElementBase>();
            NominalTextBox.ContextMenu = new ContextMenu();

            ElementsBindingSource.DataSource = _elements;
            ElementsGridView.DataSource = ElementsBindingSource;
            
            _resistorIterator = 0;
            _capacitorIterator = 0;
            _inductorIterator = 0;
            CircuitComboBox.SelectedIndex = 0;
        }
        /// <summary>
        /// Добавление элемента в цепь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ResistorRadioButton.Checked)
            {
                ElementsBindingSource.Add(new Resistor(
                    "R" + ++_resistorIterator,
                    double.Parse(NominalTextBox.Text)));
            }
            else if (CapacitorRadioButton.Checked)
            {
                ElementsBindingSource.Add(new Capacitor(
                    "C" + ++_capacitorIterator,
                    double.Parse(NominalTextBox.Text)));
            }
            else if (InductorRadioButton.Checked)
            {
                ElementsBindingSource.Add(new Inductor(
                    "I" + ++_inductorIterator,
                    double.Parse(NominalTextBox.Text)));
            }
            else
            {
                MessageBox.Show(
                    "Выберите тип элемента", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Удаление элемента из цепи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in ElementsGridView.SelectedRows)
            {
                ElementsGridView.Rows.Remove(row);
            }
        }
        /// <summary>
        /// Выбор цепи.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CircuitComboBox.SelectedIndex == 0)
            {
                Update(new List<ElementBase>(), 0, 0, 0);
            }
            else if (CircuitComboBox.SelectedIndex == 1)
            {
                var elements = new List<ElementBase>
                {
                    new Resistor("R1",1),
                    new Resistor("R2",2),
                    new Resistor("R3",3),
                    new Capacitor("C1",2.3),
                    new Inductor("I1",99.3)
                };
                Update(elements, 3, 1, 1);
            }
            else if (CircuitComboBox.SelectedIndex == 2)
            {
                var elements = new List<ElementBase>
                {
                    new Resistor("R1",1),
                    new Resistor("R2",2.1),
                    new Inductor("I1",99.3),
                    new Capacitor("C1",2.2),
                    new Inductor("I2",9.2)
                };
                Update(elements, 2, 1, 2);
            }

            else if(CircuitComboBox.SelectedIndex == 3)
            {
                var elements = new List<ElementBase>
                {
                    new Resistor("R1",11),
                    new Resistor("R2",12),
                    new Resistor("R3",1.3),
                    new Inductor("I1",4),
                    new Inductor("I2",4.3)
                };
                Update(elements, 3, 0, 2);
            }
            else if (CircuitComboBox.SelectedIndex == 4)
            {
                var elements = new List<ElementBase>
                {
                    new Resistor("C1",155),
                    new Resistor("R1", 1),
                    new Resistor("C2",5.6),
                    new Inductor("I1",7),
                    new Inductor("I2",9.1)
                };
                Update(elements, 1, 2, 2);
            }
            else if (CircuitComboBox.SelectedIndex == 5)
            {
                var elements = new List<ElementBase>
                {
                    new Resistor("R1",55),
                    new Resistor("R2",23.3),
                    new Resistor("R3",22),
                    new Inductor("R4",21),
                    new Inductor("I2",7.3)
                };
                Update(elements, 4, 0, 1);
            }
        }
        /// <summary>
        /// Обновление цепи
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="resistorIterator"></param>
        /// <param name="capacitorIterator"></param>
        /// <param name="inductorIterator"></param>
        public void Update(List<ElementBase> elements, uint resistorIterator,
            uint capacitorIterator, uint inductorIterator)
        {
            _resistorIterator = resistorIterator;
            _capacitorIterator = capacitorIterator;
            _inductorIterator = inductorIterator;

            ElementsBindingSource.Clear();

            foreach (var element in elements)
            {
                ElementsBindingSource.Add(element);
            }
        }
        /// <summary>
        /// Расчитать импедансы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (ElementsGridView.RowCount == 0)
            {
                MessageBox.Show("Добавьте элементы в цепь", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var calculateForm = new CalculateForm { Owner = this };
            calculateForm.ShowDialog();
        }

        private void ElementsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Некорректный ввод символов", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        #endregion

    }
}
