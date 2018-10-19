using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model.Circuit;

namespace View
{
    /// <summary>
    ///     Форма расчетов импедансов.
    /// </summary>
    public partial class ImpedanceForm : Form
    {
        #region Readonly fields

        /// <summary>
        ///     Цепь.
        /// </summary>
        private readonly Circuit _circuit;

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор.
        /// </summary>
        /// <param name="circuit">Цепь.</param>
        public ImpedanceForm(Circuit circuit)
        {
            _circuit = circuit;
            InitializeComponent();
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Расчет импедансов.
        /// </summary>
        /// <param name="frequencies"></param>
        private void CalculateImpedances()
        {
            
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateImpedances();
        }

        #endregion
    }
}