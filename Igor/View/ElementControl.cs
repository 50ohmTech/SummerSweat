using System.Collections.ObjectModel;
using System.Windows.Forms;
using Gpt.Model;
using Gpt.View.Properties;

namespace Gpt.View
{
    public partial class ElementControl : UserControl
    {
        private readonly ObservableCollection<ElementBase> _elements;

        private string _endCircuit;

        private ElementBase _item;


        public ElementControl(ElementBase elementBase,
            ObservableCollection<ElementBase> elements)
        {
            InitializeComponent();
            //BackgroundImage = image;

            Item = elementBase;
            _elements = elements;
            _elements.Add(Item);

            label1.Text = elementBase.Value.ToString(); //CultureInfo.CurrentCulture
            //elementBase.ValueChanged += ElementValueChanged;
        }

        public ElementControl(string nameEndingCircuit)
        {
            InitializeComponent();
            EndCircuit = nameEndingCircuit;
            label1.Visible = false;
        }

        public string EndCircuit
        {
            get => _endCircuit;
            private set
            {
                switch (value)
                {
                    case "Ending":
                    {
                        BackgroundImage = Resources.Ending_Part;
                        break;
                    }
                    case "Starting":
                    {
                        BackgroundImage = Resources.Starting_Part;
                        break;
                    }
                }
            }
        }

        public ElementBase Item
        {
            get => _item;
            private set
            {
                switch (value)
                {
                    case Resistor test:
                        BackgroundImage = Resources.resistor;
                        break;
                    case Capacitor test:
                        BackgroundImage = Resources.condensator;
                        break;
                    case Inductor test:
                        BackgroundImage = Resources.inductor;
                        break;
                }

                _item = value;
            }
        }
    }
}