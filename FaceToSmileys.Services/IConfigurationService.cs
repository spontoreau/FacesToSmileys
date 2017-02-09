using FacesToSmileys.Models;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define a configuration service.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets secret keys.
        /// </summary>
        /// <returns>Secret.</returns>
        Secret GetSecret();
    }
}
