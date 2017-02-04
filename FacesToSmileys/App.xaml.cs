using FacesToSmileys.Pages;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;
// Visual Studio Mobile Center Analytics and Crashes
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Autofac;
using FacesToSmileys.Dependencies;

namespace FacesToSmileys
{
    public partial class App : Application
    {
        IContainer Container { get; }

        public App()
        {
            InitializeComponent();

            // Enable Visual Studio Mobile Center Analytics and Crashes collection
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<ViewModelModule>();
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
