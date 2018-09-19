using Model;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Форма создания цепи.
    /// </summary>
    public partial class CreateForm : Form
    {
        #region - - Свойства - -

        /// <summary>
        /// Электрическая цепь.
        /// </summary>
        public Circuit Circuit { get; }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CreateForm.
        /// </summary>
        public CreateForm()
        {
            InitializeComponent();
            
            Circuit = new Circuit(new ElementsTree());

            Circuit.Elements.ElementsChanged += Circuit_ElementsChanged;

            valueBox.ContextMenu = new ContextMenu();
            circuitComboBox.SelectedIndex = 0;
            elementComboBox.SelectedIndex = 0;
            connectionComboBox.SelectedIndex = 0;
        }

        #endregion

        #region - - Приватные методы - -

        /// <summary>
        /// Выбрать цепь.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (circuitComboBox.SelectedItem)
            {
                case "Создать цепь":
                    Circuit.Elements.Clear();

                    break;
                case "Цепь 1":
                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Resistor("R1", 5));
                    Circuit.Elements.Add(new Resistor("R2", 10), "R1", false);
                    Circuit.Elements.Add(new Resistor("R3", 20), "R1", true);
                    Circuit.Elements.Add(new Resistor("R4", 5), "R1", true);
                    Circuit.Elements.Add(new Resistor("R5", 5), "R1", false);
                    Circuit.Elements.Add(new Resistor("R6", 20), "R5", true);
                    Circuit.Elements.Add(new Resistor("R7", 5), "R4", false);
                    Circuit.Elements.Add(new Resistor("R8", 10), "R4", false);
                    Circuit.Elements.Add(new Resistor("R9", 15), "R7", false);
                    Circuit.Elements.Add(new Resistor("R10", 10), "R7", true);

                    break;
                case "Цепь 2":
                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Capacitor("C1", 66.666));
                    Circuit.Elements.Add(new Inductor("I1", 0.02), "C1", false);
                    Circuit.Elements.Add(new Resistor("R1", 20.56), "I1", true);
                    Circuit.Elements.Add(new Inductor("I2", 0.7), "C1", false);

                    break;
                case "Цепь 3":
                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Resistor("R1", 95));
                    Circuit.Elements.Add(new Capacitor("C1", 38), "R1", false);
                    Circuit.Elements.Add(new Inductor("I1", 0.5), "C1", true);
                    Circuit.Elements.Add(new Capacitor("C2", 32.8), "R1", true);
                    Circuit.Elements.Add(new Resistor("R2", 20), "I1", false);
                    Circuit.Elements.Add(new Capacitor("C3", 66.666), "C2", false);
                    Circuit.Elements.Add(new Resistor("R3", 222), "C2", false);

                    break;
                case "Цепь 4":
                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Inductor("I1", 0.02));
                    Circuit.Elements.Add(new Resistor("R1", 38), "I1", true);
                    Circuit.Elements.Add(new Capacitor("C1", 59.9), "I1", false);
                    Circuit.Elements.Add(new Inductor("I2", 0.28), "C1", true);
                    Circuit.Elements.Add(new Resistor("R2", 80.98), "I2", false);
                    Circuit.Elements.Add(new Capacitor("C2", 25), "R2", true);

                    break;
                case "Цепь 5":
                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Resistor("R1", 33.5));
                    Circuit.Elements.Add(new Capacitor("C1", 10), "R1", false);
                    Circuit.Elements.Add(new Inductor("I1", 0.003), "C1", true);
                    Circuit.Elements.Add(new Resistor("R2", 20), "I1", true);
                    Circuit.Elements.Add(new Resistor("R3", 43.21), "R2", false);

                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Рассчитать импедансы цепи для диапазона частот.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (Circuit.Elements.Count == 0)
            {
                MessageBox.Show("Добавьте элементы в цепь", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var calculateForm = new CalculateForm {Owner = this};
            calculateForm.ShowDialog();
        }

        /// <summary>
        /// Обработать добавление элемента.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Circuit.Elements.Count >= 12)
            {
                MessageBox.Show("Цепь может содержать до 12 элементов", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            NumberBox.ChangeSeparator(valueBox);

            var value = double.Parse(valueBox.Text);

            if (!ConstraintTools.IsCorrectNominal(value)) return;

            var isElementsNotEmpty = Circuit.Elements.Count != 0;
            AddElement(isElementsNotEmpty);
        }

        /// <summary>
        /// Добавить элемент в цепь.
        /// </summary>
        /// <param name="isElementsNotEmpty">Истина, если список не пуст, иначе - ложь.</param>
        private void AddElement(bool isElementsNotEmpty)
        {
            switch (elementComboBox.SelectedItem)
            {
                case "Резистор":
                    if (isElementsNotEmpty)
                    {
                        Circuit.Elements.Add(new Resistor(
                                "R" + (Circuit.Elements.ResistorCount + 1),
                                double.Parse(valueBox.Text)),
                            elementGridView.SelectedRows[0].Cells[0].Value.ToString(),
                            connectionComboBox.SelectedIndex == 0);
                    }
                    else
                    {
                        Circuit.Elements.Add(new Resistor(
                            "R" + (Circuit.Elements.ResistorCount + 1),
                            double.Parse(valueBox.Text)));
                    }

                    break;
                case "Конденсатор":
                    if (isElementsNotEmpty)
                    {
                        Circuit.Elements.Add(new Capacitor(
                                "C" + (Circuit.Elements.CapacitorCount + 1),
                                double.Parse(valueBox.Text)),
                            elementGridView.SelectedRows[0].Cells[0].Value.ToString(),
                            connectionComboBox.SelectedIndex == 0);
                    }
                    else
                    {
                        Circuit.Elements.Add(new Capacitor(
                            "C" + (Circuit.Elements.CapacitorCount + 1),
                            double.Parse(valueBox.Text)));
                    }

                    break;
                case "Катушка":
                    if (isElementsNotEmpty)
                    {
                        Circuit.Elements.Add(new Inductor(
                                "I" + (Circuit.Elements.InductorCount + 1),
                                double.Parse(valueBox.Text)),
                            elementGridView.SelectedRows[0].Cells[0].Value.ToString(),
                            connectionComboBox.SelectedIndex == 0);
                    }
                    else
                    {
                        Circuit.Elements.Add(new Inductor(
                            "I" + (Circuit.Elements.InductorCount + 1),
                            double.Parse(valueBox.Text)));
                    }

                    break;
                default:
                    MessageBox.Show(
                        "Выберите тип элемента", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    break;
            }
        }

        /// <summary>
        /// Удалить элемент из цепи.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (elementGridView.SelectedRows.Count == 1)
            {
                Circuit.Elements.Delete(elementGridView.SelectedRows[0].Cells[0].Value
                    .ToString());
            }
            else
            {
                MessageBox.Show(
                    "Выберите один элемент из списка",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установить параметры работы с ячейкой таблицы.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void ElementGridView_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.ContextMenu = new ContextMenu();

            e.Control.KeyPress -= Cell_KeyPress;
            e.Control.KeyPress += Cell_KeyPress;

            e.Control.Leave -= Cell_Leave;
            e.Control.Leave += Cell_Leave;
        }

        /// <summary>
        /// Ограничить ввод символов для ячейки таблицы.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e,
                ((DataGridViewTextBoxEditingControl)sender).Text);
        }

        /// <summary>
        /// Сохранить новое значение.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void Cell_Leave(object sender, EventArgs e)
        {
            var index = ((DataGridViewTextBoxEditingControl) sender)
                .EditingControlRowIndex;
            var name = elementGridView.Rows[index].Cells[0].Value.ToString();
            var element = Circuit.Elements.Search(Circuit.Elements.Root, name).Element;

            if (!double.TryParse(((DataGridViewTextBoxEditingControl) sender).Text,
                out var value))
            {
                ((DataGridViewTextBoxEditingControl) sender).Text =
                    element.Value.ToString(CultureInfo.InvariantCulture);

                return;
            }

            if (!ConstraintTools.IsCorrectNominal(value))
            {
                ((DataGridViewTextBoxEditingControl) sender).Text =
                    element.Value.ToString(CultureInfo.InvariantCulture);
                return;
            }

            ((DataGridViewTextBoxEditingControl) sender).Text =
                value.ToString(CultureInfo.InvariantCulture);

            element.Value = value;
        }

        /// <summary>
        /// Ограничить ввод символов для текстового поля.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void ValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox)sender).Text);
        }

        /// <summary>
        /// Подготовить текстовое поле к вводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void ValueBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        /// <summary>
        /// Подготовить текстовое поле к выводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void ValueBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }

        /// <summary>
        /// Обновить графическое представление цепи.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void Circuit_ElementsChanged(object sender, ChangedEventArgs e)
        {
            var isElementsNotEmpty = Circuit.Elements.Count != 0;
            label4.Visible = isElementsNotEmpty;
            label5.Visible = isElementsNotEmpty;
            connectionComboBox.Visible = isElementsNotEmpty;

            switch (e.Type)
            {
                case ChangeType.Add:
                    elementGridView.Rows.Add(e.Element.Name, e.Element.Value);
                    break;
                case ChangeType.Delete:
                    UpdateNameGrid();
                    elementGridView.Rows.Remove(elementGridView.SelectedRows[0]);
                    break;
                case ChangeType.Clear:
                    elementGridView.Rows.Clear();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            circuitPictureBox.Image = null;
            var bitmapBackground = new Bitmap(1000, 1000);
            Drawer.Graphics = Graphics.FromImage(bitmapBackground);
            Drawer.Pen = new Pen(Color.Black, 1);
            Drawer.Font = Font;

            var displacement = new Point(50, 40);
            Drawer.DrawCircuit(Circuit.Elements.Root, displacement);

            circuitPictureBox.Image = bitmapBackground;
        }

        /// <summary>
        /// Обновить имя элемента в таблице.
        /// </summary>
        private void UpdateNameGrid()
        {
            var symbol = elementGridView.SelectedRows[0].Cells[0].Value.ToString()[0];
            var number = uint.Parse(elementGridView.SelectedRows[0].Cells[0].Value
                .ToString().Substring(1));

            for (var i = elementGridView.SelectedRows[0].Index + 1;
                i < elementGridView.Rows.Count;
                i++)
            {
                if (elementGridView.Rows[i].Cells[0].Value.ToString()[0] == symbol)
                {
                    elementGridView.Rows[i].Cells[0].Value = symbol + number++.ToString();
                }
            }
        }

        #endregion
    }
}
