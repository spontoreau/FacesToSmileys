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

        public async Task<Emotion[]> GetEmotions(byte[] image)
        {
            var emotionServiceClient = new EmotionServiceClient(ServiceKey);

            using(var stream = new MemoryStream(image))
            {
                return await emotionServiceClient.RecognizeAsync(stream);
            }
        }
    }
}
