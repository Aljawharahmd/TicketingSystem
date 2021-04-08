using System.Threading.Tasks;

namespace Ticketing.Storage.Abstractions
{
    /// <summary>
    /// Manage the storage by saving and getting files
    /// </summary>
    public interface IFileStorage
    {
        /// <summary>
        /// Save the file to storage 
        /// </summary>
        /// <param name="path">Where to save the file and file name</param>
        /// <param name="file">To save the file as an array of bytes </param>
        /// <returns></returns>
        Task Save(string path, byte[] file);

        /// <summary>
        /// Get the file from the storage based on the path
        /// </summary>
        /// <param name="path">Path of the file to be fetched from the storage </param>
        /// <returns> The file requested, as an array of bytes </returns>
        Task<byte[]> Get(string path);

    }
}
