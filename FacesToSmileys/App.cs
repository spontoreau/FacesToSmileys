using Autofac;
using FacesToSmileys.Views;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;
using FacesToSmileys.Services.Implementations;
using FacesToSmileys.Services;

namespace FacesToSmileys
{
    public class App : Application
    {
        public App()
        {
            var builder = new ContainerBuilder();
			builder.RegisterType<DetectionService>().As<IDetectionService>();
			builder.RegisterType<FileService>().As<IFileService>();
			builder.RegisterType<ImageProcessingService>().As<IImageProcessingService>();
			builder.RegisterType<PhotoService>().As<IPhotoService>();
			builder.RegisterType<AnalyticSercice>().As<IAnalyticService>();
            builder.RegisterType<ConfigurationService>().As<IConfigurationService>();
			builder.RegisterType<TakePhotoViewModel>().OnActivated(e => e.Context.InjectUnsetProperties(e.Instance));
            var container = builder.Build();

            MainPage = new TakePhotoView
            {
                BindingContext = container.Resolve<TakePhotoViewModel>()
            };
        }
    }
}
