namespace FacesToSmileys.Models
{
    /// <summary>
    /// Detection
    /// </summary>
    public class Detection
    {
        /// <summary>
        /// Emotion
        /// </summary>
        public string Emotion { get; }

        /// <summary>
        /// Detection rectangle
        /// </summary>
        public Rectangle Rectangle { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FacesToSmileys.Models.Detection"/> class.
        /// </summary>
        /// <param name="emotion">Emotion</param>
        /// <param name="rectangle">Detection rectangle</param>
        public Detection(string emotion, Rectangle rectangle)
        {
            Emotion = emotion;
            Rectangle = rectangle;
        }
    }
}
