using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using View.Properties;

namespace View
{
    /// <summary>
    /// Форма создания цепи.
    /// </summary>
    public partial class CreateForm : Form
    {
        #region - - Поля - -

        /// <summary>
        /// Количество резисторов в цепи.
        /// </summary>
        private uint _resistorCounter;

        /// <summary>
        /// Количество конденсаторов в цепи.
        /// </summary>
        private uint _capacitorCounter;

        /// <summary>
        /// Количество катушек индуктивности в цепи.
        /// </summary>
        private uint _inductorCounter;

        #endregion

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

            //KeyPreview = true;

            valueBox.ContextMenu = new ContextMenu();
            circuitComboBox.SelectedIndex = 0;
            elementComboBox.SelectedIndex = 0;
            connectionComboBox.SelectedIndex = 0;
        }

        #endregion

        #region - - Приватные методы - -

        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (circuitComboBox.SelectedItem)
            {
                case "Создать цепь":
                    _resistorCounter = 0;
                    _capacitorCounter = 0;
                    _inductorCounter = 0;

                    Circuit.Elements.Clear();
                    break;
                case "Цепь 1":
                    _resistorCounter = 10;
                    _capacitorCounter = 0;
                    _inductorCounter = 0;

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
                    _resistorCounter = 1;
                    _capacitorCounter = 1;
                    _inductorCounter = 2;

                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Capacitor("C1", 66.666));
                    Circuit.Elements.Add(new Inductor("I1", 0.02), "C1", false);
                    Circuit.Elements.Add(new Resistor("R1", 20.56), "I1", true);
                    Circuit.Elements.Add(new Inductor("I2", 0.7), "C1", false);
                    break;
                case "Цепь 3":
                    _resistorCounter = 3;
                    _capacitorCounter = 3;
                    _inductorCounter = 1;

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
                    _resistorCounter = 2;
                    _capacitorCounter = 2;
                    _inductorCounter = 2;

                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Inductor("I1", 0.02));
                    Circuit.Elements.Add(new Resistor("R1", 38), "I1", true);
                    Circuit.Elements.Add(new Capacitor("C1", 59.9), "I1", false);
                    Circuit.Elements.Add(new Inductor("I2", 0.28), "C1", true);
                    Circuit.Elements.Add(new Resistor("R2", 80.98), "I2", false);
                    Circuit.Elements.Add(new Capacitor("C2", 25), "R2", true);
                    break;
                case "Цепь 5":
                    _resistorCounter = 3;
                    _capacitorCounter = 1;
                    _inductorCounter = 1;

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

            if (value < double.Parse(Resources.minElementValue) ||
                value > double.Parse(Resources.maxElementValue))
            {
                MessageBox.Show(
                    "Номинал элемента должен быть\n больше " +
                    Resources.minElementValue + " и не превышать " +
                    Resources.maxElementValue,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (Circuit.Elements.Count == 0)
            {
                switch (elementComboBox.SelectedItem)
                {
                    case "Резистор":
                        Circuit.Elements.Add(new Resistor(
                            "R" + (++_resistorCounter).ToString(),
                            double.Parse(valueBox.Text)));

                        break;
                    case "Конденсатор":
                        Circuit.Elements.Add(new Capacitor(
                            "C" + (++_capacitorCounter).ToString(),
                            double.Parse(valueBox.Text)));

                        break;
                    case "Катушка":
                        Circuit.Elements.Add(new Inductor(
                            "I" + (++_inductorCounter).ToString(),
                            double.Parse(valueBox.Text)));

                        break;
                    default:
                        MessageBox.Show(
                            "Выберите тип элемента", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        break;
                }
            }
            else
            {
                if (elementGridView.SelectedRows.Count != 1)
                {
                    MessageBox.Show(
                        "Выберите один элемент из списка,\nс которым хотите соединить новый элемент",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (connectionComboBox.SelectedIndex != 0 && connectionComboBox.SelectedIndex != 1)
                {
                    MessageBox.Show(
                        "Выберите тип соединения", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                switch (elementComboBox.SelectedItem)
                {
                    case "Резистор":
                        Circuit.Elements.Add(new Resistor(
                                "R" + (++_resistorCounter).ToString(),
                                double.Parse(valueBox.Text)),
                            elementGridView.SelectedRows[0].Cells[0].Value.ToString(),
                            connectionComboBox.SelectedIndex == 0);

                        break;
                    case "Конденсатор":
                        Circuit.Elements.Add(new Capacitor(
                                "C" + (++_capacitorCounter).ToString(),
                                double.Parse(valueBox.Text)),
                            elementGridView.SelectedRows[0].Cells[0].Value.ToString(),
                            connectionComboBox.SelectedIndex == 0);

                        break;
                    case "Катушка":
                        Circuit.Elements.Add(new Inductor(
                                "I" + (++_inductorCounter).ToString(),
                                double.Parse(valueBox.Text)),
                            elementGridView.SelectedRows[0].Cells[0].Value.ToString(),
                            connectionComboBox.SelectedIndex == 0);

                        break;
                    default:
                        MessageBox.Show(
                            "Выберите тип элемента", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        break;
                }
            }
        }

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

        private void ElementGridView_EditingControlShowing(object sender,
            DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.ContextMenu = new ContextMenu();

            e.Control.KeyPress -= Cell_KeyPress;
            e.Control.KeyPress += Cell_KeyPress;

            e.Control.Leave -= Cell_Leave;
            e.Control.Leave += Cell_Leave;
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e,
                ((DataGridViewTextBoxEditingControl)sender).Text);
        }

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

            if (value < double.Parse(Resources.minElementValue) ||
                value > double.Parse(Resources.maxElementValue))
            {
                ((DataGridViewTextBoxEditingControl) sender).Text =
                    element.Value.ToString(CultureInfo.InvariantCulture);
                return;
            }

            ((DataGridViewTextBoxEditingControl) sender).Text =
                value.ToString(CultureInfo.InvariantCulture);

            element.Value = value;
        }

        private void ValueBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberBox.PressDouble(e, ((TextBox)sender).Text);
        }

        private void ValueBox_Enter(object sender, EventArgs e)
        {
            NumberBox.Enter(sender);
        }

        private void ValueBox_Leave(object sender, EventArgs e)
        {
            NumberBox.Leave(sender);
        }

        private void Circuit_ElementsChanged(object sender, ChangedEventArgs e)
        {
            if (Circuit.Elements.Count == 0)
            {
                label4.Visible = false;
                label5.Visible = false;
                connectionComboBox.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
                connectionComboBox.Visible = true;
            }
            
            switch (e.Type)
            {
                case ChangedEventArgs.ChangeType.Add:
                    elementGridView.Rows.Add(e.Element.Name, e.Element.Value);
                    break;
                case ChangedEventArgs.ChangeType.Delete:
                    elementGridView.Rows.Remove(elementGridView.SelectedRows[0]);
                    break;
                case ChangedEventArgs.ChangeType.Clear:
                    elementGridView.Rows.Clear();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            circuitPictureBox.Image = null;
            var bitmapBackground = new Bitmap(1000, 1000);
            var graphics = Graphics.FromImage(bitmapBackground);
            var pen = new Pen(Color.Black, 1);

            var displacement = new Point(50, 40);
            DrawCircuit(graphics, pen, Circuit.Elements.Root, displacement);

            circuitPictureBox.Image = bitmapBackground;
        }

        /// <summary>
        /// Рисовать схему электрической цепи.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        /// <param name="pen">Ручка.</param>
        /// <param name="node">Корень поддерева.</param>
        /// <param name="displacement">Смещение.</param>
        /// <returns>Размер поддерева.</returns>
        private Point DrawCircuit(Graphics graphics, Pen pen, ElementsTree.Node node,
            Point displacement)
        {
            if (node.Brood.Count == 0)
            {
                DrawElement(graphics, pen, node.Element, displacement);
                return new Point(1, 1);
            }

            int maxCount = 0;
            List<int> steps = new List<int>();

            if (node.IsSerial)
            {
                graphics.DrawLine(pen, new Point(displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X, 25 + displacement.Y));

                for (var i = 0; i < node.Brood.Count; i++)
                {
                    var count = DrawCircuit(graphics, pen, node.Brood[i],
                        new Point(25 + displacement.X,
                            steps.Sum() * 40 + displacement.Y));

                    steps.Add(count.Y);

                    if (maxCount < count.X)
                    {
                        var step = 0;
                        for (var j = 0; j < i; j++)
                        {
                            graphics.DrawLine(pen,
                                new Point(25 + maxCount * 50 + displacement.X,
                                    25 + step * 40 + displacement.Y),
                                new Point(25 + count.X * 50 + displacement.X,
                                    25 + step * 40 + displacement.Y));

                            step += steps[j];
                        }

                        maxCount = count.X;

                    }
                    else
                    {
                        var step = 0;
                        for (var j = 0; j < i; j++)
                        {
                            step += steps[j];
                        }

                        graphics.DrawLine(pen,
                            new Point(25 + count.X * 50 + displacement.X,
                                25 + step * 40 + displacement.Y),
                            new Point(25 + maxCount * 50 + displacement.X,
                                25 + step * 40 + displacement.Y));
                    }
                }

                graphics.DrawLine(pen,
                    new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(50 + maxCount * 50 + displacement.X, 25 + displacement.Y));


                graphics.DrawLine(pen,
                    new Point(25 + displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X,
                        25 + (steps.Sum() - steps[steps.Count - 1]) * 40 +
                        displacement.Y));

                graphics.DrawLine(pen,
                    new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(25 + maxCount * 50 + displacement.X,
                        25 + (steps.Sum() - steps[steps.Count - 1]) * 40 +
                        displacement.Y));

                return new Point(maxCount + 1, steps.Sum());
            }

            foreach (var child in node.Brood)
            {
                var count = DrawCircuit(graphics, pen, child,
                    new Point(steps.Sum() * 50 + displacement.X, displacement.Y));

                steps.Add(count.X);

                if (maxCount < count.Y)
                {
                    maxCount = count.Y;
                }
            }

            return new Point(steps.Sum(), maxCount);
        }

        /// <summary>
        /// Рисовать элемент электрической цепи.
        /// </summary>
        /// <param name="graphics">Поверхность рисования.</param>
        /// <param name="pen">Ручка.</param>
        /// <param name="element">Элемент электрической цепи.</param>
        /// <param name="displacement">Смещение.</param>
        private void DrawElement(Graphics graphics, Pen pen, ElementBase element,
            Point displacement)
        {
            var brush = new SolidBrush(Color.Black);
            switch (element)
            {
                case Resistor _:
                    graphics.DrawLine(pen,
                        new Point(10 + displacement.X, 20 + displacement.Y),
                        new Point(10 + displacement.X, 30 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(10 + displacement.X, 30 + displacement.Y),
                        new Point(40 + displacement.X, 30 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 20 + displacement.Y),
                        new Point(40 + displacement.X, 30 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 20 + displacement.Y),
                        new Point(10 + displacement.X, 20 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, 25 + displacement.Y),
                        new Point(10 + displacement.X, 25 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 25 + displacement.Y),
                        new Point(50 + displacement.X, 25 + displacement.Y));

                    graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                        40 + displacement.Y);

                    break;
                case Capacitor _:
                    graphics.DrawLine(pen,
                        new Point(20 + displacement.X, 15 + displacement.Y),
                        new Point(20 + displacement.X, 35 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(30 + displacement.X, 15 + displacement.Y),
                        new Point(30 + displacement.X, 35 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, 25 + displacement.Y),
                        new Point(20 + displacement.X, 25 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(30 + displacement.X, 25 + displacement.Y),
                        new Point(50 + displacement.X, 25 + displacement.Y));

                    graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                        40 + displacement.Y);

                    break;
                case Inductor _:
                    graphics.DrawArc(pen, 10 + displacement.X, 20 + displacement.Y,
                        10, 10, 180, 180);

                    graphics.DrawArc(pen, 20 + displacement.X, 20 + displacement.Y,
                        10, 10, 180, 180);

                    graphics.DrawArc(pen, 30 + displacement.X, 20 + displacement.Y,
                        10, 10, 180, 180);

                    graphics.DrawLine(pen,
                        new Point(0 + displacement.X, 25 + displacement.Y),
                        new Point(10 + displacement.X, 25 + displacement.Y));

                    graphics.DrawLine(pen,
                        new Point(40 + displacement.X, 25 + displacement.Y),
                        new Point(50 + displacement.X, 25 + displacement.Y));

                    graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                        40 + displacement.Y);

                    break;
            }
        }

        #endregion
    }
}
