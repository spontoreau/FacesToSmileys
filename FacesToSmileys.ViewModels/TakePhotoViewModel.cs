using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using FacesToSmileys.Services;
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
        /// Gets the analytic service.
        /// </summary>
        /// <value>The analytic service.</value>
        IAnalyticService AnalyticService { get; }

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

        ObservableAsPropertyHelper<bool> _isBusy;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:FacesToSmileys.ViewModels.TakePhotoViewModel"/> is busy.
        /// </summary>
        /// <value><c>true</c> if is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy => _isBusy.Value;

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

            Initialize();
        }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        void Initialize()
        {
            var command = ReactiveCommand.CreateFromTask<Unit, byte[]>((u) => TakePhoto());

            _photo = command.ToProperty(this, x => x.Photo, new byte[0]);
            _isBusy = command.IsExecuting.ToProperty(this, x => x.IsBusy, false);

            TakePhotoCommand = command;
        }

        /// <summary>
        /// Takes the photo.
        /// </summary>
        /// <returns>The photo.</returns>
        public async Task<byte[]> TakePhoto()
        {
            var photo = await PhotoService.TaskPhotoAsync();
            // Track Camera usage
            AnalyticService.Track("Photo taken");

            ImageProcessingService.Open(photo);
            var detections = await DetectionService.DetectAsync(photo);

            foreach (var d in detections)
            {
                // Track each detection
                AnalyticService.Track($"Detection done:{d.Attitude.ToString().ToLower()}");

#if DEBUG
                ImageProcessingService.DrawDebugRect(d.Rectangle);
#endif
                ImageProcessingService.DrawImage(FileService.Load($"{d.Attitude.ToString().ToLower()}.png"), d.Rectangle);
            }

            var finalImage = ImageProcessingService.GetImage();
            ImageProcessingService.Close();

            return finalImage;
        }
    }
}
