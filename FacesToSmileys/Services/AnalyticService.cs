using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Analytic sercice.
    /// </summary>
    public class AnalyticSercice : IAnalyticService
    {
        IConfigurationService ConfigurationService { get; set; }

        /// <summary>
        /// Initializes the <see cref="T:FacesToSmileys.Implementations.AnalyticSercice"/> class.
        /// </summary>
        static AnalyticSercice()
        {
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));
        }

        public AnalyticSercice(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
            Initialize();
        }

        void Initialize()
        {
            var mobileCenterKey = ConfigurationService.GetSecret().MobileCenter;
            MobileCenter.Configure(mobileCenterKey);
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
