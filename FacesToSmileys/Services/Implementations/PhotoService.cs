using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace FacesToSmileys.Services.Implementations
{
    public class PhotoService : IPhotoService
    {
        public async Task<byte[]> TaskPhotoAsync()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                throw new InvalidOperationException("No camera available");

            var mediaOptions = new StoreCameraMediaOptions
            {
                Directory = "Picture",
                Name = $"{Guid.NewGuid()}.bmp",
                PhotoSize = PhotoSize.Medium
            };

            using (var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions))
            {
                using(var ms = new MemoryStream())
                {
                    file?.GetStream()?.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}
