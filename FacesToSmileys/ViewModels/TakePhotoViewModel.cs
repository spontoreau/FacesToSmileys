using System.Threading.Tasks;
using System.Windows.Input;
using FacesToSmileys.Services;
using Xamarin.Forms;

namespace FacesToSmileys.ViewModels
{
    /// <summary>
    /// Take photo ViewModel.
    /// </summary>
    public class TakePhotoViewModel : ViewModelBase
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
        /// Gets the analytic service.
        /// </summary>
        /// <value>The analytic service.</value>
        IAnalyticService AnalyticService { get; }

        /// <summary>
        /// Gets the file service.
        /// </summary>
        /// <value>The file service.</value>
        IFileService FileService { get; }

        byte[] _photo;

        /// <summary>
        /// Gets or sets the photo.
        /// </summary>
        /// <value>The photo.</value>
        public byte[] Photo
        {
            get => _photo;
            set => Set(nameof(Photo), ref _photo, value);
        }

        bool _isBusy;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:FacesToSmileys.ViewModels.TakePhotoViewModel"/> is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get => _isBusy;
            set => Set(nameof(IsBusy), ref _isBusy, value);
        }

        /// <summary>
        /// Gets the take photo command.
        /// </summary>
        /// <value>The take photo command.</value>
        public ICommand TakePhotoCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FacesToSmileys.ViewModels.TakePhotoViewModel"/> class.
        /// </summary>
        /// <param name="photoService">Photo service.</param>
        /// <param name="imageProcessiongService">Image processiong service.</param>
        /// <param name="detectionService">Detection service.</param>
        /// <param name="fileService">File service.</param>
        public TakePhotoViewModel(IPhotoService photoService,
                                  IImageProcessingService imageProcessiongService,
                                  IDetectionService detectionService,
                                  IFileService fileService,
                                  IAnalyticService analyticService)
        {
            PhotoService = photoService;
            ImageProcessingService = imageProcessiongService;
            DetectionService = detectionService;
            FileService = fileService;
            AnalyticService = analyticService;

            TakePhotoCommand = new Command(async () => await TakePhoto());
        }
        
        /// <summary>
        /// Takes the photo.
        /// </summary>
        /// <returns>The photo.</returns>
        public async Task TakePhoto()
        {
            IsBusy = true;
            var photo = await PhotoService.TaskPhotoAsync();

            if (photo.Length == 0)
            {
                Photo = photo;
                return;
            }

            // Track Camera usage
            AnalyticService.Track("Photo taken");

            ImageProcessingService.Open(photo);
            var detections = await DetectionService.DetectAsync(photo);

            foreach (var d in detections)
            {
                // Track each detection
                AnalyticService.Track($"Detection done:{d.Emotion.ToLower()}");

#if DEBUG
                ImageProcessingService.DrawDebugRect(d.Rectangle);
#endif
                ImageProcessingService.DrawImage(FileService.LoadResource($"{d.Emotion.ToLower()}.png"), d.Rectangle);
            }

            var finalImage = ImageProcessingService.GetImage();
            ImageProcessingService.Close();

            Photo = finalImage;
            IsBusy = false;
        }
    }
}
