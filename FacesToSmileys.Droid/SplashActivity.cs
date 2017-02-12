using Android.App;
using Android.Content.PM;
using Android.OS;

namespace FacesToSmileys.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.SensorLandscape, Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.StartActivity(typeof(MainActivity));
        }
    }
}
