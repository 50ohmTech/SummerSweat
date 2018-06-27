using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Model.Elements;
using Model.Events;

namespace View
{
    public sealed partial class ViewElement : UserControl
    {
        //TODO: УДАЛИТЬ!
        private bool _isMoves;

        //TODO: УДАЛИТЬ!
        private Point _oldLocation;

        private readonly ObservableCollection<ElementBase> _elements;

        private ElementBase _item;

        public ViewElement(ElementBase element, ObservableCollection<ElementBase> elements)
        {
            InitializeComponent();

            Item = element;
            _elements = elements;
            _elements.Add(Item);

            _labelValue.Text = element.Value.ToString(CultureInfo.CurrentCulture);
        }

        public ElementBase Item
        {
            get => _item;
            private set
            {
                switch (value)
                {
                    case Resistor _:
                        BackgroundImage = Properties.Resources.Resistor;
                        break;

                    case Inductor _:
                        BackgroundImage = Properties.Resources.Inductor;
                        break;
                    case Capacitor _:
                        BackgroundImage = Properties.Resources.Capacitor;
                        break;

                    case null:
                        throw new ArgumentNullException();

                    default:
                        throw new InvalidOperationException();
                }               
                _item = value;
                _item.ValueChanged += ElementValueChanged;
            }
        }

        private void ElementValueChanged(object sender, ElementValueArgs arguments)
        {
            _labelValue.Text = arguments.NewValue.ToString(CultureInfo.CurrentCulture);
        }

        //TODO: УДАЛИТЬ!
        private void ElementMouseDown(object sender, MouseEventArgs e)
        {
            _isMoves = true;
        }

        //TODO: УДАЛИТЬ!
        private void ElementMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoves)
            {
                var newLocation = new Point(e.Location.X - _oldLocation.X, e.Location.Y - _oldLocation.Y);
                Location = new Point(Location.X + newLocation.X, Location.Y + newLocation.Y);
            }
        }

        //TODO: УДАЛИТЬ!
        private void ElementMouseUp(object sender, MouseEventArgs e)
        {
            _isMoves = false;
            _oldLocation = e.Location;
        }

        private void ToolStripMenuAddClick(object sender, EventArgs e)
        {
            new AddForm(this).ShowDialog();
        }

        private void ToolStripMenuDeleteClick(object sender, EventArgs e)
        {
            _elements.Remove(Item);
            Dispose();
        }
    }
}