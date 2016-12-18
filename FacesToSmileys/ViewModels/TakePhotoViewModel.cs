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
        IPhotoService PhotoService { get; }
        IDetectionService DetectionService { get; }
        IImageProcessingService ImageProcessingService { get; }
        IFileService FileService { get; }

        byte[] _photo;

        public byte[] Photo
        {
            get { return _photo; }
            set { Set(nameof(Photo), ref _photo, value); }
        }

        public ICommand TakePhotoCommand { get; private set; }

        public TakePhotoViewModel(IPhotoService photoService, 
                                  IImageProcessingService imageProcessiongService, 
                                  IDetectionService detectionService,
                                  IFileService fileService)
        {
            PhotoService = photoService;
            ImageProcessingService = imageProcessiongService;
            DetectionService = detectionService;
            FileService = fileService;
            TakePhotoCommand = new Command(async () => await TakePhoto());
        }

        public async Task TakePhoto()
        {
            IsBusy = true;

            var photo = await PhotoService.TaskPhotoAsync();
            ImageProcessingService.Open(photo);
            var detections = await DetectionService.DetectAsync(photo);

            foreach(var d in detections)
            {
                ImageProcessingService.DrawDebugRect(d.Rectangle);
                ImageProcessingService.DrawImage(FileService.Load($"{d.Attitude.ToString().ToLower()}.png"), d.Rectangle);
            }

            Photo = ImageProcessingService.GetImage();
            ImageProcessingService.Close();

            IsBusy = false;
        }
    }
}
