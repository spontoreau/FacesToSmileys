using System;
using System.IO;
using FacesToSmileys.Models;
using SkiaSharp;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Image processing service
    /// </summary>
    public class ImageProcessingService : IImageProcessingService
    {
        /// <summary>
        /// Opened image
        /// </summary>
        SKImage Image { get; set; }

        /// <summary>
        /// Opened image information
        /// </summary>
        SKImageInfo ImageInfo { get; set; }

        /// <summary>
        /// Paint object
        /// </summary>
        SKPaint Paint { get; set; }

        /// <summary>
        /// Surface for drawing
        /// </summary>
        SKSurface Surface { get; set; }

        /// <summary>
        /// True if image is open, otherwise false
        /// </summary>
        bool IsOpen { get; set; }

        /// <summary>
        /// Open an image
        /// </summary>
        /// <param name="image">Byte array corresponding to the image</param>
        public void Open(byte[] image)
        {
            if (IsOpen)
                throw new InvalidOperationException("An image is opened");

            using(var stream = new MemoryStream(image))
            {
                using (var skStream = new SKManagedStream(stream))
                {
                    using (var codec = SKCodec.Create(skStream))
                    {
                        ImageInfo = codec.Info;
                    }
                }
            }

            using(var data = new SKData(image))
            {
                Image = SKImage.FromData(new SKData(image));
            }

            Surface = SKSurface.Create(ImageInfo);
            Paint = new SKPaint();
            Paint.Color = SKColor.Parse("#2ecc71");
            Surface.Canvas.DrawImage(Image, new SKRect(0f, 0f, ImageInfo.Width, ImageInfo.Height), new SKRect(0f, 0f, ImageInfo.Width, ImageInfo.Height), Paint);
            IsOpen = true;
        }

        /// <summary>
        /// Draw a debug rectangle on the image
        /// </summary>
        /// <param name="rectangle">Rectangle to draw</param>
        public void DrawDebugRect(Rectangle rectangle)
        {
            if (!IsOpen)
                throw new InvalidOperationException("No image opened");
            
            DrawDebugLine(rectangle.TopLeft, rectangle.TopRight);       //TOP line
            DrawDebugLine(rectangle.TopLeft, rectangle.BottomLeft);     //LEFT line
            DrawDebugLine(rectangle.TopRight, rectangle.BottomRight);   //RIGHT line
            DrawDebugLine(rectangle.BottomLeft, rectangle.BottomRight); //BOTTOM line
        }

        /// <summary>
        /// Draw a debug line on the image
        /// </summary>
        /// <param name="start">Start point</param>
        /// <param name="end">End point</param>
        public void DrawDebugLine(Point start, Point end)
        {
            Surface.Canvas.DrawLine(start.X, start.Y, end.X, end.Y, Paint);
        }

        /// <summary>
        /// Draw another image on the immage
        /// </summary>
        /// <param name="image">Byte array corresponding to an image</param>
        /// <param name="bounds">Drawing bounds</param>
        public void DrawImage(byte[] image, Rectangle bounds)
        {
            using (var data = new SKData(image))
            {
                using (var skImage = SKImage.FromData(new SKData(image)))
                {
                    var xScale = bounds.Width / skImage.Width;
                    var yScale = bounds.Height / skImage.Height;
                    Surface.Canvas.SetMatrix(SKMatrix.MakeScale(xScale, yScale));
                    Surface.Canvas.DrawImage(skImage, bounds.X / xScale, bounds.Y / yScale);//We want to scale width & height, not X & Y
                    Surface.Canvas.ResetMatrix();
                }
            }
        }

        /// <summary>
        /// Get the modify image
        /// </summary>
        /// <returns>Byte array corresponding to the modify image</returns>
        public byte[] GetImage()
        {
            if (!IsOpen)
                throw new InvalidOperationException("No image opened");
            
            using(var ms = new MemoryStream())
            {
                using (var snapShot = Surface.Snapshot())
                {   
                    using (var data = snapShot.Encode(SKImageEncodeFormat.Png, 80))
                    {
                        data.SaveTo(ms);
                    }
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Close the current image
        /// </summary>
        public void Close()
        {
            if (!IsOpen)
                throw new InvalidOperationException("No image opened");
            
            Paint.Dispose();
            Surface.Dispose();
            Image.Dispose();
            IsOpen = false;
        }
    }
}
