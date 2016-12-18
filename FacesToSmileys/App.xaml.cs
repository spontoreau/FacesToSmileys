using FacesToSmileys.Pages;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;
using FacesToSmileys.Services.Implementations;
using FacesToSmileys.Services;

namespace FacesToSmileys
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var photoService = new PhotoService();
            var imageProcessingService = new ImageProcessingService();
            var detectionService = new DetectionService("");//set your api access key here
            var fileService = new FileService();
            MainPage = new TakePhotoPage
            {
                BindingContext = new TakePhotoViewModel(photoService, imageProcessingService, detectionService, fileService)
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
