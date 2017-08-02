using System.IO;
using System.Reflection;
using FacesToSmileys.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FacesToSmileys.Services.Implementations
{
    /// <summary>
    /// Configuration service.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
		/// <summary>
		/// Gets the secret keys.
		/// </summary>
		/// <value>The secret keys.</value>
		public Secret Secret { get; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:FacesToSmileys.Services.Implementations.ConfigurationService"/> class.
        /// </summary>
        public ConfigurationService()
        {
            using (var stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(""))
            {
                using (var reader = new StreamReader(stream))
				{
					Secret = JsonConvert.DeserializeObject<Secret>(reader.ReadToEnd(), new JsonSerializerSettings
					{
						ContractResolver = new CamelCasePropertyNamesContractResolver()
					});
				}
            }
        }
    }
}
