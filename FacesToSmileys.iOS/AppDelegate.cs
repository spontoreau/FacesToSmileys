using Foundation;
using UIKit;

namespace FacesToSmileys.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Xamarin.Forms.Forms.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
