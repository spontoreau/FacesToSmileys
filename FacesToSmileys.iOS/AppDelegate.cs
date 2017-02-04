﻿using Foundation;
using UIKit;
using FacesToSmileys.Dependencies;
using FacesToSmileys.Services;

namespace FacesToSmileys.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif
            ExternalModule.Register<IConfigurationService, ConfigurationService>();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
