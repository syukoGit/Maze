// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ScreenSaver
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int FreeConsole();

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            _ = Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

#if DEBUG
            _ = Program.AllocConsole();
            Console.Out.WriteLine("Debug Console");
#endif

            Application.Run(new ScreenSaver());

#if DEBUG
            _ = Program.FreeConsole();
#endif
        }
    }
}