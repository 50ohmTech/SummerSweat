using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class MainForm : Form
    {

        #region -- Закрытые поля --

        #region -- Readonly --

        /// <summary>
        ///     Связующий elements и ElementStorage список
        /// </summary>
        private readonly BindingSource _elementBindingSource = new BindingSource();

        /// <summary>
        ///     Связующий impedances и ImpedanceStorage список
        /// </summary>
        private readonly BindingSource _impedanceBindingSource = new BindingSource();

        /// <summary>
        ///     Список значений сорпотивлений цепи при разных частотах
        /// </summary>
        private readonly List<Complex> _impedances = new List<Complex>();

        /// <summary>
        ///     Цепь 
        /// </summary>
        private readonly Circuit _circuit = new Circuit();

        #endregion

        /// <summary>
        ///     Тип заранее заданной цепи в combobox
        /// </summary>
        private int _currentCircuit;

        #endregion

        #region  -- Публичные методы -- 

        /// <summary>
        ///     Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ElementStorage.Columns.Add("ElementType", "Элемент");
            _elementBindingSource.DataSource = _circuit.elements;
            ElementStorage.DataSource = _elementBindingSource;
            ElementStorage.MultiSelect = true;

            ImpedanceStorage.Columns.Add("Frequency", "Частота");
            _impedanceBindingSource.DataSource = _impedances;
            ImpedanceStorage.DataSource = _impedanceBindingSource;

            RandomButton.Visible = false;
#if DEBUG
            RandomButton.Visible = true;
#endif
        }

        #endregion

        #region -- Приватные методы --

        /// <summary>
        ///     Добавление нового элемента
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var AddForm = new AddElementForm();
                if (AddForm.ShowDialog() == DialogResult.OK)
                {
                    var element = AddForm.NewElement;
                    _elementBindingSource.Add(element);
                    ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0].Value =
                        element.ToString();
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        ///     Вычисление комплексного сопротивления для всех элементов в таблице
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // -- Проверка на корректность введенных данных --

                ValidationTools.IsEmpty(this.minFrequency);
                ValidationTools.IsEmpty(this.maxFrequency);
                ValidationTools.IsEmpty(this.step);

                ValidationTools.IsDouble(this.minFrequency);
                ValidationTools.IsDouble(this.maxFrequency);
                ValidationTools.IsDouble(this.step);

                var minFrequency = Convert.ToDouble(this.minFrequency.Text);
                var maxFrequency = Convert.ToDouble(this.maxFrequency.Text);
                var step = Convert.ToDouble(this.step.Text);

                ValidationTools.IsCorrectFrequency(minFrequency);
                ValidationTools.IsCorrectFrequency(maxFrequency);
                ValidationTools.IsCorrectStep(step);

                if (minFrequency > maxFrequency)
                {
                    throw new ArgumentException(
                        "Минимальное значение частоты не может превышать максимальное.");
                }

                if (step > maxFrequency - minFrequency)
                {
                    throw new ArgumentException(
                        " Значение шага не может привышать разницу " +
                        "между максимальной и минимальной частотой");
                }

                if (!angularFrequency.Checked && !frequency.Checked)
                {
                    MessageBox.Show("Выберите тип частоты.", "Error",
                        MessageBoxButtons.OK);
                }

                // -- Конец проверки -- 

                _impedanceBindingSource.Clear();

                if (frequency.Checked)
                {
                    _circuit.isAngular = true;
                }
                var impedances = _circuit.CalculateImpedance(minFrequency, maxFrequency,
                    step);
                _impedanceBindingSource.DataSource = impedances;
                var index = 0;
                for (var i = minFrequency; i <= maxFrequency; i = i + step)
                {
                    ImpedanceStorage.Rows[index].Cells[0].Value = i;
                    index++;
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        ///     Удаление выбранного элемента
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            for (var n = _circuit.elements.Count - 1; n >= 0; n--)
            {
                if (ElementStorage.Rows[_circuit.elements.IndexOf(_circuit.elements[n])].Selected)
                {
                    _elementBindingSource.Remove(_circuit.elements[n]);
                }
            }
        }

