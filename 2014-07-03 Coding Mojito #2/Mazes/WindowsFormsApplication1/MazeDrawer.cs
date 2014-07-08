using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mazes.Core;

namespace Mazes.Runner
{
    public class MazeDrawer : Control, IMazeDrawer
    {
        private Point offset;
        private Point mouseOffset;
        private Size drawSize;
        private int pixelsPerSquare;
        private bool isPrepared = false;
        private bool isMousePrepared = false;
        private List<Rectangle> Lines = new List<Rectangle>();
        public Position MousePosition { get; set; }
        public Direction MouseDirection { get; set; }
        private Bitmap background;
        private Bitmap mouse;

        public Size MazeSize { get; set; }

        public MazeDrawer()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            isPrepared = false;
            base.OnSizeChanged(e);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Prepare();
            using (var backBrush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(backBrush, ClientRectangle);
            }
            if (isPrepared)
                e.Graphics.DrawImage(background, offset);
            if (isMousePrepared)
                PaintMouse(e.Graphics);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (background != null)
                background.Dispose();
            background = null;
            if (mouse != null)
                mouse.Dispose();
            mouse = null;
        }

        private void Prepare()
        {
            if (isPrepared)
                return;
            if (MazeSize.Width <= 0 || MazeSize.Height <= 0)
                return;
            isMousePrepared = false;
            var xScale = ClientSize.Width / (MazeSize.Width + 1);
            var yScale = ClientSize.Height / (MazeSize.Height + 1);
            pixelsPerSquare = Math.Min(xScale, yScale);
            drawSize = new Size(MazeSize.Width * pixelsPerSquare, MazeSize.Height * pixelsPerSquare);
            offset.X = (ClientSize.Width - drawSize.Width) / 2;
            offset.Y = (ClientSize.Height - drawSize.Height) / 2;
            if (background != null)
                background.Dispose();
            background = new Bitmap(drawSize.Width + 1, drawSize.Height + 1);
            using (var graphics = Graphics.FromImage(background))
            {
                using (var backBrush = new SolidBrush(Color.Black))
                {
                    graphics.FillRectangle(backBrush, new Rectangle(0, 0, drawSize.Width, drawSize.Height));
                }
                using (var gridPen = new Pen(Color.Orange, 0.25f))
                {
                    gridPen.DashStyle = DashStyle.Dot;
                    graphics.DrawRectangle(gridPen, 0, 0, drawSize.Width, drawSize.Height);
                    // vertical grid lines
                    for (var i = 0; i <= MazeSize.Width; i++)
                    {
                        graphics.DrawLine(gridPen, i * pixelsPerSquare, 0, i * pixelsPerSquare, drawSize.Height);
                    }
                    // horiz grid lines
                    for (var i = 0; i <= MazeSize.Height; i++)
                    {
                        graphics.DrawLine(gridPen, 0, i * pixelsPerSquare, drawSize.Width, i * pixelsPerSquare);
                    }
                }
                using (var wallsPen = new Pen(Color.White, 4))
                {
                    foreach (var line in Lines)
                    {
                        graphics.DrawLine(wallsPen, line.Left * pixelsPerSquare, line.Top * pixelsPerSquare, line.Right * pixelsPerSquare, line.Bottom * pixelsPerSquare);
                    }
                }

            }
            isPrepared = true;
        }

        private void PrepareMouse()
        {
            if (isMousePrepared)
                return;
            if (mouse != null)
                mouse.Dispose();
            var size = 3 * pixelsPerSquare / 4;
            mouse = new Bitmap(size, size);
            mouseOffset = new Point(offset.X + pixelsPerSquare / 8, offset.Y + pixelsPerSquare / 8);
            using (var graphics = Graphics.FromImage(mouse))
            {
                using (var backBrush = new SolidBrush(Color.Fuchsia))
                {
                    graphics.FillRectangle(backBrush, new Rectangle(0, 0, size, size));
                    using (var brush = new SolidBrush(Color.OrangeRed))
                    {
                        graphics.FillEllipse(brush, new Rectangle(0, size / 8, size, 3 * size / 4));
                    }
                    graphics.FillEllipse(backBrush, new Rectangle(3 * size / 4, size / 2 - size / 6, size / 6, size / 3));
                }
            }
            mouse.MakeTransparent(Color.Fuchsia);
            isMousePrepared = true;
        }

        private void PaintMouse(Graphics g)
        {
            PrepareMouse();
            using (var copy = new Bitmap(mouse))
            {
                switch (MouseDirection)
                {
                    case Direction.South: copy.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case Direction.North: copy.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.West: copy.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                }                
                g.DrawImage(copy, mouseOffset.X + MousePosition.X * pixelsPerSquare,
                            mouseOffset.Y + MousePosition.Y * pixelsPerSquare);
            }
        }

        public void StartLayout(int width, int height)
        {
            MazeSize = new Size(width, height);
            Lines.Clear();
            isPrepared = false;
        }

        public void LayoutDone()
        {
            Prepare();
            Invalidate();
        }

        public void DrawWall(Position fromPos, Position toPos)
        {
            Lines.Add(new Rectangle(fromPos.X, fromPos.Y, toPos.X - fromPos.X, toPos.Y - fromPos.Y));
        }

        public void DrawMouse(Position position, Direction direction)
        {
            MousePosition = position;
            MouseDirection = direction;
            PrepareMouse();
            Invalidate();
        }
    }
}
