using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircuitModel;

/// <summary>
/// Главная форма.
/// </summary>
namespace MainForm
{
    public partial class MainForm : Form
    {
        #region ~ Свойства ~

        /// <summary>
        /// Цепь.
        /// </summary>
        public Circuit Circuit { get; }

        #endregion

        #region ~ Публичные методы ~

        public MainForm()
        {
            InitializeComponent();

            SelectingCircuitComboBox.SelectedIndex = 0;
            NodeComboBox.SelectedIndex = 0;
            ConnectionComboBox.SelectedIndex = 0;
        }

        #endregion

        #region ~ Приватные методы ~

        private void SelectingCircuitComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (SelectingCircuitComboBox.SelectedItem)
            {
                case "":
                    {

                   break;
                    }   
            }
        }

        /// <summary>
        /// Событие, срабатывающее при удалении элемента из цепи.
        /// </summary>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if ()
            {

            }
            else
            {
                MessageBox.Show(
                    "Выберите один элемент из списка",
                    "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Событие, срабатывающее при добавлении элемента в цепь.
        /// </summary>
        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
