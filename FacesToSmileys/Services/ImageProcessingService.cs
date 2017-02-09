using System;
using System.IO;
using FacesToSmileys.Models;
using SkiaSharp;

namespace FacesToSmileys.Services
{
    public class ImageProcessingService : IImageProcessingService
    {
        SKImage Image { get; set; }
        SKImageInfo ImageInfo { get; set; }
        SKPaint Paint { get; set; }
        SKSurface Surface { get; set; }
        bool IsOpen { get; set; }

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

        public void DrawDebugRect(Rectangle rectangle)
        {
            if (!IsOpen)
                throw new InvalidOperationException("No image opened");
            
            DrawDebugLine(rectangle.TopLeft, rectangle.TopRight);       //TOP line
            DrawDebugLine(rectangle.TopLeft, rectangle.BottomLeft);     //LEFT line
            DrawDebugLine(rectangle.TopRight, rectangle.BottomRight);   //RIGHT line
            DrawDebugLine(rectangle.BottomLeft, rectangle.BottomRight); //BOTTOM line
        }


        public void DrawDebugLine(Point start, Point end)
        {
            Surface.Canvas.DrawLine(start.X, start.Y, end.X, end.Y, Paint);
        }

        public void DrawImage(byte[] image, Rectangle bounds)
        {
            using (var data = new SKData(image))
            {
                using (var skImage = SKImage.FromData(new SKData(image)))
                {
                    var xScale = bounds.Width / skImage.Width;
                    var yScale = bounds.Heigth / skImage.Height;
                    Surface.Canvas.SetMatrix(SKMatrix.MakeScale(xScale, yScale));
                    Surface.Canvas.DrawImage(skImage, bounds.X / xScale, bounds.Y / yScale);//We want to scale width & height, not X & Y
                    Surface.Canvas.ResetMatrix();
                }
            }
        }

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
