using Ticketing.Storage.Enum;

namespace Ticketing.Storage.Abstractions
{
    /// <summary>
    /// Generating paths for files need to be stored
    /// </summary>
    public interface IPathGenerator
    {
        /// <summary>
        /// Generate path, used with the attachments of tickets and replies.
        /// </summary>
        /// <param name="fileId">File id stored in the database</param>
        /// <returns>File path with name </returns>
        string Generate(int fileId);


        /// <summary>
        /// Generate path, used with the users biometrics files (face, voice)
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="type">Type of file</param>
        /// <returns>File path with name</returns>
        string Generate(int userId, FileType type);
    }
}
