using System.Collections.Generic;
using System.Threading.Tasks;
using FacesToSmileys.Models;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define a detection service
    /// </summary>
    public interface IDetectionService
    {
        /// <summary>
        /// Detect all faces inside an image
        /// </summary>
        /// <param name="image">Byte array corresponding to an inmage</param>
        /// <returns>Collection of detections</returns>
        Task<IList<Detection>> DetectAsync(byte[] image);
    }
}
