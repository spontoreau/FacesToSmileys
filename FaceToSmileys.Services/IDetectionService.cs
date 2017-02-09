using System.Collections.Generic;
using System.Threading.Tasks;
using FacesToSmileys.Models;

namespace FacesToSmileys.Services
{
    public interface IDetectionService
    {
        Task<IList<Detection>> DetectAsync(byte[] image);
    }
}
