using System.Windows.Forms;
using CircuitLibrary;

namespace MainForm
{
    public partial class ImpedanceForm : Form
    {
        #region Properties

        public Circuit Circuit { get; set; }

        #endregion

        #region Constructor

        public ImpedanceForm()
        {
            InitializeComponent();
            dataGridView.RowHeadersVisible = false;
        }

        #endregion
    }
}