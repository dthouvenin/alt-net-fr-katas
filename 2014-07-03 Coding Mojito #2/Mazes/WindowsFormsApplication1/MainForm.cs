using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mazes.Core;

namespace Mazes.Runner
{
    public partial class MainForm : Form, IMazeWatcher
    {
        private MazeDrawer drawer;
        private IMazeBuilder builder;
        private Maze maze;

        public MainForm()
        {
            InitializeComponent();
        }


        void IMazeWatcher.MazeHasBeenBuilt(int with, int height)
        {
        }

        void IMazeWatcher.MouseWantsToMove()
        {
            throw new NotImplementedException();
        }

        void IMazeWatcher.MouseHasMoved(Position newPosition)
        {
            throw new NotImplementedException();
        }

        void IMazeWatcher.MouseHasTurned(Direction newDirection)
        {
            throw new NotImplementedException();
        }

        void IMazeWatcher.MouseHasExitedMaze()
        {
            throw new NotImplementedException();
        }

        void IMazeWatcher.YouHaveBeenUnsubscribed()
        {
            throw new NotImplementedException();
        }
    }
}
