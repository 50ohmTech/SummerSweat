using System;
using System.Windows.Forms;
using Model.Elements;

namespace View
{
    internal static class Program
    {
        /// <summary>
        ///     Главная форма
        /// </summary>
        private static MainForm _mainForm;

        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _mainForm = new MainForm();
            Application.Run(_mainForm);

        }
    }
}