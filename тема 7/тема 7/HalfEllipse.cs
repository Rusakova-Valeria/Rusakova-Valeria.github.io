using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace тема_7
{
    [Serializable]
    public class HalfEllipse : Figure
    {
        public HalfEllipse(Point location, Size size, Stroke stroke) : base(location, size, stroke) { }

        public override void Draw(Graphics g)
        {
            GraphicsState state = g.Save();

            if (_reflectedX || _reflectedY)
            {
                Matrix transform = new Matrix();
                if (_reflectedX) transform.Scale(-1, 1);
                if (_reflectedY) transform.Scale(1, -1);
                transform.Translate(
                    _reflectedX ? -(2 * Location.X + Size.Width) : 0,
                    _reflectedY ? -(2 * Location.Y + Size.Height) : 0, MatrixOrder.Append);
                g.Transform = transform;
            }

            if (Stroke.HasFill && Stroke.FillColor != Color.Transparent)
            {
                using (var brush = new SolidBrush(Stroke.FillColor))
                    g.FillEllipse(brush, Location.X, Location.Y, Size.Width, Size.Height);
            }

            using (var pen = Stroke.GetPen())
            {
                g.DrawEllipse(pen, Location.X, Location.Y, Size.Width, Size.Height);
                g.DrawLine(pen, Location.X, Location.Y + Size.Height / 2, Location.X + Size.Width, Location.Y + Size.Height / 2);
            }

            g.Restore(state);
        }

        public override void ReflectX() => _reflectedX = !_reflectedX;
        public override void ReflectY() => _reflectedY = !_reflectedY;
    }
}
