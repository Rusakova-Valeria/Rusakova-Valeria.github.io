using System;
using System.Drawing;

namespace тема_7
{
    [Serializable]
    public class Circle : Figure
    {
        public Circle(Point location, Size size, Stroke stroke) : base(location, size, stroke) { }

        public override void Draw(Graphics g)
        {
            int diameter = Math.Min(Size.Width, Size.Height);
            var rect = new Rectangle(Location.X, Location.Y, diameter, diameter);

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
            int radius = Math.Min(Size.Width, Size.Height) / 2;
            Point center = new Point(Location.X + radius, Location.Y + radius);
            int dx = point.X - center.X;
            int dy = point.Y - center.Y;
            return dx * dx + dy * dy <= radius * radius;
        }
    }
}
