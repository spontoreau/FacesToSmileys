using FacesToSmileys.Pages;
using FacesToSmileys.ViewModels;
using Xamarin.Forms;

namespace FacesToSmileys
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TakePhotoPage
            {
                BindingContext = new TakePhotoViewModel()
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
