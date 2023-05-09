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
        SuspendLayout();
        // 
        // _mazeViewer
        // 
        _mazeViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        _mazeViewer.BackColor = Color.Black;
        _mazeViewer.Location = new Point(0, 0);
        _mazeViewer.Maze = null;
        _mazeViewer.Name = "_mazeViewer";
        _mazeViewer.Size = new Size(800, 409);
        _mazeViewer.TabIndex = 0;
        // 
        // _generateButton
        // 
        _generateButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        _generateButton.Location = new Point(713, 415);
        _generateButton.Name = "_generateButton";
        _generateButton.Size = new Size(75, 23);
        _generateButton.TabIndex = 1;
        _generateButton.Text = "Generate";
        _generateButton.UseVisualStyleBackColor = true;
        _generateButton.Click += GenerateButton_Click;
        // 
        // MazeDebugger
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(_generateButton);
        Controls.Add(_mazeViewer);
        Name = "MazeDebugger";
        Text = "Maze Debugger";
        ResumeLayout(false);
    }

    #endregion

    private MazeViewer _mazeViewer;
    private Button _generateButton;
}
