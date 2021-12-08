// -----------------------------------------------------------------------
//  <copyright project="DebugMazeApplication" file="TextBoxWriter.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication.Systems
{
    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    ///     Represents a writer that can write a sequential series of characters in a <see cref="RichTextBox" />.
    /// </summary>
    internal sealed class TextBoxWriter : TextWriter
    {
        /// <summary>
        ///     Represents the control in which the <see cref="TextBoxWriter" /> will write.
        /// </summary>
        private readonly RichTextBox control;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextBoxWriter" /> class.
        /// </summary>
        /// <param name="control">The control in which the <see cref="TextBoxWriter" /> will write.</param>
        public TextBoxWriter(RichTextBox control)
        {
            this.control = control;
        }

        /// <summary>
        ///     Gets or sets the character encoding used by the <see cref="TextBoxWriter" />.
        ///     The default value is UTF8.
        /// </summary>
        public override Encoding Encoding { get; } = Encoding.UTF8;

        /// <inheritdoc />
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

        /// <inheritdoc />
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