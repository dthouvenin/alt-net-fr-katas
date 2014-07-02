using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mazes.Core;

namespace WindowsFormsApplication1
{
    public class MazeDrawer: Control, IMazeDrawer
    {
        private int xOffset;
        private int yOffset;
        private int drawSize;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        public void DrawWall(Position fromPos, Position toPos)
        {
            
        }

        public void DrawMouse(Position position, Direction direction)
        {
            
        }
    }
}
