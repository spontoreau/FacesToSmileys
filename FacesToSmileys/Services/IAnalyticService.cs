namespace FacesToSmileys.Services
{
    public interface IAnalyticService
    {
        /// <summary>
        /// Track an event.
        /// </summary>
        /// <param name="message">Message.</param>
        void Track(string message);
    }
}
