namespace MazeDebugger;

partial class MazeDebugger
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
        _mazeViewer = new MazeViewer();
        _generateButton = new Button();
        _cursorsTreeView = new TreeView();
        groupBox1 = new GroupBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        _widthBox = new NumericUpDown();
        _heightBox = new NumericUpDown();
        label1 = new Label();
        label2 = new Label();
        groupBox1.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_widthBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)_heightBox).BeginInit();
        SuspendLayout();
        // 
        // _mazeViewer
        // 
        _mazeViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _mazeViewer.BackColor = Color.Black;
        _mazeViewer.Location = new Point(270, 12);
        _mazeViewer.Maze = null;
        _mazeViewer.Name = "_mazeViewer";
        _mazeViewer.Size = new Size(695, 608);
        _mazeViewer.TabIndex = 0;
        // 
        // _generateButton
        // 
        _generateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _generateButton.Location = new Point(1114, 626);
        _generateButton.Name = "_generateButton";
        _generateButton.Size = new Size(75, 23);
        _generateButton.TabIndex = 1;
        _generateButton.Text = "Generate";
        _generateButton.UseVisualStyleBackColor = true;
        _generateButton.Click += GenerateButton_Click;
        // 
        // _cursorsTreeView
        // 
        _cursorsTreeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        _cursorsTreeView.Location = new Point(971, 12);
        _cursorsTreeView.Name = "_cursorsTreeView";
        _cursorsTreeView.Size = new Size(218, 608);
        _cursorsTreeView.TabIndex = 2;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(tableLayoutPanel1);
        groupBox1.Location = new Point(12, 12);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(252, 608);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        groupBox1.Text = "Maze configuration";
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.66667F));
        tableLayoutPanel1.Controls.Add(_widthBox, 1, 1);
        tableLayoutPanel1.Controls.Add(_heightBox, 1, 2);
        tableLayoutPanel1.Controls.Add(label1, 0, 1);
        tableLayoutPanel1.Controls.Add(label2, 0, 2);
        tableLayoutPanel1.Dock = DockStyle.Fill;
        tableLayoutPanel1.Location = new Point(3, 19);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle());
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Size = new Size(246, 586);
        tableLayoutPanel1.TabIndex = 2;
        // 
        // _widthBox
        // 
        _widthBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _widthBox.Location = new Point(84, 23);
        _widthBox.Name = "_widthBox";
        _widthBox.Size = new Size(159, 23);
        _widthBox.TabIndex = 2;
        _widthBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // _heightBox
        // 
        _heightBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        _heightBox.Location = new Point(84, 52);
        _heightBox.Name = "_heightBox";
        _heightBox.Size = new Size(159, 23);
        _heightBox.TabIndex = 3;
        _heightBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Location = new Point(36, 27);
        label1.Name = "label1";
        label1.Size = new Size(42, 15);
        label1.TabIndex = 4;
        label1.Text = "Width:";
        label1.TextAlign = ContentAlignment.MiddleRight;
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Location = new Point(32, 56);
        label2.Name = "label2";
        label2.Size = new Size(46, 15);
        label2.TabIndex = 5;
        label2.Text = "Height:";
        label2.TextAlign = ContentAlignment.MiddleRight;
        // 
        // MazeDebugger
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1201, 661);
        Controls.Add(groupBox1);
        Controls.Add(_cursorsTreeView);
        Controls.Add(_generateButton);
        Controls.Add(_mazeViewer);
        Name = "MazeDebugger";
        Text = "Maze Debugger";
        groupBox1.ResumeLayout(false);
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_widthBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)_heightBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private MazeViewer _mazeViewer;
    private Button _generateButton;
    private TreeView _cursorsTreeView;
    private GroupBox groupBox1;
    private TableLayoutPanel tableLayoutPanel1;
    private NumericUpDown _widthBox;
    private NumericUpDown _heightBox;
    private Label label1;
    private Label label2;
}
