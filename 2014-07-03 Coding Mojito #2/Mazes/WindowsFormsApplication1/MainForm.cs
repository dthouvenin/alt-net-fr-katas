using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Mazes.Core;

namespace Mazes.Runner
{
    public partial class MainForm : Form, IMazeWatcher
    {
        private readonly string builderPath;
        private readonly string solverPath;
        private IMazeBuilder builder;
        private IMazeSolver solver;
        private Maze maze;
        private StringBuilder logText = new StringBuilder();
        private bool mazeIsBuilt = false;
        private bool running = false;
        private MazeDrawer Drawer;

        public MainForm()
        {
            InitializeComponent();
            Drawer = new MazeDrawer();
            Drawer.Left = 5;
            Drawer.Top = 5;
            Drawer.Width = drawPanel.ClientSize.Width - 10;
            Drawer.Height = drawPanel.ClientSize.Height - 10;
            Drawer.Anchor = AnchorStyles.Left|AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Right;
            Drawer.Parent = drawPanel;            
        }

        public MainForm(string builderPath, string solverPath) : this()
        {
            this.builderPath = Path.GetFullPath(builderPath);
            this.solverPath = Path.GetFullPath(solverPath);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (builderPath != null)
            {
                LoadBuilder(builderPath);
                BuildMaze();
            }

            if (solverPath != null)
            {
                LoadSolver(solverPath);
                EnableActionButtons(true);
            }
        }

        private void ClearLog()
        {
            logText.Clear();
            logBox.Clear();
        }

        private void Log(string msgFmt, params object[] args)
        {
            logText.AppendLine(string.Format(msgFmt, args));
            logBox.Text = logText.ToString();
        }


        void IMazeWatcher.MazeHasBeenBuilt(int with, int height)
        {
            mazeIsBuilt = true;
        }

        void IMazeWatcher.MouseWantsToMove()
        {
        }

        void IMazeWatcher.MouseHasMoved(Position newPosition)
        {
            Drawer.DrawMouse(newPosition, Drawer.MouseDirection);
            Log("Mouse has moved to [{0},{1}]", newPosition.X, newPosition.Y);
        }

        void IMazeWatcher.MouseHasTurned(Direction newDirection)
        {
            Drawer.DrawMouse(Drawer.MousePosition, newDirection);
            Log("Mouse has turned to {0}", newDirection);
        }

        void IMazeWatcher.MouseHasExitedMaze()
        {
            running = false;
            Log("Yipee ! Mouse has exited");
        }

        void IMazeWatcher.YouHaveBeenUnsubscribed()
        {
        }

        private void loadBuilder_Click(object sender, EventArgs e)
        {
            EnableActionButtons(false);
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                LoadBuilder(openFileDialog1.FileName);
            }
            finally
            {
                EnableActionButtons(true);
            }
        }

        private void LoadBuilder(string fileName)
        {
            try
            {
                var newBuilder = Loader.Load<IMazeBuilder>(fileName);
                mazeIsBuilt = false;
                builder = newBuilder;
            }
            catch (InstanceNotFoundException)
            {
                MessageBox.Show("This assembly doesn't seem to contain a public IMazeBuilder implementation");
            }
        }

        private void EnableActionButtons(bool enable)
        {
            loadBuilder.Enabled = enable;
            loadSolver.Enabled = enable;
            Build.Enabled = enable && builder != null;
            Solve.Enabled = enable && solver != null && mazeIsBuilt;
            maxMoves.Enabled = enable;
        }

        private void loadSolver_Click(object sender, EventArgs e)
        {
            EnableActionButtons(false);
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;
                LoadSolver(openFileDialog1.FileName);
            }
            finally
            {
                EnableActionButtons(true);
            }
        }

        private void LoadSolver(string fileName)
        {
            try
            {
                var newSolver = Loader.Load<IMazeSolver>(fileName);
                solver = newSolver;
            }
            catch (InstanceNotFoundException)
            {
                MessageBox.Show("This assembly doesn't seem to contain a public IMazeSolver implementation");
            }
        }

        private void Build_Click(object sender, EventArgs e)
        {
            BuildMaze();
        }

        private void BuildMaze()
        {
            EnableActionButtons(false);
            try
            {
                maze = new Maze(builder);
                maze.Subscribe(this);
                maze.Draw(Drawer);
                Drawer.DrawMouse(builder.MazeStartPosition, Direction.East);
                Drawer.Invalidate();
                mazeIsBuilt = true;
            }
            finally
            {
                EnableActionButtons(true);
            }
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            EnableActionButtons(false);
            try
            {
                ClearLog();
                drawPanel.BackColor = Color.Gold;
                solver.Init(maze as IMaze, maze as IMouse);
                running = true;
                var moves = maxMoves.Value;
                while (--moves>0 && running)
                {
                    solver.YourTurn();           
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
                if (moves > 0)
                {
                    drawPanel.BackColor = Color.LimeGreen;
                    solver.YouWin();
                    timer1.Enabled = true;
                }
                else
                {
                    drawPanel.BackColor = Color.Red;
                    solver.YouLoose();
                    timer1.Enabled = true;
                }
            }
            finally
            {
                running = false;
                EnableActionButtons(true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            maze.Reset();
            drawPanel.BackColor = Color.Black;
            Drawer.DrawMouse(builder.MazeStartPosition, Direction.East);
            Drawer.Invalidate();
        }

    }
}
