using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
// Visual Studio Mobile Center
using Microsoft.Azure.Mobile;

namespace FacesToSmileys.Droid
{
    [Activity(ScreenOrientation = ScreenOrientation.Landscape, MainLauncher = false, Label = "FacesToSmileys.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            // Enable Visual Studio Mobile Center Analytics and Crashes collection
            MobileCenter.Configure("");

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}