#if DEBUG
        /// <summary>
        ///     Создание рандомного элемента
        /// </summary>
        private void RandomButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var elementType = random.Next(0, 3);
            var value = random.NextDouble() * random.Next(1, 15);
            IElement element;
            switch (elementType)
            {
                case 0:
                    element = new Inductor(value);
                    _elementBindingSource.Add(element);
                    ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0]
                            .Value = element.ToString();
                    break;
                case 1:
                    element = new Resistor(value);
                    _elementBindingSource.Add(element);
                    ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0]
                            .Value = element.ToString();
                    break;
                case 2:
                    element = new Capacitor(value);
                    _elementBindingSource.Add(element);
                    ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0]
                            .Value = element.ToString();
                    break;
            }
        }
#endif

        /// <summary>
        ///     Функция для модификации элемента. Вызывается двойным нажатием по ячейке с нужным элементом.
        /// </summary>
        private void ElementStorage_CellDoubleClick(object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                var index = ElementStorage.CurrentCell.RowIndex;
                var ModifyForm = new AddElementForm(_circuit.elements[index], true);
                if (ModifyForm.ShowDialog() == DialogResult.OK)
                {
                    var element = ModifyForm.NewElement;
                    _elementBindingSource.Remove(_circuit.elements[index]);
                    _elementBindingSource.Insert(index, element);
                    ElementStorage.Rows[index].Cells[0].Value = element.ToString();
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        ///     Метод для создания заранее заданных цепей
        /// </summary>
        private void CreateComboBoxCircuits()
        {
            _elementBindingSource.Clear();
            _circuit.elements.Clear();
            switch (_currentCircuit)
            {
                case 0:
                {
                    _circuit.elements.Add(new Resistor(1.1));
                    _circuit.elements.Add(new Inductor(1.16));
                    _circuit.elements.Add(new Capacitor(1.5663));
                    break;
                }
                case 1:
                {
                    _circuit.elements.Add(new Resistor(2.1));
                    _circuit.elements.Add(new Resistor(2.16));
                    _circuit.elements.Add(new Capacitor(2.5663));
                    _circuit.elements.Add(new Inductor(2.16));
                    _circuit.elements.Add(new Resistor(2.1));
                    _circuit.elements.Add(new Capacitor(2.5663));
                    break;
                }
                case 2:
                {
                    _circuit.elements.Add(new Inductor(0.16));
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Inductor(0.16));
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Capacitor(1.5663));
                    break;
                }
                case 3:
                {
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Resistor(5.1));
                    break;
                }
                case 4:
                {
                    _circuit.elements.Add(new Capacitor(1.5663));
                    _circuit.elements.Add(new Inductor(0.16));
                    _circuit.elements.Add(new Inductor(0.16));
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Inductor(0.16));
                    break;
                }
                case 5: break;
            }
            _elementBindingSource.DataSource = null;
            _elementBindingSource.DataSource = _circuit.elements;
            for (var n = 0; n <= _elementBindingSource.Count - 1; n++)
            {
                ElementStorage.Rows[n].Cells[0].Value =
                    _circuit.elements[n].ToString();
            }
        }

        /// <summary>
        ///     Обработка изменения значения в combobox с созданием выбранной цепи
        /// </summary>
        private void CircuitType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentCircuit = ((ComboBox) sender).SelectedIndex;
            CreateComboBoxCircuits();
        }

        #endregion

        /// <summary>
        ///     Подсказка, ввсплывающая при наведении на ячейку с номиналом элемента
        /// </summary>
        private void ElementStorage_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                DataGridViewCell cell = ElementStorage.Rows[ElementStorage.Rows.Count - 1]
                    .Cells[1];
                cell.ToolTipText = "Кликните один раз для выделения элемента с целью дальнейшего удаления." +
                                   "\nКликните дважды для вызова окна редактирования элемента.";
            }
        }
    }
}