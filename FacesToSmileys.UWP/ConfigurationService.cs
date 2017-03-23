using FacesToSmileys.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacesToSmileys.Models;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FacesToSmileys.UWP
{
    class ConfigurationService : IConfigurationService
    {

        public Secret GetSecret()
        {
            string json = null;

            Task.Run(async () =>
            {
                var secretFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\secret.json");
                json = await Windows.Storage.FileIO.ReadTextAsync(secretFile);
            }).Wait();

            return JsonConvert.DeserializeObject<Secret>(json, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
