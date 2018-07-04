using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using ImpedanceModel;

namespace ImpedanceView
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///     Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            ElementStorage.Columns.Add("ElementType", "Элемент");
            _bindingSource.DataSource = elements;
            ElementStorage.DataSource = _bindingSource;
            ElementStorage.MultiSelect = true;

            ImpedanceStorage.Columns.Add("Frequency", "Частота");
            bindingSource.DataSource = impedances;
            ImpedanceStorage.DataSource = bindingSource;

            RandomButton.Visible = false;
#if DEBUG
            RandomButton.Visible = true;
#endif
        }

        /// <summary>
        ///     Кнопка добавления нового элемента
        /// </summary>
        private void Add_button_Click(object sender, EventArgs e)
        {
            try
            {
                var AddForm = new AddElementForm();
                if (AddForm.ShowDialog() == DialogResult.OK)
                {
                    var element = AddForm.NewElement;
                    _bindingSource.Add(element);
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
        ///     Кнопка для вычисления комплексного сопротивления для всех элементов в таблице
        /// </summary>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ValidationTools.IsEmpty(this.minFrequency);
                ValidationTools.IsEmpty(this.maxFrequency);
                ValidationTools.IsEmpty(Step);

                ValidationTools.IsDouble(this.minFrequency);
                ValidationTools.IsDouble(this.maxFrequency);
                ValidationTools.IsDouble(Step);

                var minFrequency = Convert.ToDouble(this.minFrequency.Text);
                var maxFrequency = Convert.ToDouble(this.maxFrequency.Text);
                var step = Convert.ToDouble(Step.Text);

                ValidationTools.IsLessThenNull(minFrequency);
                ValidationTools.IsLessThenNull(step);

                if (minFrequency > maxFrequency)
                {
                    throw new ArgumentException(
                        "Минимальное значение частоты не может превышать максимальное.");
                }

                bindingSource.Clear();

                if (angularFrequency.Checked)
                {
                    for (var i = minFrequency; i <= maxFrequency; i = i + step)
                    {
                        impedance = 0;
                        for (var n = 0; n <= _bindingSource.Count - 1; n++)
                        {
                            impedance += elements[n].GetImpedanceUsingAngularFrequency(i);
                        }
                        bindingSource.Add(impedance);
                        ImpedanceStorage.Rows[bindingSource.Count - 1].Cells[0].Value = i;
                    }
                }
                else if (frequency.Checked)
                {
                    for (var i = minFrequency; i <= maxFrequency; i = i + step)
                    {
                        impedance = 0;
                        for (var n = 0; n <= _bindingSource.Count - 1; n++)
                        {
                            impedance += elements[n].GetImpedanceUsingFrequency(i);
                        }
                        bindingSource.Add(impedance);
                        ImpedanceStorage.Rows[bindingSource.Count - 1].Cells[0].Value = i;
                    }
                }
                else
                {
                    MessageBox.Show("Выберите тип частоты.", "Error",
                        MessageBoxButtons.OK);
                }
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        ///     Кнопка удаления элементов
        /// </summary>
        private void Remove_button_Click(object sender, EventArgs e)
        {
            for (var n = elements.Count - 1; n >= 0; n--)
            {
                if (ElementStorage.Rows[elements.IndexOf(elements[n])].Selected)
                {
                    _bindingSource.Remove(elements[n]);
                }
            }
        }

#if DEBUG
        /// <summary>
        ///     Кнопка для создания рандомных данных
        /// </summary>
        private void RandomButton_Click(object sender, EventArgs e)
        {
            var random = new Random();
            for (var i = 0; i < 5; i++)
            {
                var elementType = random.Next(0, 3);
                var value = random.NextDouble() * random.Next(1, 15);
                IElement element;
                switch (elementType)
                {
                    case 0:
                        element = new Inductor(value);
                        _bindingSource.Add(element);
                        ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0]
                                .Value =
                            element.ToString();
                        break;
                    case 1:
                        element = new Resistor(value);
                        _bindingSource.Add(element);
                        ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0]
                                .Value =
                            element.ToString();
                        break;
                    case 2:
                        element = new Capacitor(value);
                        _bindingSource.Add(element);
                        ElementStorage.Rows[ElementStorage.Rows.Count - 1].Cells[0]
                                .Value =
                            element.ToString();
                        break;
                }
            }
        }
#endif

        /// <summary>
        ///     Функция для модификации элемента. Вызывается двойным нажатием по ячейке с нужным элементом.
        /// </summary>
        private void DataGridView1_CellDoubleClick(object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                var index = ElementStorage.CurrentCell.RowIndex;
                var ModifyForm = new AddElementForm(elements[index], true);
                if (ModifyForm.ShowDialog() == DialogResult.OK)
                {
                    var element = ModifyForm.NewElement;
                    _bindingSource.Remove(elements[index]);
                    _bindingSource.Insert(index, element);
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
            _bindingSource.Clear();
            elements.Clear();
            switch (_currentCircuit)
            {
                case 0:
                {
                    elements.Add(new Resistor(1.1));
                    elements.Add(new Inductor(1.16));
                    elements.Add(new Capacitor(1.5663));
                    break;
                }
                case 1:
                {
                    elements.Add(new Resistor(2.1));
                    elements.Add(new Resistor(2.16));
                    elements.Add(new Capacitor(2.5663));
                    elements.Add(new Inductor(2.16));
                    elements.Add(new Resistor(2.1));
                    elements.Add(new Capacitor(2.5663));
                    break;
                }
                case 2:
                {
                    elements.Add(new Inductor(0.16));
                    elements.Add(new Resistor(5.1));
                    elements.Add(new Inductor(0.16));
                    elements.Add(new Resistor(5.1));
                    elements.Add(new Capacitor(1.5663));
                    break;
                }
                case 3:
                {
                    elements.Add(new Resistor(5.1));
                    elements.Add(new Resistor(5.1));
                    elements.Add(new Resistor(5.1));
                    elements.Add(new Resistor(5.1));
                    break;
                }
                case 4:
                {
                    elements.Add(new Capacitor(1.5663));
                    elements.Add(new Inductor(0.16));
                    elements.Add(new Inductor(0.16));
                    elements.Add(new Resistor(5.1));
                    elements.Add(new Inductor(0.16));
                    break;
                }
                case 5: break;
            }
            _bindingSource.DataSource = null;
            _bindingSource.DataSource = elements;
            for (var n = 0; n <= _bindingSource.Count - 1; n++)
            {
                ElementStorage.Rows[n].Cells[0].Value =
                    elements[n].ToString();
            }
        }

        /// <summary>
        ///     Обработка изменения значения в combobox с созданием выбранной цепи
        /// </summary>
        private void circuitType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _currentCircuit = ((ComboBox) sender).SelectedIndex;
            CreateComboBoxCircuits();
        }

        #region Private fields

        /// <summary>
        ///     Связующий _elements и gridview список
        /// </summary>
        private readonly BindingSource _bindingSource = new BindingSource();

        private readonly BindingSource bindingSource = new BindingSource();

        /// <summary>
        ///     Список пассивных элементов
        /// </summary>
        public List<IElement> elements = new List<IElement>();

        /// <summary>
        ///     Список частот
        /// </summary>
        public List<double> frequencies = new List<double>();

        private readonly List<Complex> impedances = new List<Complex>();
        private Complex impedance;

        private int _currentCircuit;

        #endregion
    }
}