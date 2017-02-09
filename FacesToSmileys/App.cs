using Autofac;
using FacesToSmileys.Dependencies;
using FacesToSmileys.Pages;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;

namespace FacesToSmileys
{
    public class App : Application
    {
        IContainer Container { get; }

        public App()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<ViewModelModule>();
            containerBuilder.RegisterModule<ExternalModule>();
            Container = containerBuilder.Build();
        }

        protected override void OnStart()
        {
            var viewModel = Container.Resolve<TakePhotoViewModel>();
            MainPage = new TakePhotoPage()
            {
                BindingContext = viewModel
            };
        }
    }
}
