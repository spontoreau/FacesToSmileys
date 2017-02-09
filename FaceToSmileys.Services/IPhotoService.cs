using System.Threading.Tasks;

namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define a photo service
    /// </summary>
    public interface IPhotoService
    {
        /// <summary>
        /// Take a photo
        /// </summary>
        /// <returns>Byte array corresponding to the phpto</returns>
        Task<byte[]> TaskPhotoAsync();
    }
}
