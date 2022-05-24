// -----------------------------------------------------------------------
//  <copyright project="DebugMazeApplication" file="MazeDisplay.cs" company="SyukoTech">
//  Copyright (c) SyukoTech. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace DebugMazeApplication.Controls
{
    using MazeGenerator.Types.Base;
    using MazeGenerator.Types.Mazes;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    ///     A control which display a maze in the course of generation or finished.
    /// </summary>
    public sealed partial class MazeDisplay : UserControl
    {
        /// <summary>
        ///     A dictionary which links each cursor to a color.
        ///     Used when the <see cref="DifferentColorForEachCursor" /> is true.
        /// </summary>
        private readonly Dictionary<int, Color> cursorColor = new ();

        /// <summary>
        ///     A dictionary which links each maze cell to a color.
        /// </summary>
        private readonly Dictionary<Coordinates, Color> mazeCellColor = new ();

        /// <summary>
        ///     The maze to be displayed.
        /// </summary>
        private Maze maze;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MazeDisplay" /> class.
        /// </summary>
        public MazeDisplay()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Rectangle structure that, together with the <see cref="SrcRect" /> parameter, specifies a scale transformation for
        ///     the container.
        /// </summary>
        private RectangleF DestRect { get; set; } = RectangleF.Empty;

        /// <summary>
        ///     Gets or sets a value indicating whether the <see cref="MazeDisplay" /> used a different color for each cursor.
        /// </summary>
        public bool DifferentColorForEachCursor { get; set; }

        /// <summary>
        ///     Gets or sets the maze to be display.
        /// </summary>
        public Maze Maze
        {
            get => this.maze;

            set
            {
                if (this.maze != null)
                {
                    this.maze.MazeCellUpdated -= this.Maze_MazeCellUpdated;
                }

                this.maze = value;

                if (this.maze == null)
                {
                    return;
                }

                this.maze.MazeCellUpdated += this.Maze_MazeCellUpdated;
                this.DestRect = new RectangleF(0.0F, 0.0F, (this.Maze.Width * 2) + 1, (this.Maze.Height * 2) + 1);

                this.Invalidate();
            }
        }

        /// <summary>
        ///     Rectangle structure that, together with the <see cref="DestRect" /> parameter, specifies a scale transformation for
        ///     the container.
        /// </summary>
        private RectangleF SrcRect { get; set; } = RectangleF.Empty;

        /// <summary>
        ///     Clear the <see cref="MazeDisplay" /> and its data.
        /// </summary>
        public void Clear()
        {
            this.cursorColor.Clear();
            this.mazeCellColor.Clear();
        }

        /// <summary>
        ///     Draw a cell of the maze.
        /// </summary>
        /// <param name="graphics">The drawing surface.</param>
        /// <param name="mazeCell">The maze cell to be draw.</param>
        private void DrawMazeCell(Graphics graphics, MazeCell mazeCell)
        {
            Color color = this.mazeCellColor.ContainsKey(mazeCell.Coordinates)
                              ? this.mazeCellColor[mazeCell.Coordinates]
                              : Color.White;

            (EDirection directions, (int x, int y)) = mazeCell;

            graphics.FillRectangle(new SolidBrush(color), (x * 2) + 1, (y * 2) + 1, 1, 1);

            if (directions.HasFlag(EDirection.Down))
            {
                graphics.FillRectangle(new SolidBrush(color), (x * 2) + 1, (y * 2) + 2, 1, 1);
            }

            if (directions.HasFlag(EDirection.Left))
            {
                graphics.FillRectangle(new SolidBrush(color), x * 2, (y * 2) + 1, 1, 1);
            }

            if (directions.HasFlag(EDirection.Right))
            {
                graphics.FillRectangle(new SolidBrush(color), (x * 2) + 2, (y * 2) + 1, 1, 1);
            }

            if (directions.HasFlag(EDirection.Top))
            {
                graphics.FillRectangle(new SolidBrush(color), (x * 2) + 1, y * 2, 1, 1);
            }
        }

        /// <summary>
        ///     Called when a maze cell is updated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">A <see cref="MazeCellUpdatedEventArgs" /> which contains the update information.</param>
        private void Maze_MazeCellUpdated(object sender, MazeCellUpdatedEventArgs args)
        {
            (MazeCell mazeCell, int cursorId) = args;

            if (this.DifferentColorForEachCursor)
            {
                if (!this.cursorColor.ContainsKey(cursorId))
                {
                    var r = new Random(cursorId);
                    this.cursorColor[cursorId] = Color.FromArgb(r.Next(40, 256), r.Next(40, 256), r.Next(40, 256));
                }
            }
            else
            {
                this.cursorColor[cursorId] = Color.White;
            }

            this.mazeCellColor[mazeCell.Coordinates] = this.cursorColor[cursorId];

            Graphics graphic = this.CreateGraphics();

            GraphicsContainer containerState = graphic.BeginContainer(this.SrcRect, this.DestRect, GraphicsUnit.Pixel);

            this.DrawMazeCell(graphic, mazeCell);

            graphic.EndContainer(containerState);
        }

        /// <summary>
        ///     Called when the control needs to be redrawn.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="PaintEventArgs" /> which contains the event information.</param>
        private void MazeDisplay_Paint(object sender, PaintEventArgs e)
        {
            if (this.InvokeRequired)
            {
                new PaintEventHandler(this.MazeDisplay_Paint).Invoke(sender, e);
                return;
            }

            GraphicsContainer containerState = e.Graphics.BeginContainer(this.SrcRect, this.DestRect, GraphicsUnit.Pixel);

            e.Graphics.Clear(this.BackColor);

            if (this.Maze != null)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), this.Maze.Entry.X * 2, (this.Maze.Entry.Y * 2) + 1, 1, 1);
                e.Graphics.FillRectangle(new SolidBrush(Color.White), (this.Maze.Exit.X * 2) + 2, (this.Maze.Exit.Y * 2) + 1, 1, 1);

                lock (this.Maze)
                {
                    var mazeCells = this.Maze.Where(static c => c.Directions != EDirection.None).ToList();
                    mazeCells.ForEach(c => this.DrawMazeCell(e.Graphics, c));
                }
            }
            else
            {
                e.Graphics.DrawString("No maze", new Font(FontFamily.GenericSerif, 12), new SolidBrush(Color.White), 0, 0);
            }

            e.Graphics.EndContainer(containerState);
        }

        /// <summary>
        ///     Called when the control is resize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MazeDisplay_Resize(object sender, EventArgs e)
        {
            this.SrcRect = new RectangleF(this.Padding.Left, this.Padding.Top, this.Width - this.Padding.Left - this.Padding.Right, this.Height - this.Padding.Top - this.Padding.Bottom);
            this.Invalidate();
        }
    }
}