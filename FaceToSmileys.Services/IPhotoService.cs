using System.Threading.Tasks;

namespace FacesToSmileys.Services
{
    public interface IPhotoService
    {
        Task<byte[]> TaskPhotoAsync();
    }
}
