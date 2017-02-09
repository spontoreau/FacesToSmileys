namespace FacesToSmileys.Models
{
    /// <summary>
    /// Point
    /// </summary>
    public class Point
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
        /// Initializes a new instance of the <see cref="T:FacesToSmileys.Models.Point"/> class.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
