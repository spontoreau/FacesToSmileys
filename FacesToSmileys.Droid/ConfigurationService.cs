using System.IO;
using FacesToSmileys.Models;
using FacesToSmileys.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FacesToSmileys.Droid
{
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Gets the secret keys.
        /// </summary>
        /// <returns>Secret.</returns>
        public Secret GetSecret()
        {
            using (var stream = new StreamReader(Android.App.Application.Context.Assets.Open("secret.json")))
            {
                var json = stream.ReadToEnd();
                return JsonConvert.DeserializeObject<Secret>(json, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            }
        }
    }
}
