namespace DebugMazeApplication
{
    using DebugMazeApplication.Controls.CustomControls;

    partial class DebugMazeApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Cursors");
            this.mazeDisplay = new DebugMazeApplication.Controls.MazeDisplay();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.consoleOutput = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMazeConfig = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.mazeHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.mazeWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nbMaxRunningCursor = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.probabilityCursorToSplit = new DebugMazeApplication.Controls.CustomControls.CustomNumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.waitingTimeCursorMs = new DebugMazeApplication.Controls.CustomControls.CustomNumericUpDown();
            this.groupBoxConfiguration = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxDifferentColorForEachCursor = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxMazeInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.labelNbTotalCursor = new System.Windows.Forms.Label();
            this.labelNbEndedCursor = new System.Windows.Forms.Label();
            this.labelNbWaitingCursor = new System.Windows.Forms.Label();
            this.labelNbRuningCursor = new System.Windows.Forms.Label();
            this.progressBarMaze = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewCursor = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxMazeConfig.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbMaxRunningCursor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityCursorToSplit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingTimeCursorMs)).BeginInit();
            this.groupBoxConfiguration.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxMazeInfo.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // mazeDisplay
            // 
            this.mazeDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mazeDisplay.BackColor = System.Drawing.Color.Black;
            this.mazeDisplay.DifferentColorForEachCursor = false;
            this.mazeDisplay.Location = new System.Drawing.Point(373, 54);
            this.mazeDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.mazeDisplay.Maze = null;
            this.mazeDisplay.Name = "mazeDisplay";
            this.mazeDisplay.Size = new System.Drawing.Size(432, 347);
            this.mazeDisplay.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(3, 458);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(324, 50);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // consoleOutput
            // 
            this.consoleOutput.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.consoleOutput, 2);
            this.consoleOutput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.consoleOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleOutput.Location = new System.Drawing.Point(333, 458);
            this.consoleOutput.Name = "consoleOutput";
            this.consoleOutput.ReadOnly = true;
            this.consoleOutput.ShortcutsEnabled = false;
            this.consoleOutput.Size = new System.Drawing.Size(843, 146);
            this.consoleOutput.TabIndex = 2;
            this.consoleOutput.TabStop = false;
            this.consoleOutput.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.Controls.Add(this.btnGenerate, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.consoleOutput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mazeDisplay, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1179, 607);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBoxMazeConfig, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxConfiguration, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(324, 449);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // groupBoxMazeConfig
            // 
            this.groupBoxMazeConfig.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxMazeConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMazeConfig.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMazeConfig.Name = "groupBoxMazeConfig";
            this.groupBoxMazeConfig.Size = new System.Drawing.Size(318, 218);
            this.groupBoxMazeConfig.TabIndex = 0;
            this.groupBoxMazeConfig.TabStop = false;
            this.groupBoxMazeConfig.Text = "Maze configuration";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.mazeHeight, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.mazeWidth, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.nbMaxRunningCursor, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.probabilityCursorToSplit, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.waitingTimeCursorMs, 1, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(312, 196);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // mazeHeight
            // 
            this.mazeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazeHeight.Location = new System.Drawing.Point(159, 3);
            this.mazeHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mazeHeight.Name = "mazeHeight";
            this.mazeHeight.Size = new System.Drawing.Size(150, 23);
            this.mazeHeight.TabIndex = 0;
            this.mazeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mazeHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Height :";
            // 
            // mazeWidth
            // 
            this.mazeWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazeWidth.Location = new System.Drawing.Point(159, 32);
            this.mazeWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.mazeWidth.Name = "mazeWidth";
            this.mazeWidth.Size = new System.Drawing.Size(150, 23);
            this.mazeWidth.TabIndex = 2;
            this.mazeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mazeWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Width :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "NbMaxRunningCursor :";
            // 
            // nbMaxRunningCursor
            // 
            this.nbMaxRunningCursor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nbMaxRunningCursor.Location = new System.Drawing.Point(159, 61);
            this.nbMaxRunningCursor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbMaxRunningCursor.Name = "nbMaxRunningCursor";
            this.nbMaxRunningCursor.Size = new System.Drawing.Size(150, 23);
            this.nbMaxRunningCursor.TabIndex = 5;
            this.nbMaxRunningCursor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nbMaxRunningCursor.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "ProbabilityCursorToSplit :";
            // 
            // probabilityCursorToSplit
            // 
            this.probabilityCursorToSplit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.probabilityCursorToSplit.Location = new System.Drawing.Point(159, 90);
            this.probabilityCursorToSplit.Name = "probabilityCursorToSplit";
            this.probabilityCursorToSplit.Prefix = "";
            this.probabilityCursorToSplit.Size = new System.Drawing.Size(150, 23);
            this.probabilityCursorToSplit.Suffix = "%";
            this.probabilityCursorToSplit.TabIndex = 7;
            this.probabilityCursorToSplit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.probabilityCursorToSplit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "WaitingTimeCursorMs :";
            // 
            // waitingTimeCursorMs
            // 
            this.waitingTimeCursorMs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.waitingTimeCursorMs.Location = new System.Drawing.Point(159, 119);
            this.waitingTimeCursorMs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.waitingTimeCursorMs.Name = "waitingTimeCursorMs";
            this.waitingTimeCursorMs.Prefix = "";
            this.waitingTimeCursorMs.Size = new System.Drawing.Size(150, 23);
            this.waitingTimeCursorMs.Suffix = " ms";
            this.waitingTimeCursorMs.TabIndex = 9;
            this.waitingTimeCursorMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.waitingTimeCursorMs.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // groupBoxConfiguration
            // 
            this.groupBoxConfiguration.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxConfiguration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxConfiguration.Location = new System.Drawing.Point(3, 227);
            this.groupBoxConfiguration.Name = "groupBoxConfiguration";
            this.groupBoxConfiguration.Size = new System.Drawing.Size(318, 219);
            this.groupBoxConfiguration.TabIndex = 3;
            this.groupBoxConfiguration.TabStop = false;
            this.groupBoxConfiguration.Text = "Debug Configuration";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxDifferentColorForEachCursor, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(312, 197);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkBoxDifferentColorForEachCursor
            // 
            this.checkBoxDifferentColorForEachCursor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDifferentColorForEachCursor.AutoSize = true;
            this.checkBoxDifferentColorForEachCursor.Location = new System.Drawing.Point(190, 3);
            this.checkBoxDifferentColorForEachCursor.Name = "checkBoxDifferentColorForEachCursor";
            this.checkBoxDifferentColorForEachCursor.Size = new System.Drawing.Size(119, 14);
            this.checkBoxDifferentColorForEachCursor.TabIndex = 0;
            this.checkBoxDifferentColorForEachCursor.UseVisualStyleBackColor = true;
            this.checkBoxDifferentColorForEachCursor.CheckedChanged += new System.EventHandler(this.CheckBoxDifferentColorForEachCursor_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Different color for each cursor :";
            // 
            // groupBoxMazeInfo
            // 
            this.groupBoxMazeInfo.AutoSize = true;
            this.groupBoxMazeInfo.Controls.Add(this.tableLayoutPanel5);
            this.groupBoxMazeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMazeInfo.Location = new System.Drawing.Point(3, 3);
            this.groupBoxMazeInfo.Name = "groupBoxMazeInfo";
            this.groupBoxMazeInfo.Size = new System.Drawing.Size(319, 231);
            this.groupBoxMazeInfo.TabIndex = 5;
            this.groupBoxMazeInfo.TabStop = false;
            this.groupBoxMazeInfo.Text = "Maze Information";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.labelNbTotalCursor, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.progressBarMaze, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.labelNbEndedCursor, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.labelNbWaitingCursor, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelNbRuningCursor, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(313, 209);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // labelNbTotalCursor
            // 
            this.labelNbTotalCursor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNbTotalCursor.BackColor = System.Drawing.Color.LightGray;
            this.labelNbTotalCursor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNbTotalCursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNbTotalCursor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelNbTotalCursor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelNbTotalCursor.Location = new System.Drawing.Point(3, 140);
            this.labelNbTotalCursor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelNbTotalCursor.Name = "labelNbTotalCursor";
            this.labelNbTotalCursor.Size = new System.Drawing.Size(307, 35);
            this.labelNbTotalCursor.TabIndex = 3;
            this.labelNbTotalCursor.Text = "Number total of cursors : 0";
            this.labelNbTotalCursor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNbEndedCursor
            // 
            this.labelNbEndedCursor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNbEndedCursor.BackColor = System.Drawing.Color.LightGray;
            this.labelNbEndedCursor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNbEndedCursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNbEndedCursor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNbEndedCursor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelNbEndedCursor.Location = new System.Drawing.Point(3, 95);
            this.labelNbEndedCursor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelNbEndedCursor.Name = "labelNbEndedCursor";
            this.labelNbEndedCursor.Size = new System.Drawing.Size(307, 35);
            this.labelNbEndedCursor.TabIndex = 2;
            this.labelNbEndedCursor.Text = "Number of ended cursors : 0";
            this.labelNbEndedCursor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNbWaitingCursor
            // 
            this.labelNbWaitingCursor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNbWaitingCursor.BackColor = System.Drawing.Color.LightGray;
            this.labelNbWaitingCursor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNbWaitingCursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNbWaitingCursor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNbWaitingCursor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelNbWaitingCursor.Location = new System.Drawing.Point(3, 50);
            this.labelNbWaitingCursor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelNbWaitingCursor.Name = "labelNbWaitingCursor";
            this.labelNbWaitingCursor.Size = new System.Drawing.Size(307, 35);
            this.labelNbWaitingCursor.TabIndex = 1;
            this.labelNbWaitingCursor.Text = "Number of waiting cursors : 0";
            this.labelNbWaitingCursor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNbRuningCursor
            // 
            this.labelNbRuningCursor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNbRuningCursor.BackColor = System.Drawing.Color.LightGray;
            this.labelNbRuningCursor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelNbRuningCursor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNbRuningCursor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNbRuningCursor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelNbRuningCursor.Location = new System.Drawing.Point(3, 5);
            this.labelNbRuningCursor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelNbRuningCursor.Name = "labelNbRuningCursor";
            this.labelNbRuningCursor.Size = new System.Drawing.Size(307, 35);
            this.labelNbRuningCursor.TabIndex = 0;
            this.labelNbRuningCursor.Text = "Number of running cursors : 0";
            this.labelNbRuningCursor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarMaze
            // 
            this.progressBarMaze.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarMaze.Location = new System.Drawing.Point(3, 183);
            this.progressBarMaze.Name = "progressBarMaze";
            this.progressBarMaze.Size = new System.Drawing.Size(307, 23);
            this.progressBarMaze.TabIndex = 4;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.groupBoxMazeInfo, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.treeViewCursor, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(851, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(325, 449);
            this.tableLayoutPanel6.TabIndex = 6;
            // 
            // treeViewCursor
            // 
            this.treeViewCursor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCursor.Location = new System.Drawing.Point(3, 240);
            this.treeViewCursor.Name = "treeViewCursor";
            treeNode1.Name = "root";
            treeNode1.Text = "Cursors";
            this.treeViewCursor.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeViewCursor.Size = new System.Drawing.Size(319, 206);
            this.treeViewCursor.TabIndex = 6;
            // 
            // DebugMazeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 607);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DebugMazeApp";
            this.Text = "DebugMazeApp";
            this.Load += new System.EventHandler(this.DebugMazeApp_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBoxMazeConfig.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mazeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mazeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbMaxRunningCursor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityCursorToSplit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waitingTimeCursorMs)).EndInit();
            this.groupBoxConfiguration.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxMazeInfo.ResumeLayout(false);
            this.groupBoxMazeInfo.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.MazeDisplay mazeDisplay;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox consoleOutput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBoxConfiguration;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxMazeConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.NumericUpDown mazeHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown mazeWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbMaxRunningCursor;
        private System.Windows.Forms.Label label4;
        private CustomNumericUpDown probabilityCursorToSplit;
        private System.Windows.Forms.Label label5;
        private CustomNumericUpDown waitingTimeCursorMs;
        private System.Windows.Forms.GroupBox groupBoxMazeInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label labelNbRuningCursor;
        private System.Windows.Forms.Label labelNbWaitingCursor;
        private System.Windows.Forms.Label labelNbEndedCursor;
        private System.Windows.Forms.Label labelNbTotalCursor;
        private System.Windows.Forms.ProgressBar progressBarMaze;
        private System.Windows.Forms.CheckBox checkBoxDifferentColorForEachCursor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TreeView treeViewCursor;
    }
}

