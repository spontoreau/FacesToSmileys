using System.Windows.Input;
using System.IO;
using FacesToSmileys.Services;
using Xamarin.Forms;
using SkiaSharp;
using System;
using System.Threading.Tasks;

namespace FacesToSmileys.ViewModels
{
    public class TakePhotoViewModel : ViewModel
    {
        PhotoService PhotoService { get; }
        EmotionService EmotionService { get; }
        ImageProcessingService ImageProcessingService { get; }

        byte[] _photo;

        public byte[] Photo
        {
            get { return _photo; }
            set { Set(nameof(Photo), ref _photo, value); }
        }

        public ICommand TakePhotoCommand { get; private set; }

        public TakePhotoViewModel()
        {
            PhotoService = new PhotoService();
            ImageProcessingService = new ImageProcessingService();
            EmotionService = new EmotionService("");//set your api access key here


            TakePhotoCommand = new Command(async () => await TakePhoto());
        }

        public async Task TakePhoto()
        {
            IsBusy = true;

            var photo = await PhotoService.TaskPhotoAsync();
            ImageProcessingService.Open(photo);
            var emotions = await EmotionService.GetEmotions(photo);

            foreach(var e in emotions)
            {
                ImageProcessingService.DrawDebugRect(e.FaceRectangle.Left, e.FaceRectangle.Top, e.FaceRectangle.Width, e.FaceRectangle.Height, "#c0392b");
            }

            Photo = ImageProcessingService.GetImage();
            ImageProcessingService.Close();

            IsBusy = false;
        }
    }
}
