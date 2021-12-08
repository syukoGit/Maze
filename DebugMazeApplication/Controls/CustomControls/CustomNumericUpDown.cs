// -----------------------------------------------------------------------
// <copyright file="CustomNumericUpDown.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication.Controls.CustomControls
{
    using System;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    internal class CustomNumericUpDown : NumericUpDown
    {
        private string prefix = string.Empty;

        private string suffix = string.Empty;

        public string Prefix
        {
            get => this.prefix;

            set
            {
                this.prefix = value;

                this.UpdateEditText();
            }
        }

        public string Suffix
        {
            get => this.suffix;

            set
            {
                this.suffix = value;

                this.UpdateEditText();
            }
        }

        protected override void UpdateEditText() => this.Text = $@"{this.Prefix}{this.Value}{this.Suffix}";

        protected override void ValidateEditText()
        {
            this.ParseEditText();
            this.UpdateEditText();
        }

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