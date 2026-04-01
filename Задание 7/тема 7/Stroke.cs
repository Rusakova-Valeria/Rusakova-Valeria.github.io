using System;
using System.Drawing;

namespace тема_7
{
    [Serializable]
    public class Stroke
    {
        public Color Color { get; set; } = Color.Black;
        public float Width { get; set; } = 2f;
        public System.Drawing.Drawing2D.DashStyle DashStyle { get; set; } = System.Drawing.Drawing2D.DashStyle.Solid;
        public Color FillColor { get; set; } = Color.Transparent;
        public bool HasFill { get; set; } = false;

        public Stroke() { }

        public Stroke(Color color, float width)
        {
            Color = color;
            Width = width;
        }

        public Pen GetPen()
        {
            var pen = new Pen(Color, Width)
            {
                DashStyle = DashStyle
            };
            return pen;
        }

        public Brush GetBrush()
        {
            if (HasFill && FillColor != Color.Transparent)
                return new SolidBrush(FillColor);
            return null;
        }

        public Stroke Clone()
        {
            return new Stroke(Color, Width)
            {
                FillColor = FillColor,
                HasFill = HasFill,
                DashStyle = DashStyle
            };
        }
    }
}
