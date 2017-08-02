using FacesToSmileys.Views;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;
using FacesToSmileys.Services.Implementations;
using FacesToSmileys.Services;
using SimpleInjector;

namespace FacesToSmileys
{
    public class App : Application
    {
        public App()
        {
            var container = new Container();
            container.Register<IDetectionService, DetectionService>();
			container.Register<IFileService, FileService>();
			container.Register<IImageProcessingService, ImageProcessingService>();
			container.Register<IPhotoService, PhotoService>();
            container.Register<IAnalyticService, AnalyticSercice>();
            container.Register<IConfigurationService, ConfigurationService>();
            container.Register<TakePhotoViewModel>();

            MainPage = new TakePhotoView
            {
                BindingContext = container.GetInstance<TakePhotoViewModel>()
            };
        }
    }
}
