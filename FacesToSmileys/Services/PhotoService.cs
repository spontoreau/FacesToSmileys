using System;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace FacesToSmileys.Services
{
    public class PhotoService
    {
        public string Folder { get; set; } = "Picture";
        public string Extension { get; set; } = "png";

        public async Task<string> TaskPhotoAsync()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                return string.Empty;

            var mediaOptions = new StoreCameraMediaOptions
            {
                Directory = Folder,
                Name = $"{Guid.NewGuid()}.{Extension}"
            };

            using (var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions))
            {
                return file?.Path;
            }
        }
    }
}
