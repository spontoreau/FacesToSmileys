namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define an analytic service
    /// </summary>
    public interface IAnalyticService
    {
        /// <summary>
        /// Track an event.
        /// </summary>
        /// <param name="message">Message.</param>
        void Track(string message);
    }
}
