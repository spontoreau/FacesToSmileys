namespace FacesToSmileys.Services
{
    /// <summary>
    /// Define a file service.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Load a resource
        /// </summary>
        /// <param name="resourceName">Resource name</param>
        /// <returns>Byte array</returns>
        byte[] LoadResource(string resourceName);
    }
}
