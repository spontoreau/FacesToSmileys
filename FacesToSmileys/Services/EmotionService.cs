using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace FacesToSmileys.Services
{
    public class EmotionService
    {
        public string ServiceKey { get; }

        public EmotionService(string serviceKey)
        {
            ServiceKey = serviceKey;
        }

        public async Task<Emotion[]> GetEmotions(Stream stream)
        {
            var emotionServiceClient = new EmotionServiceClient(ServiceKey);
            return await emotionServiceClient.RecognizeAsync(stream);
        }
    }
}
