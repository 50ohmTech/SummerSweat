﻿using System;
using System.Windows.Forms;

namespace MainForm
{
    /// <summary>
    /// Точка входа
    /// </summary>
    internal static class Program
    {
        #region Private methods

        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CircuitForm());
        }

        #endregion
    }
}