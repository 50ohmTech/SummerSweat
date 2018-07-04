﻿using Model;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

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
        public Circuit Circuit { get; set; }

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

            _resistorCounter = 0;
            _capacitorCounter = 0;
            _inductorCounter = 0;
        }

        #endregion

        #region - - Приватные методы - -

        private void CircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (circuitComboBox.SelectedIndex)
            {
                case 0:
                    _resistorCounter = 0;
                    _capacitorCounter = 0;
                    _inductorCounter = 0;

                    Circuit.Elements.Clear();

                    break;
                case 1:
                {
                    _resistorCounter = 5;
                    _capacitorCounter = 0;
                    _inductorCounter = 0;

                    Circuit.Elements.Clear();

                    Circuit.Elements.Add(new Resistor("R1", 10));
                    Circuit.Elements.Add(new Resistor("R2", 10), "R1", false);
                    Circuit.Elements.Add(new Resistor("R3", 10), "R1", true);
                    Circuit.Elements.Add(new Resistor("R4", 5), "R1", true);
                    Circuit.Elements.Add(new Resistor("R5", 5), "R1", false);
                    Circuit.Elements.Add(new Resistor("R6", 20), "R5", true);
                    Circuit.Elements.Add(new Resistor("R7", 5), "R4", false);
                    Circuit.Elements.Add(new Resistor("R8", 10), "R4", false);
                    Circuit.Elements.Add(new Resistor("R9", 10), "R7", false);
                    Circuit.Elements.Add(new Resistor("R10", 10), "R7", true);
                    Circuit.Elements.Add(new Resistor("R11", 10), "R7", true);
                    Circuit.Elements.Add(new Resistor("R12", 10), "R9", true);
                    Circuit.Elements.Add(new Resistor("R13", 10), "R9", true);
                    Circuit.Elements.Add(new Resistor("R14", 10), "R9", true);
                    Circuit.Elements.Add(new Resistor("R15", 10), "R12", false);
                    Circuit.Elements.Add(new Resistor("R16", 10), "R15", true);

                    break;
                }
                case 2:
                {
                    _resistorCounter = 1;
                    _capacitorCounter = 1;
                    _inductorCounter = 2;

                    Circuit.Elements.Clear();

                    var elements = new List<Element>
                    {
                        new Capacitor("C1", 66.666),
                        new Inductor("I1", 0.02),
                        new Resistor("R1", 20.56),
                        new Inductor("I2", 0.7)
                    };

                    Circuit.Elements.Add(elements[0]);
                    Circuit.Elements.Add(elements[1], "C1", false);
                    Circuit.Elements.Add(elements[2], "I1", true);
                    Circuit.Elements.Add(elements[3], "C1", false);

                    break;
                }
                case 3:
                {
                    _resistorCounter = 2;
                    _capacitorCounter = 3;
                    _inductorCounter = 1;

                    Circuit.Elements.Clear();

                    var elements = new List<Element>
                    {
                        new Resistor("R1", 95),
                        new Capacitor("C1", 38),
                        new Inductor("I1", 0.5),
                        new Capacitor("C2", 32.8),
                        new Resistor("R2", 20),
                        new Capacitor("C3", 66.666)
                    };

                    Circuit.Elements.Add(elements[0]);
                    Circuit.Elements.Add(elements[1], "R1", false);
                    Circuit.Elements.Add(elements[2], "C1", true);
                    Circuit.Elements.Add(elements[3], "R1", true);
                    Circuit.Elements.Add(elements[4], "I1", false);
                    Circuit.Elements.Add(elements[5], "C2", false);
                    Circuit.Elements.Add(new Resistor("R3", 222), "C2", false);

                    break;
                }
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
            NumberBox.ChangeSeparator(valueBox);

            var value = double.Parse(valueBox.Text);

            if (value < double.Parse(Properties.Resources.minElementValue) ||
                value > double.Parse(Properties.Resources.maxElementValue))
            {
                MessageBox.Show(
                    "Номинал элемента должен быть\n больше " +
                    Properties.Resources.minElementValue + " и не превышать " +
                    Properties.Resources.maxElementValue,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (resistorRadioButton.Checked)
            {
                Circuit.Elements.Add(new Resistor(
                    "R" + (++_resistorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else if (capacitorRadioButton.Checked)
            {
                Circuit.Elements.Add(new Capacitor(
                    "C" + (++_capacitorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else if (inductorRadioButton.Checked)
            {
                Circuit.Elements.Add(new Inductor(
                    "I" + (++_inductorCounter).ToString(),
                    double.Parse(valueBox.Text)));
            }
            else
            {
                MessageBox.Show(
                    "Выберите тип элемента", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in elementGridView.SelectedRows)
            {
                elementGridView.Rows.Remove(row);
            }
        }

        private void ElementGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            var text = ((DataGridViewTextBoxEditingControl)sender).Text;
            var index = ((DataGridViewTextBoxEditingControl)sender).EditingControlRowIndex;

            if (!double.TryParse(text, out var value))
            {
                //((DataGridViewTextBoxEditingControl) sender).Text =
                //    elementGridView.Rows[index].Cells[1].Value.ToString();

                return;
            }

            if (value < double.Parse(Properties.Resources.minElementValue) ||
                value > double.Parse(Properties.Resources.maxElementValue))
            {
                //((DataGridViewTextBoxEditingControl) sender).Text =
                //    ((Element) elementBindingSource[index]).Value.ToString();
            }
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
            if (e.Type == ChangedEventArgs.ChangeType.Add)
            {
                elementGridView.Rows.Add(e.Element.Name, e.Element.Value);
            }
            else if (e.Type == ChangedEventArgs.ChangeType.Delete)
            {
            }
            else if (e.Type == ChangedEventArgs.ChangeType.Clear)
            {
                elementGridView.Rows.Clear();
            }

            circuitPictureBox.Image = null;
            var bitmapBackground = new Bitmap(1000, 1000);
            var graphics = Graphics.FromImage(bitmapBackground);
            var pen = new Pen(Color.Black, 1);

            var displacement = new Point(50, 40);
            DrawCircuit(graphics, pen, Circuit.Elements.Root, displacement);

            circuitPictureBox.Image = bitmapBackground;
        }

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
                        new Point(25 + displacement.X, steps.Sum() * 40 + displacement.Y));

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

                graphics.DrawLine(pen, new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(50 + maxCount * 50 + displacement.X, 25 + displacement.Y));


                graphics.DrawLine(pen, new Point(25 + displacement.X, 25 + displacement.Y),
                    new Point(25 + displacement.X, 25 + (steps.Sum() - steps[steps.Count - 1]) * 40 + displacement.Y));

                graphics.DrawLine(pen, new Point(25 + maxCount * 50 + displacement.X, 25 + displacement.Y),
                    new Point(25 + maxCount * 50 + displacement.X, 25 + (steps.Sum() - steps[steps.Count - 1]) * 40 + displacement.Y));

                return new Point(maxCount + 1, steps.Sum());
            }
            else
            {
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
        }

        private void DrawElement(Graphics graphics, Pen pen, Element element,
            Point displacement)
        {
            var brush = new SolidBrush(Color.Black);
            if (element is Resistor)
            {
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

                graphics.DrawLine(pen, new Point(0 + displacement.X, 25 + displacement.Y),
                    new Point(10 + displacement.X, 25 + displacement.Y));

                graphics.DrawLine(pen,
                    new Point(40 + displacement.X, 25 + displacement.Y),
                    new Point(50 + displacement.X, 25 + displacement.Y));

                graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                    40 + displacement.Y);
            }
            else if (element is Capacitor)
            {
                graphics.DrawLine(pen,
                    new Point(20 + displacement.X, 15 + displacement.Y),
                    new Point(20 + displacement.X, 35 + displacement.Y));

                graphics.DrawLine(pen,
                    new Point(30 + displacement.X, 15 + displacement.Y),
                    new Point(30 + displacement.X, 35 + displacement.Y));

                graphics.DrawLine(pen, new Point(0 + displacement.X, 25 + displacement.Y),
                    new Point(20 + displacement.X, 25 + displacement.Y));

                graphics.DrawLine(pen,
                    new Point(30 + displacement.X, 25 + displacement.Y),
                    new Point(50 + displacement.X, 25 + displacement.Y));

                graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                    40 + displacement.Y);
            }
            else if (element is Inductor)
            {
                graphics.DrawArc(pen, 10 + displacement.X, 20 + displacement.Y, 10, 10,
                    180, 180);

                graphics.DrawArc(pen, 20 + displacement.X, 20 + displacement.Y, 10, 10,
                    180, 180);

                graphics.DrawArc(pen, 30 + displacement.X, 20 + displacement.Y, 10, 10,
                    180, 180);

                graphics.DrawLine(pen, new Point(0 + displacement.X, 25 + displacement.Y),
                    new Point(10 + displacement.X, 25 + displacement.Y));

                graphics.DrawLine(pen,
                    new Point(40 + displacement.X, 25 + displacement.Y),
                    new Point(50 + displacement.X, 25 + displacement.Y));

                graphics.DrawString(element.Name, Font, brush, 15 + displacement.X,
                    40 + displacement.Y);
            }

        }

        #endregion
    }
}
