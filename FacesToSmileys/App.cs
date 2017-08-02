using Autofac;
using FacesToSmileys.Dependencies;
using FacesToSmileys.Views;
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


            // ViewModel resolution in the constructor for UWP App
            var viewModel = Container.Resolve<TakePhotoViewModel>();
            MainPage = new TakePhotoView
            {
                BindingContext = viewModel
            };
        }

        protected override void OnStart()
        {
          
        }
    }
}
