using System;
namespace FacesToSmileys.Models
{
    public class Detection
    {
        public Attitude Attitude { get; }
        public Rectangle Rectangle { get; }

        public Detection(Attitude attitude, Rectangle rectangle)
        {
            Attitude = attitude;
            Rectangle = rectangle;
        }
    }
}
