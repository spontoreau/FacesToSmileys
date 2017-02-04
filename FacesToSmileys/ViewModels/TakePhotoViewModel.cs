using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using FacesToSmileys.Services;
using Microsoft.Azure.Mobile.Analytics;
using ReactiveUI;

namespace FacesToSmileys.ViewModels
{
    /// <summary>
    /// Take photo ViewModel.
    /// </summary>
    public class TakePhotoViewModel : ReactiveObject
    {
        /// <summary>
        /// Gets the photo service.
        /// </summary>
        /// <value>The photo service.</value>
        IPhotoService PhotoService { get; }

        /// <summary>
        /// Gets the detection service.
        /// </summary>
        /// <value>The detection service.</value>
        IDetectionService DetectionService { get; }

        /// <summary>
        /// Gets the image processing service.
        /// </summary>
        /// <value>The image processing service.</value>
        IImageProcessingService ImageProcessingService { get; }

        /// <summary>
        /// Gets the file service.
        /// </summary>
        /// <value>The file service.</value>
        IFileService FileService { get; }

        ObservableAsPropertyHelper<byte[]> _photo;

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        public byte[] Photo => _photo.Value;

        bool _isBusy;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FacesToSmileys.ViewModels.TakePhotoViewModel"/> is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return _isBusy; }
            set { this.RaiseAndSetIfChanged(ref _isBusy, value); }
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

            var command = ReactiveCommand.CreateFromTask<Unit, byte[]>((u) => TakePhoto());
            _photo = command.ToProperty(this, x => x.Photo, new byte[0]);

            TakePhotoCommand = command;
        }

        public async Task<byte[]> TakePhoto()
        {
            IsBusy = true;

            var photo = await PhotoService.TaskPhotoAsync();
            // Track Camera usage
            Analytics.TrackEvent("Photo taken");

            ImageProcessingService.Open(photo);
            var detections = await DetectionService.DetectAsync(photo);

            foreach (var d in detections)
            {
                // Track each detection
                Analytics.TrackEvent($"Detection done:{d.Attitude.ToString().ToLower()}");

#if DEBUG
                ImageProcessingService.DrawDebugRect(d.Rectangle);
#endif
                ImageProcessingService.DrawImage(FileService.Load($"{d.Attitude.ToString().ToLower()}.png"), d.Rectangle);
            }

            var finalImage = ImageProcessingService.GetImage();
            ImageProcessingService.Close();

            IsBusy = false;
            return finalImage;
        }
    }
}
