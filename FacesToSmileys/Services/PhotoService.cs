using System;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace FacesToSmileys.Services
{
    public class PhotoService
    {
        public string Folder { get; set; } = "Picture";
        public string Extension { get; set; } = "png";

        public async Task<Stream> TaskPhotoAsync()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                throw new InvalidOperationException("No camera available");

            var mediaOptions = new StoreCameraMediaOptions
            {
                Directory = Folder,
                Name = $"{Guid.NewGuid()}.{Extension}"
            };

            using (var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions))
            {
                return file?.GetStream();
            }
        }
    }
}
