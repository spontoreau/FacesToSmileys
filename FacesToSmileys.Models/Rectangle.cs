namespace FacesToSmileys.Models
{
    /// <summary>
    /// Rectangle
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public float X { get; }

        /// <summary>
        /// Y coordinate
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// Width
        /// </summary>
        public float Width { get; }

        /// <summary>
        /// Height
        /// </summary>
        public float Height { get; }

        /// <summary>
        /// Top left point
        /// </summary>
        public Point TopLeft
        {
            get
            {
                return new Point(X, Y);
            }
        }

        /// <summary>
        /// Top right point
        /// </summary>
        public Point TopRight
        {
            get
            {
                return new Point(X + Width, Y);
            }
        }

        /// <summary>
        /// Bottom left point
        /// </summary>
        public Point BottomLeft
        {
            get
            {
                return new Point(X, Y + Height);
            }
        }

        /// <summary>
        /// Bottom right point
        /// </summary>
        public Point BottomRight
        {
            get
            {
                return new Point(X + Width, Y + Height);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FacesToSmileys.Models.Rectangle"/> class.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">Width</param>
        /// <param name="height">Height</param>
        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
