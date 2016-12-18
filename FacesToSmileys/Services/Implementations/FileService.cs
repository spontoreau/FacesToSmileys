using System;
using System.IO;
using System.Reflection;

namespace FacesToSmileys.Services.Implementations
{
    public class FileService : IFileService
    {
        public byte[] Load(string filename)
        {
            byte[] bytes;
            using (Stream s = GetType().GetTypeInfo().Assembly.GetManifestResourceStream(filename))
            {
                bytes = new byte[s.Length];
                s.Read(bytes, 0, (int)s.Length);
            }
            return bytes;
        }
    }
}
