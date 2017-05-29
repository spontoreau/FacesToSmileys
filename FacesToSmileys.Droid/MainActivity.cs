
using Android.App;
using Android.Content.PM;
using Android.OS;
using FacesToSmileys.Dependencies;
using FacesToSmileys.Services;

namespace FacesToSmileys.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.FullSensor, MainLauncher = false, Label = "FacesToSmileys.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ExternalModule.Register<IConfigurationService, ConfigurationService>();
            LoadApplication(new App());
        }
    }
}
