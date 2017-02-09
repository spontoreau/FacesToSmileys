using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FacesToSmileys.Models;
using Microsoft.ProjectOxford.Emotion;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Detection service
    /// </summary>
    public class DetectionService : IDetectionService
    {
        /// <summary>
        /// Configuration service
        /// </summary>
        IConfigurationService ConfigurationService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FacesToSmileys.Services.DetectionService"/> class.
        /// </summary>
        public DetectionService(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        /// <summary>
        /// Detect all face inside an image
        /// </summary>
        /// <param name="image">Byte array corresponding to an inmage</param>
        /// <returns>Collection of detections</returns>
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
