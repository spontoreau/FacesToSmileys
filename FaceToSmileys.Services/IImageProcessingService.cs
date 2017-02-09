using System;
using FacesToSmileys.Models;

namespace FacesToSmileys.Services
{
    public interface IImageProcessingService
    {
        void Open(byte[] image);
        void DrawDebugRect(Rectangle rectangle);
        void DrawDebugLine(Point start, Point end);
        void DrawImage(byte[] image, Rectangle bounds);
        byte[] GetImage();
        void Close();
    }
}
