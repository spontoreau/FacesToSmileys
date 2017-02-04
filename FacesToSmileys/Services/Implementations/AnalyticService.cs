using System;
using FacesToSmileys.Services;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace FacesToSmileys.Implementations
{
    /// <summary>
    /// Analytic sercice.
    /// </summary>
    public class AnalyticSercice : IAnalyticService
    {
        /// <summary>
        /// Initializes the <see cref="T:FacesToSmileys.Implementations.AnalyticSercice"/> class.
        /// </summary>
        static AnalyticSercice()
        {
            // Enable Visual Studio Mobile Center Analytics and Crashes collection
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));
        }

        public AnalyticSercice()
        {
            //Initialize();
        }

        void Initialize()
        {
            //TODO configure with json configuration file
            MobileCenter.Configure("");
        }

        /// <summary>
        /// Track the specified message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void Track(string message)
        {
            Analytics.TrackEvent(message);
        }
    }
}
