// -----------------------------------------------------------------------
// <copyright file="DebugMazeApp.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication
{
    using DebugMazeApplication.Systems;
    using MazeGenerator.Generators;
    using MazeGenerator.Types;
    using MazeGenerator.Types.Mazes;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    internal partial class DebugMazeApp : Form
    {
        private readonly CancellationTokenSource cts = new();

        private IMazeGenerator mazeGenerator;

        public DebugMazeApp()
        {
            this.InitializeComponent();
        }

        private async void BtnGenerate_Click(object sender, EventArgs e)
        {
            this.btnGenerate.Enabled = false;
            this.groupBoxConfiguration.Enabled = false;
            this.groupBoxMazeConfig.Enabled = false;

            this.mazeDisplay.Clear();

            this.mazeGenerator = new DefaultMazeGenerator(decimal.ToInt32(this.mazeHeight.Value), decimal.ToInt32(this.mazeWidth.Value))
            {
                Configuration = new Configuration
                {
                    NbMaxRunningCursor = decimal.ToUInt32(this.nbMaxRunningCursor.Value),
                    ProbabilityCursorToSplit = decimal.ToInt32(this.probabilityCursorToSplit.Value),
                    WaitingTimeCursorMs = decimal.ToUInt32(this.waitingTimeCursorMs.Value),
                },
            };

            this.mazeGenerator.CursorStateChanged += this.MazeGenerator_CursorStateChanged;

            Maze maze = this.mazeGenerator.InitMaze();
            maze.MazeCellUpdated += this.Maze_MazeCellUpdated;

            this.mazeDisplay.Maze = maze;

            await this.mazeGenerator.Generate(this.cts.Token);

            this.btnGenerate.Enabled = true;
            this.groupBoxConfiguration.Enabled = true;
            this.groupBoxMazeConfig.Enabled = true;
        }

        private void CheckBoxDifferentColorForEachCursor_CheckedChanged(object sender, EventArgs e) => this.mazeDisplay.DifferentColorForEachCursor = this.checkBoxDifferentColorForEachCursor.Checked;

        private void DebugMazeApp_Load(object sender, EventArgs e)
        {
            var writer = new TextBoxWriter(this.consoleOutput);
            Console.SetOut(writer);
        }

        private void Maze_MazeCellUpdated(object sender, MazeCellUpdatedEventArgs args)
        {
            int nbMazeCells = this.mazeGenerator.Maze.Height * this.mazeGenerator.Maze.Width;
            int nbMazeCellsTraveled = this.mazeGenerator.Maze.Count(c => c.Directions != EDirection.None);

            _ = this.progressBarMaze?.Invoke(new Action(() => this.progressBarMaze.Value = nbMazeCellsTraveled * 100 / nbMazeCells));
        }

        private void MazeGenerator_CursorStateChanged(int cursorId, EventArgs e)
        {
            _ = this.labelNbRuningCursor.Invoke(new Action(this.UpdateNbRunningCursor));

            _ = this.labelNbEndedCursor.Invoke(new Action(this.UpdateNbEndedCursor));

            _ = this.labelNbWaitingCursor.Invoke(new Action(this.UpdateNbWaitingCursor));

            _ = this.labelNbTotalCursor.Invoke(new Action(this.UpdateNbTotalCursor));

            _ = this.treeViewCursor.Invoke(new Action<int>(this.UpdateTreeView), cursorId);
        }

        private void UpdateNbEndedCursor() => this.labelNbEndedCursor.Text = $@"Number of ended cursors : {this.mazeGenerator.NbEndedCursors}";

        private void UpdateNbRunningCursor() => this.labelNbRuningCursor.Text = $@"Number of running cursors : {this.mazeGenerator.NbRunningCursors}";

        private void UpdateNbTotalCursor() => this.labelNbTotalCursor.Text = $@"Number total of cursors : {this.mazeGenerator.NbTotalCursors}";

        private void UpdateNbWaitingCursor() => this.labelNbWaitingCursor.Text = $@"Number of waiting cursors : {this.mazeGenerator.NbWaitingCursors}";

        private void UpdateTreeView(int cursorId)
        {
            TreeNode rootNode = this.treeViewCursor.Nodes["root"];

            if (!rootNode.Nodes.ContainsKey(cursorId.ToString()))
            {
                _ = rootNode.Nodes.Add(new TreeNode(cursorId.ToString())
                {
                    Name = cursorId.ToString(),
                    Text = cursorId.ToString(),
                });
            }
        }
    }
}