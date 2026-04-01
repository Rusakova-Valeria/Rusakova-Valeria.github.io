using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace тема_7
{
    [Serializable]
    public class HalfCircle : Figure
    {
        public HalfCircle(Point location, Size size, Stroke stroke) : base(location, size, stroke) { }

        public override void Draw(Graphics g)
        {
            int diameter = Math.Min(Size.Width, Size.Height);
            var rect = new Rectangle(Location.X, Location.Y, diameter, diameter);

            GraphicsState state = g.Save();

            if (_reflectedX || _reflectedY)
            {
                Matrix transform = new Matrix();
                if (_reflectedX) transform.Scale(-1, 1);
                if (_reflectedY) transform.Scale(1, -1);
                transform.Translate(
                    _reflectedX ? -(2 * Location.X + diameter) : 0,
                    _reflectedY ? -(2 * Location.Y + diameter) : 0, MatrixOrder.Append);
                g.Transform = transform;
            }

            if (Stroke.HasFill && Stroke.FillColor != Color.Transparent)
            {
                using (var brush = new SolidBrush(Stroke.FillColor))
                    g.FillPie(brush, rect, 0, 180);
            }

            using (var pen = Stroke.GetPen())
            {
                g.DrawArc(pen, rect, 0, 180);
                g.DrawLine(pen, Location.X, Location.Y + diameter / 2, Location.X + diameter, Location.Y + diameter / 2);
            }

            g.Restore(state);
        }

        public override void ReflectX() => _reflectedX = !_reflectedX;
        public override void ReflectY() => _reflectedY = !_reflectedY;
    }
}
