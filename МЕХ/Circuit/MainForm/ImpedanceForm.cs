using System.Windows.Forms;
using CircuitElements;

namespace MainForm
{
	public partial class ImpedanceForm : Form
	{
		#region Properties

		/// <summary>
		///     Обрабатываемая цепь
		/// </summary>
		public CircuitBase Circuit { get; set; }

		#endregion

		#region Constructor

		public ImpedanceForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods

		/// <summary>
		///     Обработчик события закрытия формы
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ImpedanceForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Visible = false;
			e.Cancel = true;
		}

		#endregion
	}
}