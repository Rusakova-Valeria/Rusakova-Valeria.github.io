using System;
using System.Drawing;

namespace тема_7
{
    [Serializable]
    public class Ellipse : Figure
    {
        public Ellipse(Point location, Size size, Stroke stroke) : base(location, size, stroke) { }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);

            if (Stroke.HasFill && Stroke.FillColor != Color.Transparent)
            {
                using (var brush = new SolidBrush(Stroke.FillColor))
                    g.FillEllipse(brush, rect);
            }

            using (var pen = Stroke.GetPen())
                g.DrawEllipse(pen, rect);
        }

        public override bool ContainsPoint(Point point)
        {
            Point center = new Point(Location.X + Size.Width / 2, Location.Y + Size.Height / 2);
            double rx = Size.Width / 2.0;
            double ry = Size.Height / 2.0;
            if (rx == 0 || ry == 0) return false;
            double dx = (point.X - center.X) / rx;
            double dy = (point.Y - center.Y) / ry;
            return dx * dx + dy * dy <= 1;
        }
    }
}
