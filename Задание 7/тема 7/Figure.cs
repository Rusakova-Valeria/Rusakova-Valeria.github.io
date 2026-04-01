using System;
using System.Drawing;

namespace тема_7
{
    [Serializable]
    public abstract class Figure
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Stroke Stroke { get; set; }
        public int Id { get; set; }
        protected bool _reflectedX;
        protected bool _reflectedY;
        protected float _rotationAngle;

        protected Figure(Point location, Size size, Stroke stroke)
        {
            Location = location;
            Size = size;
            Stroke = stroke?.Clone() ?? new Stroke();
            Id = GetHashCode();
        }

        public Rectangle Bounds => new Rectangle(Location, Size);

        public abstract void Draw(Graphics g);

        public virtual void Move(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
        }

        public void ShiftRight(int pixels) => Move(pixels, 0);
        public void ShiftLeft(int pixels) => Move(-pixels, 0);
        public void ShiftUp(int pixels) => Move(0, -pixels);
        public void ShiftDown(int pixels) => Move(0, pixels);

        public virtual bool ContainsPoint(Point point)
        {
            return Bounds.Contains(point);
        }

        public virtual void ReflectX() => _reflectedX = !_reflectedX;
        public virtual void ReflectY() => _reflectedY = !_reflectedY;
        public virtual void Rotate(float angle) => _rotationAngle = (_rotationAngle + angle) % 360;

        public virtual Figure Clone()
        {
            var fig = (Figure)MemberwiseClone();
            fig.Stroke = Stroke.Clone();
            return fig;
        }

        public virtual void Resize(int newWidth, int newHeight)
        {
            Size = new Size(Math.Max(10, newWidth), Math.Max(10, newHeight));
        }
    }
}
