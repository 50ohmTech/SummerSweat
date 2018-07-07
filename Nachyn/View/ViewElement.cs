﻿using System;
using System.Collections.Generic;
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
        ///     Список элементов в ветви
        /// </summary>
        private readonly List<ElementBase> _elementBases;

        /// <summary>
        ///     Элемент цепи
        /// </summary>
        private ElementBase _item;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="element">Элемент цепи</param>
        /// <param name="elementBases">Список элементов в ветви</param>
        public ViewElement(ElementBase element, List<ElementBase> elementBases)
        {
            _elementBases = elementBases;
            InitializeComponent();
            Item = element;
            _labelValue.Text =
                "Номинал: " + element.Value.ToString(CultureInfo.CurrentCulture);

            _labelName.Text = element.Name.ToString(CultureInfo.CurrentCulture);
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

        private void Element_ValueChanged(object sender, ElementValueEventArgs arguments)
        {
            _labelValue.Text = "Номинал: " +
                               arguments.NewValue.ToString(CultureInfo.CurrentCulture);
            _labelName.Text = arguments.Name.ToString(CultureInfo.CurrentCulture);
        }

        private void ToolStripMenuAdd_Click(object sender, EventArgs e)
        {
            new ElementManagerForm(this).ShowDialog();
        }

        private void ToolStripMenuDelete_Click(object sender, EventArgs e)
        {
            _elementBases.Remove(Item);
            Dispose();
        }
    }
}