using FacesToSmileys.Pages;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;
using FacesToSmileys.Services.Implementations;

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

            MainPage = new TakePhotoPage
            {   
                BindingContext = new TakePhotoViewModel(photoService, imageProcessingService, detectionService)
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
