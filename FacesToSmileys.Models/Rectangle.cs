using System;
namespace FacesToSmileys.Models
{
    public class Rectangle
    {
        public float X { get; }
        public float Y { get; }
        public float Width { get; }
        public float Heigth { get; }

        public Point TopLeft
        {
            get
            {
                return new Point(X, Y);
            }
        }

        public Point TopRight
        {
            get
            {
                return new Point(X + Width, Y);
            }
        }

        public Point BottomLeft
        {
            get
            {
                return new Point(X, Y + Heigth);
            }
        }

        public Point BottomRight
        {
            get
            {
                return new Point(X + Width, Y + Heigth);
            }
        }

        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Heigth = height;
        }
    }
}
