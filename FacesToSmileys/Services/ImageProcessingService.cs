using System;
using System.IO;
using SkiaSharp;

namespace FacesToSmileys.Services
{
    public class ImageProcessingService
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
            Surface.Canvas.DrawImage(Image, new SKRect(0f, 0f, ImageInfo.Width, ImageInfo.Height), new SKRect(0f, 0f, ImageInfo.Width, ImageInfo.Height), Paint);
            IsOpen = true;
        }

        public void DrawDebugRect(int x, int y, int width, int height, string hexColor)
        {
            if (!IsOpen)
                throw new InvalidOperationException("No image opened");
            
            Paint.Color = SKColor.Parse(hexColor);

            Surface.Canvas.DrawLine(x, y, x + width, y, Paint);//TOP line
            Surface.Canvas.DrawLine(x, y, x, y + height, Paint);//LEFT line
            Surface.Canvas.DrawLine(x + width, y, x + width, y + height, Paint);//RIGHT line
            Surface.Canvas.DrawLine(x , y + height, x + width, y + height, Paint);//BOTTOM line
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
