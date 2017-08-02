using FacesToSmileys.Models;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define a configuration service.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the secret keys.
        /// </summary>
        /// <value>The secret keys.</value>
        Secret Secret { get; }
    }
}
