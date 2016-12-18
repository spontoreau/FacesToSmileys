using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FacesToSmileys.Models;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;

namespace FacesToSmileys.Services.Implementations
{
    public class DetectionService : IDetectionService
    {
        public string ServiceKey { get; }

        public DetectionService(string serviceKey)
        {
            ServiceKey = serviceKey;
        }

        public async Task<IList<Detection>> DetectAsync(byte[] image)
        {
            var emotionServiceClient = new EmotionServiceClient(ServiceKey);

            using(var stream = new MemoryStream(image))
            {
                var emotions = await emotionServiceClient.RecognizeAsync(stream);
                return emotions
                    .Select(x => new Detection(GetAttitude(x.Scores.ToRankedList().First().Key), new Rectangle(x.FaceRectangle.Left, x.FaceRectangle.Top, x.FaceRectangle.Width, x.FaceRectangle.Height)))
                    .ToList();
            }
        }

        public Attitude GetAttitude(string bestScore)
        {
            return (Attitude)Enum.Parse(typeof(Attitude), bestScore);
        }
    }
}
