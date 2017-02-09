using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FacesToSmileys.Models;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace FacesToSmileys.Services
{
    public class DetectionService : IDetectionService
    {
        IConfigurationService ConfigurationService { get; set; }

        public DetectionService(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        public async Task<IList<Detection>> DetectAsync(byte[] image)
        {
            var cognitiveKey = ConfigurationService.GetSecret().Cognitive;
            var emotionServiceClient = new EmotionServiceClient(cognitiveKey);

            using(var stream = new MemoryStream(image))
            {
                var emotions = await emotionServiceClient.RecognizeAsync(stream);
                return emotions
                    .Select(x => new Detection(x.Scores.ToRankedList().First().Key, new Rectangle(x.FaceRectangle.Left, x.FaceRectangle.Top, x.FaceRectangle.Width, x.FaceRectangle.Height)))
                    .ToList();
            }
        }
    }
}
