using Model;
using Model.Elements;
using Model.Enums;
using Model.EventArgs;
using Model.Tree;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using View.ConstraintTools;

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

        /// <summary>
        /// Создатель деревьев элементов.
        /// </summary>
        public TreesCreator TreesCreator { get; }

        #endregion

        #region - - Публичные методы - -

        /// <summary>
        /// Конструктор класса CreateForm.
        /// </summary>
        public CreateForm()
        {
            InitializeComponent();
            
            TreesCreator = new TreesCreator();
            Circuit = new Circuit(TreesCreator.Trees[0]);

            for (var i = 0; i < 6; i++)
            {
                TreesCreator.Trees[i].ElementsChanged += Circuit_ElementsChanged;
            }

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
            //TODO: вынести создание тестовых цепей в отдельный класс.
            //+
            //TODO: Цепи не должны создаваться/пересоздаваться при смене комбобокса!
            //+
            if (circuitComboBox.SelectedIndex >= 0 && circuitComboBox.SelectedIndex < 6)
            {
                Circuit.Elements = TreesCreator.Trees[circuitComboBox.SelectedIndex];
                Circuit_ElementsChanged(Circuit.Elements,
                    new ElementChangeEventArgs(ElementsChangeType.ChangeTree));
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Обновить данные о элементах цепи в таблице.
        /// </summary>
        /// <param name="root">Корень поддерева.</param>
        private void RefreshGridView(Node root)
        {
            if (root.Element != null)
            {
                elementGridView.Rows.Add(root.Element.Name, root.Element.Value);
                return;
            }

            foreach (var child in root.Childs)
            {
                RefreshGridView(child);
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

            NumberBoxConstraintTools.ChangeSeparator(valueBox);

            var value = double.Parse(valueBox.Text);

            if (!ValueConstraintTools.IsCorrectNominal(value)) return;

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
                            (ConnectionType)connectionComboBox.SelectedIndex);
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
                            (ConnectionType)connectionComboBox.SelectedIndex);
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
                            (ConnectionType)connectionComboBox.SelectedIndex);
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
            NumberBoxConstraintTools.PressDouble(e,
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

            if (!ValueConstraintTools.IsCorrectNominal(value))
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
            NumberBoxConstraintTools.PressDouble(e, ((TextBox)sender).Text);
        }

        /// <summary>
        /// Подготовить текстовое поле к вводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void ValueBox_Enter(object sender, EventArgs e)
        {
            NumberBoxConstraintTools.Enter(sender);
        }

        /// <summary>
        /// Подготовить текстовое поле к выводу.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void ValueBox_Leave(object sender, EventArgs e)
        {
            NumberBoxConstraintTools.Leave(sender);
        }

        /// <summary>
        /// Обновить графическое представление цепи.
        /// </summary>
        /// <param name="sender">Отправитель события.</param>
        /// <param name="e">Параметры события.</param>
        private void Circuit_ElementsChanged(object sender, ElementChangeEventArgs e)
        {
            var isElementsNotEmpty = Circuit.Elements.Count != 0;
            label4.Visible = isElementsNotEmpty;
            label5.Visible = isElementsNotEmpty;
            connectionComboBox.Visible = isElementsNotEmpty;

            switch (e.Type)
            {
                case ElementsChangeType.ChangeTree:
                    elementGridView.Rows.Clear();
                    RefreshGridView(Circuit.Elements.Root);
                    break;
                case ElementsChangeType.Add:
                    elementGridView.Rows.Add(e.Element.Name, e.Element.Value);
                    break;
                case ElementsChangeType.Delete:
                    UpdateNameGrid();
                    elementGridView.Rows.Remove(elementGridView.SelectedRows[0]);
                    break;
                case ElementsChangeType.Clear:
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

            var displacement = new Point(15, 0);
            Drawer.DrawCircuit(Circuit.Elements.Root, displacement);

            circuitPictureBox.Image = bitmapBackground;
        }

        /// <summary>
        /// Обновить имя элемента в таблице.
        /// </summary>
        private void UpdateNameGrid()
        {
            var deleteSymbol =
                elementGridView.SelectedRows[0].Cells[0].Value.ToString()[0];

            var deleteNumber = uint.Parse(elementGridView.SelectedRows[0].Cells[0].Value
                .ToString().Substring(1));

            for (var i = 0;
                i < elementGridView.Rows.Count;
                i++)
            {
                var changeNumber = uint.Parse(elementGridView.Rows[i].Cells[0].Value
                    .ToString().Substring(1));

                if (elementGridView.Rows[i].Cells[0].Value.ToString()[0] ==
                    deleteSymbol &&
                    changeNumber > deleteNumber)
                {
                    elementGridView.Rows[i].Cells[0].Value =
                        deleteSymbol + (changeNumber - 1).ToString();
                }
            }
        }

        #endregion
    }
}