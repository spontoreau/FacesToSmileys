using System.IO;
using System.Reflection;

namespace FacesToSmileys.Services.Implementations
{
    /// <summary>
    /// File service.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Load a resource
        /// </summary>
        /// <param name="resourceName">Resource name</param>
        /// <returns>Byte array</returns>
        public byte[] LoadResource(string filename)
        {
            using (Stream s = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(filename))
            {
                var bytes = new byte[s.Length];
                s.Read(bytes, 0, (int)s.Length);
                return bytes;
            }
        }
    }
}
