using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gpt.Model;

namespace Gpt.View
{
    public partial class ElementControl : UserControl
    {

        //private readonly ObservableCollection<ElementBase> _elements;
        private readonly List<ElementBase> _elements;

        public ElementControl( ElementBase elementBase)
        {
            InitializeComponent();
            //BackgroundImage = image;

            Item = elementBase;
            //_elements = elements;
            //_elements.Add(Item);

            label1.Text = elementBase.Value.ToString(); //CultureInfo.CurrentCulture
            //elementBase.ValueChanged += ElementValueChanged;
        }

        public ElementBase Item { get; }
    }
}
