using System.Windows.Input;
using System.IO;
using FacesToSmileys.Services;
using Xamarin.Forms;

namespace FacesToSmileys.ViewModels
{
    public class TakePhotoViewModel : ViewModel
    {
        PhotoService PhotoService { get; set; }
        EmotionService EmotionService { get; set; }

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
            EmotionService = new EmotionService("");//set your api access key here

            TakePhotoCommand = new Command(async () =>
            {
                IsBusy = true;
                using(var ms = new MemoryStream())
                {
                    using(var stream = await PhotoService.TaskPhotoAsync())
                    {
                        var emotions = await EmotionService.GetEmotions(stream);
                        stream.CopyTo(ms);
                        Photo = ms.ToArray();
                    }
                }
                IsBusy = false;
            });
        }
    }
}
