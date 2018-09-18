using System.Windows.Forms;

namespace MainForm
{
	public partial class ImpedanceForm : Form
	{
		#region Constructor

		public ImpedanceForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods

		private void ImpedanceForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Visible = false;
			e.Cancel = true;
		}

		#endregion
	}
}