using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Model.Elements;
using Model.Events;

namespace View
{
    public sealed partial class Element : UserControl
    {
        private bool _isMoves;

        private Point _oldLocation;

        private readonly ObservableCollection<IElement> _elements;

        public Element(Bitmap image, IElement element, ObservableCollection<IElement> elements)
        {
            InitializeComponent();
            BackgroundImage = image;

            Item = element;
            _elements = elements;
            _elements.Add(Item);

            _labelValue.Text = element.Value.ToString(CultureInfo.CurrentCulture);
            element.ValueChanged += ElementValueChanged;
        }

        public IElement Item { get; }

        private void ElementValueChanged(object sender, ElementValueArgs arguments)
        {
            _labelValue.Text = arguments.NewValue.ToString(CultureInfo.CurrentCulture);
        }

        private void ElementMouseDown(object sender, MouseEventArgs e)
        {
            _isMoves = true;
        }

        private void ElementMouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoves)
            {
                var newLocation = new Point(e.Location.X - _oldLocation.X, e.Location.Y - _oldLocation.Y);
                Location = new Point(Location.X + newLocation.X, Location.Y + newLocation.Y);
            }
        }

        private void ElementMouseUp(object sender, MouseEventArgs e)
        {
            _isMoves = false;
            _oldLocation = e.Location;
        }

        private void ToolStripMenuAddClick(object sender, EventArgs e)
        {
            new AddForm(Item).ShowDialog();
        }

        private void ToolStripMenuDeleteClick(object sender, EventArgs e)
        {
            _elements.Remove(Item);
            Dispose();
        }
    }
}