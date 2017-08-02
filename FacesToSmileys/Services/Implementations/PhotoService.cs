using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace FacesToSmileys.Services.Implementations
{
    /// <summary>
    /// Photo service
    /// </summary>
    public class PhotoService : IPhotoService
    {
        /// <summary>
        /// Take a photo
        /// </summary>
        /// <returns>Byte array corresponding to the phpto</returns>
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
