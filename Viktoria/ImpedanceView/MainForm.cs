using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class MainForm : Form
    {
        #region  -- Публичные методы -- 

        /// <summary>
        ///     Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _elementBindingSource.DataSource = _circuit.elements;
            ElementStorage.DataSource = _elementBindingSource;
            ElementStorage.MultiSelect = true;

            ImpedanceStorage.Columns.Add("Frequency", "Частота");
            _impedanceBindingSource.DataSource = _impedances;
            ImpedanceStorage.DataSource = _impedanceBindingSource;

            RandomButton.Visible = false;
            frequency.Checked = true;
#if DEBUG
            RandomButton.Visible = true;
#endif
        }

        #endregion

        /// <summary>
        ///     Подсказка, всплывающая при наведении на ячейку с номиналом элемента
        /// </summary>
        private void ElementStorage_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                var cell = ElementStorage.Rows[ElementStorage.Rows.Count - 1]
                    .Cells[1];
                cell.ToolTipText =
                    "Кликните один раз для выделения элемента с целью дальнейшего удаления." +
                    "\nКликните два раза для вызова окна редактирования элемента.";
            }
        }

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
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Создание списка частот и полная проверка корректности введенных для списка частот данных
        /// </summary>
        /// <returns></returns>
        private List<double> CreateFrequencyList()
        {
            try
            {
                // -- Проверка на корректность введенных данных --

                ValidationTools.IsEmpty(minFrequency);
                ValidationTools.IsEmpty(maxFrequency);
                ValidationTools.IsEmpty(step);

                ValidationTools.IsDouble(minFrequency);
                ValidationTools.IsDouble(maxFrequency);
                ValidationTools.IsDouble(step);

                var minFrequencyValue = Convert.ToDouble(minFrequency.Text);
                var maxFrequencyValue = Convert.ToDouble(maxFrequency.Text);
                var stepValue = Convert.ToDouble(step.Text);

                ValidationTools.IsCorrectFrequency(minFrequencyValue);
                ValidationTools.IsCorrectFrequency(maxFrequencyValue);
                ValidationTools.IsCorrectStep(stepValue);

                if (minFrequencyValue > maxFrequencyValue)
                {
                    throw new ArgumentException(
                        "Минимальное значение частоты не может превышать максимальное.");
                }

                if (stepValue > maxFrequencyValue - minFrequencyValue)
                {
                    throw new ArgumentException(
                        " Значение шага не может привышать разницу " +
                        "между максимальной и минимальной частотой");
                }

                // -- Конец проверки -- 

                var frequencyList = new List<double>();
                for (var i = minFrequencyValue; i <= maxFrequencyValue; i = i + stepValue)
                {
                    frequencyList.Add(i);
                }

                return frequencyList;
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
                return null;
            }
        }

        /// <summary>
        ///     Вычисление комплексного сопротивления для всех элементов в таблице
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var frequencyList = CreateFrequencyList();
            _impedanceBindingSource.Clear();
            if (frequencyList != null)
            {
                if (frequency.Checked)
                {
                    _circuit.isAngular = true;
                }
                var impedances = _circuit.CalculateImpedance(frequencyList);
                _impedanceBindingSource.DataSource = impedances;
                var index = 0;
                foreach (var frequency in frequencyList)
                {
                    ImpedanceStorage.Rows[index].Cells[0].Value = frequency;
                    index++;
                }
            }
        }

        /// <summary>
        ///     Удаление выбранного элемента
        /// </summary>
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            for (var n = _circuit.elements.Count - 1; n >= 0; n--)
            {
                if (ElementStorage.Rows[_circuit.elements.IndexOf(_circuit.elements[n])]
                    .Selected)
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
                    break;
                case 1:
                    element = new Resistor(value);
                    _elementBindingSource.Add(element);
                    break;
                case 2:
                    element = new Capacitor(value);
                    _elementBindingSource.Add(element);
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
                    _circuit.elements.Add(new Capacitor(1.66));
                    break;
                }
                case 1:
                {
                    _circuit.elements.Add(new Resistor(2.1));
                    _circuit.elements.Add(new Resistor(2.16));
                    _circuit.elements.Add(new Capacitor(2.53));
                    _circuit.elements.Add(new Inductor(2.16));
                    _circuit.elements.Add(new Resistor(2.1));
                    _circuit.elements.Add(new Capacitor(2.56));
                    break;
                }
                case 2:
                {
                    _circuit.elements.Add(new Inductor(3.16));
                    _circuit.elements.Add(new Resistor(3.1));
                    _circuit.elements.Add(new Inductor(3.36));
                    _circuit.elements.Add(new Resistor(3.1));
                    _circuit.elements.Add(new Capacitor(3.63));
                    break;
                }
                case 3:
                {
                    _circuit.elements.Add(new Resistor(4.1));
                    _circuit.elements.Add(new Resistor(4.1));
                    _circuit.elements.Add(new Resistor(4.1));
                    _circuit.elements.Add(new Resistor(4.1));
                    break;
                }
                case 4:
                {
                    _circuit.elements.Add(new Capacitor(5.73));
                    _circuit.elements.Add(new Inductor(5.89));
                    _circuit.elements.Add(new Inductor(5.56));
                    _circuit.elements.Add(new Resistor(5.1));
                    _circuit.elements.Add(new Inductor(5.16));
                    break;
                }
                case 5: break;
            }
            _elementBindingSource.DataSource = null;
            _elementBindingSource.DataSource = _circuit.elements;
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
    }
}