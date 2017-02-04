using FacesToSmileys.Models;
using FacesToSmileys.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FacesToSmileys.iOS
{
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Gets the secret keys.
        /// </summary>
        /// <returns>Secret.</returns>
        public Secret GetSecret()
        {
            var json = System.IO.File.ReadAllText("secret.json");
            return JsonConvert.DeserializeObject<Secret>(json, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
