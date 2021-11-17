// -----------------------------------------------------------------------
// <copyright file="DebugConsole.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
#if DEBUG
namespace MazeGenerator.DebugMode
{
    using System;
    using System.Runtime.InteropServices;

    internal class DebugConsole : IDisposable
    {
        public DebugConsole()
        {
            _ = DebugConsole.AllocConsole();
            Console.Out.WriteLine("==== Debug Console ====");
        }

        public void Dispose() => FreeConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int FreeConsole();
    }
}
#endif