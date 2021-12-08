// -----------------------------------------------------------------------
// <copyright file="TextBoxWriter.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication.Systems
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    internal class TextBoxWriter : TextWriter
    {
        private readonly RichTextBox control;

        public TextBoxWriter(RichTextBox control)
        {
            this.control = control;
        }

        public override Encoding Encoding { get; } = Encoding.UTF8;

        public override void Write(char value)
        {
            if (this.control.InvokeRequired)
            {
                _ = this.control.Invoke(new Action(() =>
                {
                    this.control.Text += value;
                    this.control.SelectionStart = this.control.Text.Length;
                    this.control.ScrollToCaret();
                }));
            }
            else
            {
                this.control.Text += value;
                this.control.SelectionStart = this.control.Text.Length;
                this.control.ScrollToCaret();
            }
        }

        public override void Write(string value)
        {
            if (this.control.InvokeRequired)
            {
                _ = this.control.Invoke(new Action(() =>
                {
                    this.control.Text += value;
                    this.control.SelectionStart = this.control.Text.Length;
                    this.control.ScrollToCaret();
                }));
            }
            else
            {
                this.control.Text += value;
                this.control.SelectionStart = this.control.Text.Length;
                this.control.ScrollToCaret();
            }
        }
    }
}