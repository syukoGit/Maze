// -----------------------------------------------------------------------
//  <copyright project="DebugMazeApplication" file="DebugMazeApp.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
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

    /// <summary>
    ///     A form which can configure and generate a maze.
    ///     It displays information about the maze live and contains debug tools.
    /// </summary>
    internal sealed partial class DebugMazeApp : Form
    {
        /// <summary>
        ///     Represents a source of <see cref="CancellationToken" /> used by the maze generator.
        /// </summary>
        private readonly CancellationTokenSource cts = new ();

        /// <summary>
        ///     Represents the maze generator used by the <see cref="DebugMazeApp" />.
        /// </summary>
        private IMazeGenerator mazeGenerator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DebugMazeApp" /> class.
        /// </summary>
        public DebugMazeApp()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Called when the generate button is clicked.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs" /> that contains no event data.</param>
        // ReSharper disable once AsyncVoidMethod
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

        /// <summary>
        ///     Called when the Checked property of the checkbox "different color for each cursor" changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs" /> that contains no event data.</param>
        private void CheckBoxDifferentColorForEachCursor_CheckedChanged(object sender, EventArgs e) => this.mazeDisplay.DifferentColorForEachCursor = this.checkBoxDifferentColorForEachCursor.Checked;

        /// <summary>
        ///     Called when the form is loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="EventArgs" /> that contains no event data.</param>
        private void DebugMazeApp_Load(object sender, EventArgs e)
        {
            var writer = new TextBoxWriter(this.consoleOutput);
            Console.SetOut(writer);
        }

        /// <summary>
        ///     Called when a maze cell of the maze is updated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Maze_MazeCellUpdated(object sender, MazeCellUpdatedEventArgs args)
        {
            int nbMazeCells = this.mazeGenerator.Maze.Height * this.mazeGenerator.Maze.Width;
            int nbMazeCellsTraveled = this.mazeGenerator.Maze.Count(static c => c.Directions != EDirection.None);

            _ = this.progressBarMaze?.Invoke(new Action(() => this.progressBarMaze.Value = nbMazeCellsTraveled * 100 / nbMazeCells));
        }

        /// <summary>
        ///     Called when a cursor's state changes.
        /// </summary>
        /// <param name="cursorId">The id of the cursor.</param>
        /// <param name="e">A <see cref="EventArgs" /> that contains no event data.</param>
        private void MazeGenerator_CursorStateChanged(int cursorId, EventArgs e)
        {
            _ = this.labelNbRuningCursor.Invoke(new Action(this.UpdateNbRunningCursor));

            _ = this.labelNbEndedCursor.Invoke(new Action(this.UpdateNbEndedCursor));

            _ = this.labelNbWaitingCursor.Invoke(new Action(this.UpdateNbWaitingCursor));

            _ = this.labelNbTotalCursor.Invoke(new Action(this.UpdateNbTotalCursor));

            _ = this.treeViewCursor.Invoke(new Action<int>(this.UpdateTreeView), cursorId);
        }

        /// <summary>
        ///     Updates the control that display the number of ended cursors.
        /// </summary>
        private void UpdateNbEndedCursor() => this.labelNbEndedCursor.Text = $@"Number of ended cursors : {this.mazeGenerator.NbEndedCursors}";

        /// <summary>
        ///     Updates the control that display the number of running cursors.
        /// </summary>
        private void UpdateNbRunningCursor() => this.labelNbRuningCursor.Text = $@"Number of running cursors : {this.mazeGenerator.NbRunningCursors}";

        /// <summary>
        ///     Updates the control that display the number total of cursors.
        /// </summary>
        private void UpdateNbTotalCursor() => this.labelNbTotalCursor.Text = $@"Number total of cursors : {this.mazeGenerator.NbTotalCursors}";

        /// <summary>
        ///     Updates the control that display the number of waiting cursors.
        /// </summary>
        private void UpdateNbWaitingCursor() => this.labelNbWaitingCursor.Text = $@"Number of waiting cursors : {this.mazeGenerator.NbWaitingCursors}";

        /// <summary>
        ///     Adds or updates a cursor in the tree view.
        /// </summary>
        /// <param name="cursorId">The cursor to be add or update.</param>
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