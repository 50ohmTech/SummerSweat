﻿using System;
using System.Globalization;
using System.Windows.Forms;
using Model.Elements;
using Model.Events;
using View.Properties;

namespace View
{
    /// <summary>
    ///     Визуальный элемент
    /// </summary>
    public sealed partial class ViewElement : UserControl
    {
        /// <summary>
        ///     Элемент цепи
        /// </summary>
        private ElementBase _item;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Элемент цепи</param>
        public ViewElement(ElementBase element)
        {
            InitializeComponent();

            Item = element;

            _labelValue.Text = element.Value.ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        ///     Элемент цепи
        /// </summary>
        public ElementBase Item
        {
            get => _item;
            private set
            {
                switch (value)
                {
                    case Resistor _:
                        BackgroundImage = Resources.Resistor;
                        break;

                    case Inductor _:
                        BackgroundImage = Resources.Inductor;
                        break;
                    case Capacitor _:
                        BackgroundImage = Resources.Capacitor;
                        break;

                    case null:
                        throw new ArgumentNullException();

                    default:
                        throw new InvalidOperationException();
                }

                _item = value;
                _item.ValueChanged += Element_ValueChanged;
            }
        }

        private void Element_ValueChanged(object sender, ElementValueArgs arguments)
        {
            _labelValue.Text = arguments.NewValue.ToString(CultureInfo.CurrentCulture);
        }

        private void ToolStripMenuAdd_Click(object sender, EventArgs e)
        {
            new ControlPanel(this).ShowDialog();
        }

        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            Item.Delete();
            Dispose();
        }
    }
}