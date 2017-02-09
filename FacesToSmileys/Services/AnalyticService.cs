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
        /// <summary>
        /// Initializes the <see cref="T:FacesToSmileys.Implementations.AnalyticSercice"/> class.
        /// </summary>
        static AnalyticSercice()
        {
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FacesToSmileys.Services.AnalyticSercice"/> class.
        /// </summary>
        public AnalyticSercice(IConfigurationService configurationService)
        {
            MobileCenter.Configure(configurationService?.GetSecret()?.MobileCenter);
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
