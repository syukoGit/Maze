// -----------------------------------------------------------------------
//  <copyright project="DebugMazeApplication" file="CustomNumericUpDown.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication.Controls.CustomControls
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    /// <summary>
    ///     Represents a <see cref="NumericUpDown" /> that can have a suffix and/or prefix.
    /// </summary>
    internal sealed class CustomNumericUpDown : NumericUpDown
    {
        /// <summary>
        ///     The prefix of the <see cref="CustomNumericUpDown" />.
        /// </summary>
        private string prefix = string.Empty;

        /// <summary>
        ///     The suffix of the <see cref="CustomNumericUpDown" />.
        /// </summary>
        private string suffix = string.Empty;

        /// <summary>
        ///     Gets or sets the prefix to be display.
        /// </summary>
        public string Prefix
        {
            get => this.prefix;

            set
            {
                this.prefix = value;

                this.UpdateEditText();
            }
        }

        /// <summary>
        ///     Gets or sets the suffix to be display.
        /// </summary>
        public string Suffix
        {
            get => this.suffix;

            set
            {
                this.suffix = value;

                this.UpdateEditText();
            }
        }

        /// <inheritdoc />
        protected override void UpdateEditText() => this.Text = $@"{this.Prefix}{this.Value}{this.Suffix}";

        /// <inheritdoc />
        protected override void ValidateEditText()
        {
            this.ParseEditText();
            this.UpdateEditText();
        }

        /// <summary>
        ///     Check if the value is between the minimum and maximum allowed.
        /// </summary>
        /// <param name="value">The value to be check.</param>
        /// <returns>
        ///     If the value is inferior to minimum allowed, then return the minimum.
        ///     If the value is superior to maximum allowed, then return the maximum.
        ///     Else return the value.
        /// </returns>
        private decimal Constrain(decimal value)
        {
            if (value < this.Minimum)
            {
                value = this.Minimum;
            }

            if (value > this.Maximum)
            {
                value = this.Maximum;
            }

            return value;
        }

        /// <summary>
        ///     Parses the text of the text of the control for defines the value.
        /// </summary>
        private new void ParseEditText()
        {
            try
            {
                var regex = new Regex($@"[^(?!({this.Prefix} |{this.Suffix} ))]+");
                Match match = regex.Match(this.Text);

                if (!match.Success)
                {
                    return;
                }

                string text = match.Value;

                if (string.IsNullOrEmpty(text) || (text.Length == 1 && text == "-"))
                {
                    return;
                }

                this.Value = this.Constrain(this.Hexadecimal
                                                ? Convert.ToDecimal(Convert.ToInt32(this.Text, 16))
                                                : decimal.Parse(text, CultureInfo.CurrentCulture));
            }
            finally
            {
                this.UserEdit = false;
            }
        }
    }
}