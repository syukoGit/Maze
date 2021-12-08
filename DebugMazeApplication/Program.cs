// -----------------------------------------------------------------------
//  <copyright project="DebugMazeApplication" file="Program.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    ///     The class that contains the main entry point.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            _ = Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DebugMazeApp());
        }
    }
}