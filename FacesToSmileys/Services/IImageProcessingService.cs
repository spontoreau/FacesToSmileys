using FacesToSmileys.Models;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define an image processing service
    /// </summary>
    public interface IImageProcessingService
    {
        /// <summary>
        /// Open an image
        /// </summary>
        /// <param name="image">Byte array corresponding to the image</param>
        void Open(byte[] image);

        /// <summary>
        /// Draw a debug rectangle on the image
        /// </summary>
        /// <param name="rectangle">Rectangle to draw</param>
        void DrawDebugRect(Rectangle rectangle);

        /// <summary>
        /// Draw a debug line on the image
        /// </summary>
        /// <param name="start">Start point</param>
        /// <param name="end">End point</param>
        void DrawDebugLine(Point start, Point end);

        /// <summary>
        /// Draw another image on the immage
        /// </summary>
        /// <param name="image">Byte array corresponding to an image</param>
        /// <param name="bounds">Drawing bounds</param>
        void DrawImage(byte[] image, Rectangle bounds);

        /// <summary>
        /// Get the modify image
        /// </summary>
        /// <returns>Byte array corresponding to the modify image</returns>
        byte[] GetImage();

        /// <summary>
        /// Close the current image
        /// </summary>
        void Close();
    }
}
